using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using ADOConsole._17bangren;
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
			//HomeWork._17bangWork.Update_User();
			#region 调用GetMessage()，靠将消息列表：
			//    所有未读在已读前面
			//	未读和已读各自按生成时间排序
			//HomeWork._17bangWork.GetMessage();
			#endregion
			DBSqlContext dBSqlContext = new DBSqlContext();
			var db =  dBSqlContext.Database;
			//db.EnsureDeleted();
			//db.EnsureCreated();
			#region 帮帮币交易
			Bmoney.BmoneyDeal(3, 4, 100);
			#endregion
		}
	}

}
