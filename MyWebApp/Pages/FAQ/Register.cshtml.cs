using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWebApp.Pages.Article;
using MyWebApp.Pages.Entity;

using MyWebApp.Pages.Repositories;

namespace MyWebApp.Pages.FAQ
{
	[BindProperties]
	public class RegisterModel : PageModel
	{
		public User NewUser { get; set; }
		public UserRepositorie userRepositorie;
		//public IList<User> Users { get; set; }
		public RegisterModel()
		{
			userRepositorie = new UserRepositorie();
		}
		public string ConfirmPassword { get; set; }
		public void OnGet()
		{

			IDictionary<string, string> error = TempData[Keys.ErrorMessage] as Dictionary<string,string>;
			if (error!=null)
			{
				foreach (var item in error)
				{
					ModelState.AddModelError(item.Key, item.Value);
				}
			}//else nothing
	

		}
		public IActionResult OnPost()
		{
			if (ConfirmPassword != NewUser.Password)
			{
				ModelState.AddModelError(nameof(ConfirmPassword), "* 两次输入的密码不一致");
				TempData[Keys.ErrorMessage] = GetErrorMessage();
				
			}//else nothing

			User user = userRepositorie.Get().Where(u => u.Name == NewUser.InviterBy.Name).SingleOrDefault();

			if (user == null)
			{
				ModelState.AddModelError("NewUser.InviterBy.Name", "* 没有该邀请人");
				TempData[Keys.ErrorMessage] = GetErrorMessage();
			}
			else
			{
				if (user.InvitationCode != NewUser.InviterBy.InvitationCode)
				{
					ModelState.AddModelError("NewUser.Inviterby.InvitationCode", "* 邀请码错误");
					TempData[Keys.ErrorMessage] = GetErrorMessage();
				}//else nothing
			}
			if (!ModelState.IsValid)
			{
				return RedirectToPage();
			}//else nothing
			return Page();
		}
		public object GetErrorMessage()
		{
			return ModelState.Where(m => m.Value.Errors.Any())
				.ToDictionary(
				m => m.Key, m => m.Value.Errors
				   .Select(s => s.ErrorMessage)
				   .FirstOrDefault(s => s != null)
				);
		}
	}
}
