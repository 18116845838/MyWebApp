using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _17bangMVC.Models
{
	public class PlanNewModel
	{
		public int Id { get; set; }

		public string Name { get; set; }
		public string Password { get; set; }
		public string Specify { get; set; }
		public DateTime BeginTime { get; set; }
		public DateTime EndTime { get; set; }
		public IDictionary<string, bool> DaysInWeek { get; set; }
		public int? DaysOfLeave { get; set; }
		public IDictionary<int, int> DaysOfLeaveOptions { get; set; }
	}
}