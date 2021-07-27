using _17bangMVC.Models;
using Global;
using SRV.ProdService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace _17bangMVC.Controllers
{
	public class WriteController : Controller
	{
		// GET: Write
		public ActionResult Index()
		{
			if (Request.Cookies[Keys.User]==null)
			{
				return RedirectToAction("index","Register");
			}
			return View();
		}
		[HttpPost]
		public ActionResult Index(RegisterModel model, HttpPostedFileBase icon)
		{
			if (icon != null)
			{
				if (icon.ContentLength >= 1080 * 400)
				{
					return View();
				}
				if (icon.ContentType == "image/x-icon" || icon.ContentType == "Image/ico")
				{
					DateTime date = DateTime.Now;
					string urlPath = $"UploadFiles\\{date.Year}\\{date.Month}\\{date.Day}";
					Directory.CreateDirectory(Server.MapPath(urlPath));

					Guid guid = Guid.NewGuid();

					//文件后缀名
					string extension = Path.GetExtension(icon.FileName);
					//文件Url路径
					string urlName = $"{urlPath}\\{guid}{extension}";
					//
					//string test = Path.Combine(urlPath, guid.ToString(), extension);
					model.Icon = urlName;
					
					icon.SaveAs(Server.MapPath(urlName));

					new UserService().Edit(Convert.ToInt32(Request.Cookies[Keys.User].Values["Id"].ToString()), model);
				}
				else
				{
					return View();
				}

			}//else nothiing


			return View(model);
		}
	}
}