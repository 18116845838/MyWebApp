using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWebApp.Pages.Filter;

namespace MyWebApp.Pages.FAQ
{
    [NeedLogOn]
    public class WelcomeModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
