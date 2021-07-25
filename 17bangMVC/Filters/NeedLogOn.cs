using SRV.SerciceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17bangMVC.Filters
{
	public class NeedLogOn:AuthorizeAttribute
	{
		public IUserService userService { get; set; }
		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			userService.GetById(1);
			base.OnAuthorization(filterContext);
		}
	}
}