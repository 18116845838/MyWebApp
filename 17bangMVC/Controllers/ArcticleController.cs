
using _17bangMVC.Models;
using Entities;
using Repositoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17bangMVC.Controllers
{
	public class ArcticleController : Controller
	{
		private ArcticleRepository arcticleRepository;
		private UserRepository userRepository;
		public ArcticleController()
		{
			SqlDbContext context = new SqlDbContext();
			arcticleRepository = new ArcticleRepository(context);
			userRepository = new UserRepository(context);
		}
		// GET: Arcticle
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Index(ArcticleModel model)
		{
			Arcticle arcticle = new Arcticle
			{
				Title = model.Title,
				Body = model.Body
			};

			//可以但没必要
			//User user = userRepository.Find(1);
			User user = userRepository.LoadProxy(1);

			arcticle.Author = user;
			arcticleRepository.Save(arcticle);
			return View();
		}
	}
}