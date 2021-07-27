using Global;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17bangMVC.Controllers
{
	public class SharedController : Controller
	{
		// GET: Shared

		public string Captchastring { get; set; }

		public ActionResult _GetCaptcha()
		{
			//string Captchastring = Global.GetCaptcha.GetCaptchastring();
			MemoryStream stream = new MemoryStream();
			Global.GetCaptcha.BitmapTast( out string session).Save(stream,ImageFormat.Jpeg);
			stream.Seek(0, SeekOrigin.Begin);
			Session.Add(Keys.Captcha, session);
			return File(stream,"Image/jpg");
		}

	}
}