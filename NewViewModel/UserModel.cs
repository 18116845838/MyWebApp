using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewViewModel
{
    public class UserModel
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string InviterBy { get; set; }
		public string InviterByCode { get; set; }
		public string Password { get; set; }
		public string Icon { get; set; }
		public string Email { get; set; }
	}
}
