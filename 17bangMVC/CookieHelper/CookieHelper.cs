using Global;
using SRV.ProdService;
using SRV.SerciceInterface;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace _17bangMVC.CookieHelper
{

	public class CookieHelper
	{
		//public IUserService userService;
		//public CookieHelper()
		//{
		//	userService = new UserService();
		//}
		public static void Delete(string name)
		{
			HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
			cookie.Expires = DateTime.Now.AddDays(-1);
			HttpContext.Current.Response.Cookies.Add(cookie);
		}
		public static int? GetCurrentUserId()
		{
			HttpCookie userInfo =HttpContext.Current.Request.Cookies[Keys.User];
			if (userInfo == null)
			{
				return null;
			}//else nothing
			bool HasUserId = int.TryParse(userInfo[Keys.Id], out int currentUserId);
			if (!HasUserId)
			{
				Delete(Keys.User);
				//throw new ArgumentException("");
			}//else nothing
			string pwdInCookie = userInfo[Keys.Password];
			if (string.IsNullOrEmpty(pwdInCookie))
			{
				throw new ArgumentException("");
			}//else nothing
			 //string pwd = userService.GetPwdById(currentUserId);
			string pwd = new UserService().GetPwdById(currentUserId);
			if (pwd.MD5Encrypt() != pwdInCookie)
			{
				throw new ArgumentException("");
			}//else nothing
			return currentUserId;
		}
	}
}