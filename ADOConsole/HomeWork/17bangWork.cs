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
		#region 能够在EF core上配置成功Logger到Debug窗口
		public static void GetLogMessage()
		{
			DBSqlContext sqlContext = new DBSqlContext();

			User user = new User
			{
				Name = "张志民",
				Age = 21,
				Password = "123456",
				Enroll = DateTime.Now,
				IsFemale = true,
				CreateTime = DateTime.Now
			};
			sqlContext.Users.Add(user);
			sqlContext.SaveChanges();
		}
		#endregion



	}
}
