using _17bangMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17bangMVC.Controllers
{
    public class ProblemController : Controller
    {
        // GET: Problem
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ArcticleModel model)
        {
            return View();
        }
    }
}