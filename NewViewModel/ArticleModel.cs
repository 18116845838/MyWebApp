using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewViewModel
{
	public class ArticleModel
	{
		public int id { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public UserModel Author { get; set; }
		public DateTime CreateTime { get; set; }
		public int commend { get; set; }
		public int notRecommend { get; set; }
		public List<CommentModel> Comments { get; set; }
	}
}
