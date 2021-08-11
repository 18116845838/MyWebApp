
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
    public class NewRegisterController : Controller
    {
        // GET: NewRegister
        private UserService userService;
        private string confirmPassword;

        public NewRegisterController()
		{
            userService = new UserService();

        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserModel model)
        {
            confirmPassword = Request.Form["confirmPassword"];

            if (!ModelState.IsValid)
			{
                return View();
			}//else nothing
			if (model.Password!=confirmPassword)
			{
                ModelState.AddModelError("ConfirmPassword", "确认密码和密码不一致");
                return View();
			}//else nothing
            UserModel inviterBy = userService.GetByName(model.InviterBy);
			if (inviterBy==null)
			{
                ModelState.AddModelError("InviterBy", "用户名不存在");
                return View();
			}
			else
			{
				if (inviterBy.InviterByCode!=model.InviterByCode)
				{
                    ModelState.AddModelError("InviterByCode","邀请人的邀请码不正确");
                    return View();
				}//else nothing
			}

            int? userid =userService.Register(model);
			if (userid==null)
			{
                ModelState.AddModelError("Name", "用户名已存在");
                return View();
			}//else nothing
            HttpCookie cookie = new HttpCookie(Keys.Cookie);
            cookie.Values.Add(Keys.UserId,model.Id.ToString());
            cookie.Values.Add(Keys.Password,model.Password.MD5Encrypt());
            cookie.Expires = DateTime.Now.AddDays(14);
            Response.Cookies.Add(cookie);
            return View();
        }
    }
}