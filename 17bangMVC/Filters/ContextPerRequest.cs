using Global;
using SRV.ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17bangMVC.Filters
{
	public class ContextPerRequest : IActionFilter/*,IResultFilter*/
	{
		public void OnActionExecuted(ActionExecutedContext filterContext)

		{

			//if (filterContext.IsChildAction)
			if (filterContext.Exception == null)
			{
				BaseService.Commit();
			}
			else
			{
				BaseService.Rollback();
			}
		}

		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (filterContext.HttpContext.Request.HttpMethod== "POST"&&filterContext.HttpContext.Request.Path=="Register")
			{
				
				ViewDataDictionary viewdate = filterContext.Controller.ViewData;
				object session = filterContext.HttpContext.Session[Keys.Captcha];
				if (session!=null)
				{
					if (filterContext.HttpContext.Request.Form["Captchastring"].ToUpper() != session.ToString().ToUpper())
					{
						filterContext.HttpContext.Session.Clear();
						viewdate.ModelState.AddModelError("Captchastring", "验证码已过期");
					}//else nothing
				}//else nothing
			}
		}
	}
}