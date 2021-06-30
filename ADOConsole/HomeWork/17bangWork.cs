using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADOConsole.HomeWork
{
	class _17bangWork
	{
		//    使用EF的API直接建库建表删库
		public static void EFAPI() 
		{
			DBSqlContext dBSql = new DBSqlContext();
			var db = dBSql.Database;
			//建表
			//db.EnsureCreated();
			//删表
			//db.EnsureDeleted();
			db.Migrate();
		}


	}
}
