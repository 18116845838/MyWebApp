using System;
using System.Collections.Generic;
using System.Text;

namespace ADOConsole
{
	class Message
	{
		public int Id { get; set; }
		public string Content { get; set; }
		public bool IsRead { get; set; }

		public DateTime DateTime { get; set; }
	}
}
