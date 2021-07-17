using _17bangMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17bangMVC.Controllers
{
	public class PlanNewController : Controller
	{
		// GET: PlanNew

		public ActionResult Index()
		{
			PlanNewModel plan = new PlanNewModel
			{
				DaysInWeek = new Dictionary<string, bool>
				{
					{ "一",true},
					{ "二",true},
					{ "三",true},
					{ "四",true},
					{ "五",true},
					{ "六",true},
					{ "七",true}
				},
				DaysOfLeaveOptions = new Dictionary<int, int>
				{
					{1,1 },
					{2,2 },
					{3,3 },
					{4,4 },
					{5,5 },
					{6,6 },
					{7,7 },
				}
			};
			return View(plan);
		}
	}
}