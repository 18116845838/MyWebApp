//using SRV.MockService;
using _17bangMVC.Models;
using SRV.SerciceInterface;
using SRV.ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace _17bangMVC.Controllers
{
	public class ArcticleController : BaseController
	{
		protected IAtricleService atricleService;
		protected KeywordsService keywords;
		public ArcticleController(IAtricleService atricleService)
		{
			this.atricleService = atricleService;
			keywords = new KeywordsService();
			//articleService = new SRV.ProdService.ArticleService();
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
				ArcticleModel model = atricleService.GetEdit(id.Value);
				return View(model);
			}
			else
			{
				return View();
			}

		}
		[HttpPost]
		//配置缓存时常 ：秒
		[OutputCache(Duration = 30)]
		public ActionResult Index(int? id, ArcticleModel model)
		{
			/*			int? verigy = BaseService.GetCurrentUserId();
						if (verigy==null)
						{
							ModelState.AddModelError(nameof(model.Title), "未登录，无法发布文章");
							return View(model);
						}//else nothing*/
			if (id.HasValue)
			{
				atricleService.Edit(id.Value, model);
			}
			else
			{
				//			使用富文本编辑器发布文章，确保发布的文章能够显示：段落（< p >）、加粗（< strong >）、斜体（< i >）、链接（< a >）的效果

				//   在后台进行过滤，保证无法利用上述发布文章的功能进行脚本注入

				//   完成点赞和踩的功能：


				//文章显示赞 / 踩的总数

				//同一篇文章一个用户只能赞或踩一次

				//自己不能赞 / 踩自己的文章

				atricleService.Publish(model/*, Convert.ToInt32(verigy)*/);
				return View("Article", model);
			}

			//		将求助 / 文章 / 意见建议列表页进行output cache，注意：

			//   上述列表页面都有分页和过滤筛选参数
			//在缓存页上能即时的反映用户的登录情况

			//保证发布新的求助 / 文章 / 意见建议后跳转到列表首页，能看到新发布的内容

			return View();
		}
		public ActionResult Keywords(KeywordsService keywords)
		{

			return PartialView("Keywords");
		}
	}
}