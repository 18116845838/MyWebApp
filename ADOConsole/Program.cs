using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using ADOConsole._17bangTableAdapters;
using Microsoft.EntityFrameworkCore;
using static ADOConsole._17bang;

namespace ADOConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			#region  使用EF的API直接建库建表删库
			//HomeWork._17bangWork.EFAPI();
			#endregion
			#region  使用Migration工具建库建表

			#endregion
			#region 能够在EF core上配置成功Logger到Debug窗口
			//能够在EF6上配置成功Logger到控制台
			//HomeWork._17bangWork.GetLogMessage();
			#endregion
			HomeWork._17bangWork.Update_User();

		}
	}

}
