using _17bangMVC.Models;
using SRV.ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace _17bangMVC.Controllers
{
	public class ProblemController : Controller
	{
		// GET: Problem
		private ProblemService problemService;
		public ProblemController()
		{
			problemService = new ProblemService();
		}
		public IList<ProblemModel> problemModels { get; set; }
		public ActionResult Index(int? id)
		{
			//if (id!=null)
			//{

			// return View();
			//}
			problemModels = problemService.Get();
			return View();
		}
		[HttpPost]
		public ActionResult Index()
		{
			problemModels = problemService.Get();
			return View();
		}
	}
}