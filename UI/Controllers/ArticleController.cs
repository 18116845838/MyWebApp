using NewService;
using NewViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index(ArticleModel model)
        {
            model = new ArticleService().Get();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int ArticleId)
        {

            return View();
        }
    }
}