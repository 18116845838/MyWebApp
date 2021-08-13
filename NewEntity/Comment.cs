using System;
using System.Collections.Generic;

namespace NewEntity
{
	public class Comment:BaseEntity
	{
		public User Author { get; set; }
		public string Content { get; set; }
		public DateTime CreateTime { get; set; }
		public int commend { get; set; }
		public int notRecommend { get; set; }
		public List<Comment> Comments { get; set; }

	}
}