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
			//User user = sqlContext.Find<User>(4);
			//sqlContext.Remove<User>(user);
			//不加载User对象，仅凭其Id用一句Update SQL语句完成上题
			User user = new User { Id = 3 };
			sqlContext.Attach<User>(user);
			user.Name = "大张";
			sqlContext.SaveChanges();
		}

		#endregion
		#region  利用Linq to EntityFramework，实现方法：

		//		GetBy(IList<ProblemStatus> exclude, bool hasSummary, bool descByPublishTime)，该方法可以根据输入参数：

		//    IList<ProblemStatus> exclude：不显示（排除）某些状态的求助
		//	bool hasReward：只显示已有总结的求助（如果传入值为true的话）
		//    bool descByPublishTime：按发布时间正序还是倒序

		//参考：求助列表（不显示/只显示）和文章列表（正序/倒序）

		//实现方法：GetMessage()，靠将消息列表：

		//    所有未读在已读前面
		//	未读和已读各自按生成时间排序
		/// <summary>
		/// 
		/// </summary>
		/// <param name="exclude">求助文章集合</param>
		/// <param name="hasSummary">只显示有总结数的集合</param>
		/// <param name="descByPublishTime">true正序，false倒序</param>
		public static void GetBy(IList<ProblemStatus> exclude, bool hasSummary, bool descByPublishTime)
		{ 

		}
		#endregion


	}
}
