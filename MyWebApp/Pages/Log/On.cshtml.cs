using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWebApp.Pages.Article;
using MyWebApp.Pages.Entity;
using MyWebApp.Pages.Repositories;

namespace MyWebApp.Pages.Log
{
	[BindProperties]
	public class OnModel : PageModel
	{
		public User NewUser { get; set; }
		public UserRepositorie userRepositorie;
		public OnModel()
		{
			userRepositorie = new UserRepositorie();
		}

		public bool Rememberme { get; set; }
		public void OnGet()
		{
			Rememberme = true;
			ViewData["HasLogOn"] = Request.Cookies[Keys.UserId];
			TempData[Keys.UrlKey] = Request.Headers["referer"];
		}
		public IActionResult OnPost()
		{


			//�������������¼���͡�ע�ᡱ����ת����¼ / ע��ҳ�棻��ɵ�¼��ע��֮���ܷ���֮ǰҳ��
			//  ������������˳���¼����/ LogOff����
			// �����ǰҳ�治��Ҫ��¼��ֻˢ�²���ת��
			// ������ת����¼ҳ�桭��
			User user = userRepositorie.Get().Where(u => u.Name == NewUser.Name).SingleOrDefault();
			if (user == null)
			{
				ModelState.AddModelError("NewUser.Name", "* �û���������");
			}
			else
			{
				if (user.Password != NewUser.Password)
				{
					ModelState.AddModelError("NewUser.Password", "* �û��������������");
				}//else nothing
			}
			if (!ModelState.IsValid)
			{
				return RedirectToPage();
			}//else nothing
			CookieOptions cookie = new CookieOptions();
			if (Rememberme)
			{
				cookie.Expires = DateTime.Now.AddDays(14);
			}//else nothing

			Response.Cookies.Append(Keys.UserId, user.Id.ToString(), cookie);

			return Redirect(((string[])TempData[Keys.UrlKey])[0]);
			//return Page();
		}
	}
}
