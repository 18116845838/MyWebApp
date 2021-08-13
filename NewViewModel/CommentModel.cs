using System;
using System.Collections.Generic;

namespace NewViewModel
{
	public class CommentModel
	{
		public int Id { get; set; }
		public UserModel Author { get; set; }
		public string Content { get; set; }
		public DateTime CreateTime { get; set; }
		public int commend { get; set; }
		public int notRecommend { get; set; }
		public List<CommentModel> Comments { get; set; }
	}
}