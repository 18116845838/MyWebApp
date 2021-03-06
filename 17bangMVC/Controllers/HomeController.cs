using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17bangMVC.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
		public ActionResult _Navbar()
		{
			//	根据Ajax动态加载导航栏下的“新消息”
			//分别通过iframe和Ajax完成侧边栏关键字“换一批”的功能
			//能通过Json获得（有无未读消息的）数据，决定是否闪烁铃铛图标（注意：要能闪还能不闪）
			//发布求助时，能够

			//	根据一级关键字，通过Ajax获取到该一级关键字下的二级关键字，并予以显示
			//	定向求助时移出焦点，就能找到相关用户
			//	刷新帮帮币
			return PartialView("_Navbar");
		}
	}
}