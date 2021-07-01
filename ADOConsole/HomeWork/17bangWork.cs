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
		#region 利用EF，插入3个User对象
		//通过主键找到其中一个User对象
		//修改该User对象的Name属性，将其同步到数据库
		//不加载User对象，仅凭其Id用一句Update SQL语句完成上题
		//删除该用户
		public static void Update_User()
		{
			DBSqlContext sqlContext = new DBSqlContext();
			//User user = new User
			//{
			//	Name = "飞哥",
			//	Age = 21,
			//	Password = "123456",
			//	Enroll = DateTime.Now,
			//	IsFemale = true,
			//	CreateTime = DateTime.Now
			//};
			//User user1 = new User
			//{
			//	Name = "小鱼",
			//	Age = 21,
			//	Password = "123456",
			//	Enroll = DateTime.Now,
			//	IsFemale = true,
			//	CreateTime = DateTime.Now
			//};	
			//User user2 = new User
			//{
			//	Name = "大鱼",
			//	Age = 21,
			//	Password = "123456",
			//	Enroll = DateTime.Now,
			//	IsFemale = true,
			//	CreateTime = DateTime.Now
			//};
			//sqlContext.Add(user);
			//sqlContext.Add(user1);
			//sqlContext.Add(user2);

			//sqlContext.Find<User>(4).Name= "小张";
			User user = sqlContext.Find<User>(4);
			sqlContext.Remove<User>(user);
			sqlContext.SaveChanges();
		}

		#endregion



	}
}
