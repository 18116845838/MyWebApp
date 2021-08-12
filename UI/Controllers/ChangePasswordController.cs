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
    public class ChangePasswordController : Controller
    {
        // GET: ChangePassword
        private string confirmNewPassword;

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ChangePasswordModel model)
        {

			//if (Request.Cookies[Keys.Cookie] != null)
			//{
			//    model.Password = new UserService().GetByName()
			//}
			if (!ModelState.IsValid)
			{
                return View();
            }//else mothing
            confirmNewPassword = Request.Form["confirmNewPassword"];
			if (model.Password == model.NewPassword)
			{
                ModelState.AddModelError("Password","原密码和新密码一致");
                return View();
			}//else mothing
            if (confirmNewPassword != model.NewPassword)
            {
                ModelState.AddModelError("NewPassword", "新密码和旧密码不一致");
                return View();
            }//else mothing

            new UserService().ChangePassword(model);
            return View();
        }
    }
}