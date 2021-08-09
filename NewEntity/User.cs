using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEntity
{
	public  class User :BaseEntity
	{
		public string Name { get; set; }
		public string InviterBy { get; set; }
		public string InviterByCode { get; set; }
		public string Password { get; set; }
		public string Icon { get; set; }
		public string Email { get; set; }
	}
}
