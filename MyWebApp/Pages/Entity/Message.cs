using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E= MyWebApp.Pages.Article;

namespace MyWebApp.Pages.Entity
{
	public class Message : E.Entity
	{
		public bool Selected { get; set; }
		public string Content { get; set; }
		public DateTime CreateTime { get; set; }
		public void IsRead()
		{ 
		}

	}
}
