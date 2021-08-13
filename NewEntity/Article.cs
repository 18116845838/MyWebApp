using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEntity
{
	public class Article : BaseEntity
	{
		public string Title { get; set; }
		public string Body { get; set; }
		public User Author { get; set; }
		public DateTime CreateTime { get; set; }
		public int commend { get; set; }
		public int notRecommend { get; set; }
		public List<Comment> Comments { get; set; } 
	}
}
