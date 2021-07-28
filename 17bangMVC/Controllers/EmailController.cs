using SRV.ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace _17bangMVC.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(EmailModel model)
        {
             new EmailService().ValidationEmail(model, out string code);
            string _code = code;
			return RedirectToAction("SaveEmail",new { _code});
		}
        public ActionResult SaveEmail(EmailModel model,string _code)
        {
			if (model.Code!=null)
			{
                if (model.Code != _code)
                {
                    ModelState.AddModelError(nameof(model.Code), "验证码错误或过期");
                }
                else
                {
                    new EmailService().Save(model);
                }
            }//else nothig
			
            return View(model);
        }
	}
}