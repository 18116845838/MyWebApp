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
				cfg.CreateMap<Arcticle, VM.ArcticleModel>().ReverseMap();
			}
			);
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
