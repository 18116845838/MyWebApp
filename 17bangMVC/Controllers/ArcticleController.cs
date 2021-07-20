//using SRV.MockService;
using _17bangMVC.Models;
using SRV.SerciceInterface;
using SRV.ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17bangMVC.Controllers
{
	public class ArcticleController : Controller
	{
		protected IAtricleService articleService;
		public ArcticleController()
		{
			articleService = new SRV.ProdService.ArticleService();
			articleService = new SRV.MockService.ArticleService();
			//articleService = new ArticleService();
		}
		// GET: Arcticle
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Index(ArcticleModel model)
		{
			articleService.Publish(model, 1);
			return View();
		}
	}
}