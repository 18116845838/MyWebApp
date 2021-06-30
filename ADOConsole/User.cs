using System;
using System.Collections.Generic;
using System.Text;

namespace ADOConsole
{
	class User
	{
		#region MyRegion
		//		将User类映射到数据库：
		//    使用EF的API直接建库建表删库
		//	使用Migration工具建库建表
		//Migration之后，在User类上添加一列：int FailedTry（尝试登陆失败次数），使用Migration工具：
		//    将改动同步到数据库
		//	回退数据库到FailedTry添加之前
		#endregion

		public int Id { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public DateTime Enroll { get; set; }
		public bool IsFemale { get; set; }

	}
}
