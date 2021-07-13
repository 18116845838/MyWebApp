using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWebApp.Pages.Article;
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
             userRepositorie=new UserRepositorie();
		}
        public string ConfirmPassword { get; set; }
        public void OnGet()
        {

        }
        public void OnPost()
        {
            if (ConfirmPassword != NewUser.Password)
            {
                ModelState.AddModelError(nameof(ConfirmPassword), "* ������������벻һ��");
            }//else nothing

            User user = userRepositorie.Get().Where(u => u.Name == NewUser.InviterBy.Name).SingleOrDefault();

            if (user == null)
			{
                ModelState.AddModelError("NewUser.InviterBy.Name","* û�и�������");
			}
			else
			{
				if (user.InvitationCode!=NewUser.InviterBy.InvitationCode)
				{
                    ModelState.AddModelError("NewUser.Inviterby.InvitationCode","* ���������");
				}//else nothing
			}
            if (!ModelState.IsValid)
			{
                return;
			}//else nothing

        }
    }
}
