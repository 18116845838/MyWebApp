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
			var db = dBSqlContext.Database;
			//db.EnsureDeleted();
			//db.EnsureCreated();
			#region 帮帮币交易
			//Bmoney.BmoneyDeal(3, 4, 100);
			#endregion

			#region  完成以下entity的创建和ORM映射：

			//		关键字
			//		文章分类

			//	帮帮点/帮帮币


			//以及相应的增删改查功能：


			//	发布文章和求助时包含关键字（keyword）

			//Content content = new Problem
			//{
			//	CreateTime = DateTime.Now,
			//	PublishTime = DateTime.Now,
			//	Keywords=new List<Keyword> { new Keyword { name="C#"},new Keyword { name="sql"} }

			//};
			//dBSqlContext.Add(content);
			//dBSqlContext.SaveChanges();
			//    可以按关键字筛选求助
			//IList<Keyword> keywords = dBSqlContext.Keywords
			//	.Where(k => k.name == "C#")
			//	.Include(c=>c.Contents)
			//	.ToList()
			//	;
			//foreach (var item in keywords)
			//{
			//	Console.WriteLine(item.Id);
			//	foreach (var content in item.Contents)
			//	{
			//		Console.WriteLine(content.Title);
			//	}
			//}

			//	能够按作者（Author）/分类（Category）显示文章列表
			//List<Content> contents = dBSqlContext.Contents.Where(c => c.User.Id == 1).ToList();
			//List<Content> contents = dBSqlContext.Contents.Where(c => c is Problem).ToList();






			#endregion

		}
		static IList<Content> OrderBy(bool order = true)
		{
			DBSqlContext sqlContext = new DBSqlContext();
			//	能够选择文章列表的排序方向（按发布时间顺序倒序）和每页显示格式（50篇标题/10篇标题+摘要）
			if (order)
			{
				return sqlContext.Contents.OrderBy(c => c.CreateTime).ToList();
			}
			else
			{
				return sqlContext.Contents.OrderByDescending(c => c.CreateTime).ToList();
			}
		}

		//	发布求助时可以设置悬赏帮帮币，发布后会被冻结，求助被解决时会划拨给好心人
		//static void Publish()
		//{

		//}
		//    发布文章会：扣掉作者1枚帮帮币、增加10个帮帮点

		//	帮帮点和帮帮币的每一次变更都会被记录并可以显示
		static void Record()
		{
			DBSqlContext sqlContext = new DBSqlContext();
			User user = sqlContext.Users.Find(1);
			if (sqlContext.Entry(user).State == EntityState.Modified)
			{
				Bmoney bmoney = new Bmoney
				{
					DealTime = DateTime.Now,
					User = user,
					Surplus=user.Wallet,
				};
				sqlContext.Add(bmoney);
				sqlContext.SaveChanges();
			}//else nothing

		}
	}
}
