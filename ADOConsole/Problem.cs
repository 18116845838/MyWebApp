using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ADOConsole
{
	public enum ProblemStatus
	{
		[Description("已撤销")]
		cancelled,
		[Description("已酬谢")]
		Rewarded,
		[Description("协助中")]
		inprocess,
		[Description("待协助")]
		assist
	}
	class Problem
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime PublishTime { get; set; }
		public int ProblemStatusID { get; set; }

		public int Reward { get; set; }
		public ProblemStatus ProblemStrtus { get; set; }
	}
}
