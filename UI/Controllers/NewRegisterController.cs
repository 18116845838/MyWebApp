using NewService;
using NewViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace UI.Controllers
{
    public class NewRegisterController : Controller
    {
        // GET: NewRegister
        public string ConfirmPassword { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserModel model)
        {
			if (!ModelState.IsValid)
			{
                return View();
			}//else nothing
			if (model.Password!=ConfirmPassword)
			{
                ModelState.AddModelError("ConfirmPassword", "确认密码和密码不一致");
                return View();
			}//else nothing
            int? userid =new UserService().Register(model);
			if (userid==null)
			{
                ModelState.AddModelError("Name", "用户名已存在");
                return View();
			}//else nothing
            return View();
        }
    }
}