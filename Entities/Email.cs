using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class Email : Entity
	{
		//[index(unique=true)]
		public string EMail { get; set; }
		public string Code { get; set; }
		public bool HasValid { get; set; }
		public User User { get; set; }
		public int UserId { get; set; }

	}
}
