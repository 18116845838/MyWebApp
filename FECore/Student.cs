using System;
using System.Collections.Generic;
using System.Text;

namespace FECore
{
	public class Student:Person
	{
		public string Major { get; set; }
		public double Score { get; set; }
		public int? SleepInId { get; set; }
		public virtual Bad SleepIn { get; set; }
		
		public virtual IList<Teacher> Teachers { get; set; }
	}
}
