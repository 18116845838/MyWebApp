using Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17bangMVC.Controllers
{
    public class BaseController : Controller
    {
        //在BaseController中实现CurrentUserId，并利用它完成：（带作者的）内容发布功能。 
        public int? CurrentUserId()
        {
            var userInfo = Request.Cookies[Keys.User].Values;
			if (userInfo==null)
			{
                return null;
			}
            bool HasUserid = int.TryParse(userInfo[Keys.Id], out int currentUserid);
			if (!HasUserid)
			{
                throw new ArgumentException("");
			}
            string pwdInCookie = userInfo[Keys.Password];
			if (string.IsNullOrWhiteSpace(pwdInCookie))
			{
                throw new ArgumentException("");
			}
   //         string pwd = userservice.GetPwdById(currentUserid);
			//if (pwd != pwdInCookie)
			//{
   //             throw new ArgumentException("");
			//}
            return 1;
        }

    }
}