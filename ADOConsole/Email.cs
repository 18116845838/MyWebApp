using System;
using System.Collections.Generic;
using System.Text;

namespace ADOConsole
{
	class Email
	{
		public int Id { get; set; }
		public string Content { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }
	}
}
