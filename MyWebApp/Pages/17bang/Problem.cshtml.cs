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
    public class ProblemModel : PageModel
    {
        public Repositories.Repositories repositories;
        public IList<Content> Contents { get; set; }
        public int Count { get; set; }
        public int PageSize = 2;
        public int PageIndex { get; set; }
		public ProblemModel()
		{
            repositories = new Repositories.Repositories();
        }
        public void OnGet()
        {
            PageIndex = Convert.ToInt32(Request.Query["pageIndex"][0]);
            Count = repositories.GetCount();
            Contents = repositories.Get(PageIndex, PageSize);
            //测试修改标题，内容
            repositories.Alter(2, "SQL语句，相关子查询");
        }
    }
}
