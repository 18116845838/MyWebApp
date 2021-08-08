using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class Content
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }

		public DateTime PublishTime { get; set; }
		public User Author { get; set; }
		public IList<Keyword> Keywords { get; set; }

	}
}
