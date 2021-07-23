using _17bangMVC.Models;
using Global;
using SRV.ProdService;
using SRV.SerciceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace _17bangMVC.Controllers
{
	public class RegisterController : Controller
	{
		// GET: Register
		//Repositorys<User> repositorys;
		//public RegisterController()
		//{
		//	SqlDbContext context = new SqlDbContext();
		//	repositorys = new Repositorys<User>(context);
		//}
		public IUserService userService;
		public RegisterController()
		{
			userService = new UserService();
		}
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Index(RegisterModel model)
		{


			int? UserId = userService.Register(model);
			if (UserId==null)
			{
				ModelState.AddModelError(nameof(model.Name), "用户名重复");
			}//else nothing
			if (!ModelState.IsValid)
			{
				return View(model);
			}//else nothing

			HttpCookie cookie = new HttpCookie(Keys.User);
			cookie.Values.Add(Keys.Id, UserId.ToString());
			cookie.Values.Add(Keys.Password, model.Password.MD5Encrypt());
			cookie.Expires = DateTime.Now.AddDays(14);
			Response.Cookies.Add(cookie);
			return View();
		}
	}
}