using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public  class Problem :Content
	{
		public int Answer { get; set; }
		public int Summary { get; set; }
		public int Reward { get; set; }

	}
}
