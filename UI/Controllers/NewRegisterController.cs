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
			if (model!=null)
			{

			}
            int? userid =new UserService().Register(model);
            return View();
        }
    }
}