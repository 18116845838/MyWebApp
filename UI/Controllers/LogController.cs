using NewGlobal;
using NewService;
using NewViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class LogController : Controller
    {
        private UserService userService;
        public LogController()
		{
            userService = new UserService();
		}
        // GET: Log
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LogModel model)
        {
			if (!ModelState.IsValid)
			{
                return View();
			}//else nothing
            UserModel userModel = userService.GetByName(model.Name);
            
            if (userModel==null)
			{
                ModelState.AddModelError("Name", "用户名不存在");
                return View();
			}
			else
			{
                if (model.Password.MD5Encrypt() != userModel.Password)
                {
                    ModelState.AddModelError("Password", "用户名或者密码输入错误");
                    return View();
				}
				else
				{
                    HttpCookie cookie = new HttpCookie(Keys.Cookie);
                    cookie.Values.Add(Keys.UserId, userModel.Id.ToString());
                    cookie.Values.Add(Keys.Password, model.Password.MD5Encrypt());
                    cookie.Expires = DateTime.Now.AddDays(14);
                    Response.Cookies.Add(cookie);
                }
            }
            return View();
        }
        //退出登录页面
        public ActionResult LogOff()
        {
            HttpCookie httpCookie = Request.Cookies.Get(Keys.Cookie);
			if (httpCookie!=null)
			{
                Response.Cookies[Keys.Cookie].Expires = DateTime.Now.AddDays(-1);
			}//else nothing
            return RedirectToAction("Index");
        }


    }
}