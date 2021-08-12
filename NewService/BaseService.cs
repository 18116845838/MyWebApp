using AutoMapper;
using NewEntity;
using NewGlobal;
using NewViewModel;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NewService
{
	public class BaseService
	{
		protected readonly static MapperConfiguration config;
		static BaseService()
		{
			config = new MapperConfiguration(
				cfg => cfg.CreateMap<User, UserModel>().ReverseMap()
				);
		}
		protected IMapper mapper { get { return config.CreateMapper(); } }

		protected SqlDbContext context
		{
			get
			{
				if (HttpContext.Current.Items[Keys.DbContext] == null)
				{
					SqlDbContext cx = new SqlDbContext();
					HttpContext.Current.Items[Keys.DbContext] = cx;
				}//else nothing
				return  HttpContext.Current.Items[Keys.DbContext] as SqlDbContext;
				
			}
		}

		public User GetCurrentUser()
		{
			HttpCookie userInfo = HttpContext.Current.Request.Cookies[Keys.Cookie];
			if (userInfo==null)
			{
				return null;
			}//else nothing
			bool hasUserId = int.TryParse(userInfo[Keys.UserId], out int currentUserId);
			if (!hasUserId)
			{
				Delete(Keys.Cookie);
				return null;
			}//else nothing 
			string pwdInCookie = userInfo[Keys.Password];
			if (string.IsNullOrEmpty(pwdInCookie))
			{
				throw new ArgumentException("");
			}//else nothing	
			User user= new UserRepository(context).Find(currentUserId);
			if (user != null)
			{
				if (pwdInCookie != user.Password)
				{
					throw new ArgumentException("");
				}//else nothing
			}//else nothing
			return user;
		}

		private void Delete(string cookie)
		{
			HttpCookie urrentCookie = HttpContext.Current.Request.Cookies[cookie];
			urrentCookie.Expires = DateTime.Now.AddDays(-1);
			HttpContext.Current.Response.Cookies.Add(urrentCookie);
		}
	}
}
