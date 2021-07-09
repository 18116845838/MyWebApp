using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Pages.Article
{
	public class Content : Entity
	{
		public string Title { get; set; }
		public string Body { get; set; }
		public int Answer { get; set; }
		public int Summary { get; set; }
		public int Reward { get; set; }
		public DateTime PublishTime { get; set; }
		public User Author { get; set; }
		public IList<Keyword> Keywords { get; set; }
	}
}
