using ADOConsole._17bangren;
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
	class Problem :Content
	{
		public string List { get; set; }
		public string Question { get;set; }

		public int Reward { get; set; }
		public ProblemStatus ProblemStrtus { get; set; }
	}
}
