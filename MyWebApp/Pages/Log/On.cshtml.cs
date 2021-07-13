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
        }
        public void OnPost()
        {

			User user = userRepositorie.Get().Where(u => u.Name == NewUser.Name).SingleOrDefault();
			if (user == null)
			{
				ModelState.AddModelError("NewUser.Name", "* 用户名不存在");
			}
			else
			{
				if (user.Password != NewUser.Password)
				{
					ModelState.AddModelError("NewUser.Password", "* 用户名或者密码错误");
				}//else nothing
			}
			if (!ModelState.IsValid)
			{
				return;
			}//else nothing
			CookieOptions cookie = new CookieOptions();
			if (Rememberme)
			{
				cookie.Expires = DateTime.Now.AddDays(14);
			}//else nothing

			Response.Cookies.Append(Keys.UserId,user.Id.ToString(),cookie);
        }
    }
}
