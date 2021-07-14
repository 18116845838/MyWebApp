using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWebApp.Pages.Article;
using MyWebApp.Pages.Filter;

namespace MyWebApp.Pages._17bang
{
    [NeedLogOn]
    public class ContactModel : PageModel
    {
        public User NewUser { get; set; }
        public void OnGet()
        {
        }
    }
}
