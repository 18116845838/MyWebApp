using _17bangMVC.Models;
using Entities;
using Repositoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17bangMVC.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        Repositorys<User> repositorys;
		public RegisterController()
		{
            repositorys = new Repositorys<User>();
		}
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserModel model)
        {

			if (!ModelState.IsValid)
			{
                return View(model);
			}
            User user = new User
            {
                Name=model.Name,
                Password=model.Password
            };
            repositorys.Save(user);
            return View();
        }
    }
}