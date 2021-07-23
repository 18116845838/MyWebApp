using Entities;
using Global;
using Repositoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SRV.ProdService
{
	public class BaseService
	{
		private UserRepository userRepository;
		//protected SqlDbContext _context;
		protected SqlDbContext context
		{
			get
			{
				if (HttpContext.Current.Items[Keys.DbContext]==null)
				{
					HttpContext.Current.Items[Keys.DbContext]= new SqlDbContext();

				}
				return  (SqlDbContext)HttpContext.Current.Items[Keys.DbContext];
			}
		}
		public BaseService()
		{

			userRepository = new UserRepository(context);
		}

		 public User GetCurrentUser()
		{
			HttpCookie userInfo = HttpContext.Current.Request.Cookies[Keys.User];
			if (userInfo==null)
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

			if (pwdInCookie!=current.Password.MD5Encrypt())
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
	}
}
