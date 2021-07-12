using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E = MyWebApp.Pages.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWebApp.Pages.Repositories;

namespace MyWebApp.Pages.Message
{
    [BindProperties]
    public class MineModel : PageModel
    {
        public IList<E.Message> Messages { get; set; }
        public MassageRepositorie massageRepositorie;
		public MineModel()
		{
            massageRepositorie = new MassageRepositorie();
        }
        public void OnGet()
        {
            Messages = massageRepositorie.Get();
        }
        public void OnPost()
        {
			foreach (var item in Messages)
			{
				if (item.Selected)
				{
                    massageRepositorie.Get()
                        .Where(m => m.Id == item.Id)
                        .SingleOrDefault().IsRead();
				}//else nothing 
			}
            //Messages = massageRepositorie.Get();
            //massageRepositorie.Dalete(3);
        }
    }
}
