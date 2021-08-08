using _17bangMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
	public  class ProblemModel
	{
		public int Answer { get; set; }
		public int Summary { get; set; }
		public int Reward { get; set; }
		public int Id { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }

		public DateTime PublishTime { get; set; }
		public UserModel Author { get; set; }
		public IList<KeywordsModel> Keywords { get; set; }
	}
}
