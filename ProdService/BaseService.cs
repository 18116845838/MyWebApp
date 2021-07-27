using VM=_17bangMVC.Models;
using AutoMapper;
using Entities;
using Global;
using Repositoy;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ViewModel;

namespace SRV.ProdService
{
	public class BaseService
	{
		//设置唯一的MapperConfiguration
		protected readonly static MapperConfiguration config;
		static BaseService()
		{
			config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Article, VM.ArcticleModel>().ReverseMap();
				cfg.CreateMap<RegisterModel, User>().ReverseMap()
				.ForMember(a=>a.InviterBy,opt=>opt.Ignore())
				;
				////这一条中的不需要验证了
				//cfg.CreateMap<Arcticle, VM.ArcticleModel>(MemberList.None)
				////这一个单独的成员不映射了
				//.ForMember(a=>a.Author,opt=>opt.Ignore())
				////配置Arctic的titlt和ArcticleModel的Id相匹配
				//.ForMember(a=>a.Title,opt=>opt.MapFrom(vm=>vm.Id))
				////null值替代，如果Author是null值，就可以用参数进行替换
				//.ForMember(a=>a.Author,opt=>opt.NullSubstitute(new User()))
				//.ReverseMap();
			}
			);
#if DEBUG
			//只在开发环境下面 检查所有配置是否有效
			//config.AssertConfigurationIsValid();
#endif

		}
		protected IMapper mapper
		{
			get { return config.CreateMapper(); }
		}

		private UserRepository userRepository;
		//protected SqlDbContext _context;
		protected SqlDbContext context
		{
			get
			{
				if (HttpContext.Current.Items[Keys.DbContext] == null)
				{
					SqlDbContext cx = new SqlDbContext();
					cx.Database.BeginTransaction();

					HttpContext.Current.Items[Keys.DbContext] = cx;

				}
				return (SqlDbContext)HttpContext.Current.Items[Keys.DbContext];
			}
		}
		public BaseService()
		{

			userRepository = new UserRepository(context);
		}

		public User GetCurrentUser()
		{
			HttpCookie userInfo = HttpContext.Current.Request.Cookies[Keys.User];
			if (userInfo == null)
			{
				return null;
			}//else nothing
			bool HasUserId = int.TryParse(userInfo[Keys.Id], out int currentUserId);

			if (!HasUserId)
			{
				Delete(Keys.User);
			}//else nothing
			string pwdInCookie = userInfo[Keys.Password];
			if (string.IsNullOrWhiteSpace(pwdInCookie))
			{
				throw new ArgumentException("");
			}//else nothing

			User current = userRepository.Find(currentUserId);

			if (pwdInCookie != current.Password.MD5Encrypt())
			{
				throw new ArgumentException("");
			}
			return current;
		}

		private static void Delete(string name)
		{
			HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
			cookie.Expires = DateTime.Now.AddDays(-1);
			HttpContext.Current.Response.Cookies.Add(cookie);
		}

		private static SqlDbContext GetContextFromHttp()
		{
			object objContext = HttpContext.Current.Items[Keys.DbContext];
			//取到之就删除掉，ChildAction去取的时候会重新New一个
			HttpContext.Current.Items.Remove(Keys.DbContext);
			return objContext as SqlDbContext;
		}
		public static void Commit()
		{
			SqlDbContext context = GetContextFromHttp();
			if (context != null)
			{
				context.SaveChanges();
				using (context)
				{
					using (DbContextTransaction transaction = context.Database.CurrentTransaction)
					{

						transaction.Commit();
					}
				}
			}
		}
		public static void Rollback()
		{
			SqlDbContext context = GetContextFromHttp();
			if (context != null)
			{
				using (context)
				{
					using (DbContextTransaction transaction = context.Database.CurrentTransaction)
					{
						transaction.Rollback();
					}
				}
			}
		}
	}
}
