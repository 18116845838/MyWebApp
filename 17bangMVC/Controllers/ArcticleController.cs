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
	public class ArcticleController : BaseController
	{
		protected IAtricleService articleService;
		public ArcticleController()
		{
			articleService = new SRV.ProdService.ArticleService();
			//articleService = new SRV.MockService.ArticleService();
			//articleService = new ArticleService();
		}
		// GET: Arcticle
		//public ActionResult Index()
		//{
		//	return View();
		//}
		public ActionResult Index(int? id)
		{
			if (id.HasValue)
			{
				ArcticleModel model = articleService.GetEdit(id.Value);
				return View(model);
			}
			else
			{
				return View();
			}

		}
		[HttpPost]
		public ActionResult Index(int? id,ArcticleModel model)
		{
			/*			int? verigy = BaseService.GetCurrentUserId();
						if (verigy==null)
						{
							ModelState.AddModelError(nameof(model.Title), "未登录，无法发布文章");
							return View(model);
						}//else nothing*/
			if (id.HasValue)
			{
				articleService.Edit(id.Value,model);
			}
			else
			{
				articleService.Publish(model/*, Convert.ToInt32(verigy)*/);
			}
			return View();
		}
	}
}