using _17bangMVC.Filters;
using System.Web;
using System.Web.Mvc;

namespace _17bangMVC
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
			//自定义Filter全局注册
			filters.Add(new ContextPerRequest());
		}
	}
}
