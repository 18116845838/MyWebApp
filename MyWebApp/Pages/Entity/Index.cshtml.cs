using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWebApp.Pages.Filter;
using E= MyWebApp.Pages.Article;

namespace MyWebApp.Pages.Entitiy
{
    [NeedLogOn]
    public class IndexModel : PageModel
    {
        public Repositories.Repositories repositories;
        public IList<E.Content> Articles { get; set; }
        public int Count { get; set; }
        public int PageSize = 2;
        public int PageIndex { get; set; }
        public IndexModel()
		{
            repositories = new Repositories.Repositories();
		}
        public void OnGet()
        {
			//PageIndex = Convert.ToInt32(Request.Query["pageIndex"][0]);
			Count = repositories.GetCount();
			Articles = repositories.Get(PageIndex, PageSize);

		}
    }
}
