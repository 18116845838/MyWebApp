using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebApp.Pages.Article;

namespace MyWebApp.Pages.Profile
{
    public class WriteModel : PageModel
    {
        public User NewUser { get; set; }

        public string Year { get; set; }
        public IEnumerable<SelectListItem> YearSelectLists { get; set; }    
        public string Month { get; set; }
        public IEnumerable<SelectListItem> MonthSelectLists { get; set; }    
        public string Constellation { get; set; }
        public IEnumerable<SelectListItem> ConstellationSelectLists { get; set; }
        public void OnGet()
        {
            YearSelectLists= new List<SelectListItem> 
            { 
                new SelectListItem("2009","2009"),
                new SelectListItem("2008","2008"),
                new SelectListItem("2007","2007"),  
            };
            MonthSelectLists = new List<SelectListItem>
            {
                new SelectListItem{ Text="1",Value="1"},
                new SelectListItem{ Text="2",Value="2"},
                new SelectListItem{ Text="3",Value="3"},
                new SelectListItem{ Text="4",Value="4"},
                new SelectListItem{ Text="5",Value="5" ,Selected=true},
            };
            ConstellationSelectLists = new List<SelectListItem>
            {
                new SelectListItem("½ðÅ£×ù","4"),
                new SelectListItem("Ë«×Ó×ù","5"),
                new SelectListItem("Ë®Æ¿×ù","6"),
                new SelectListItem("--","--",true),
            };
        }
    }
}
