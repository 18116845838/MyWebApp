using System;
using System.Collections.Generic;
using System.Text;

namespace ADOConsole._17bangren
{
	class Content
	{
		public int Id { get; set; }
		public User User { get; set; }
		public DateTime CreateTime { get; set; }
		public DateTime PublishTime { get; set; }

		public string Title { get; set; }

		public string Body { get; set; }
	}
}
