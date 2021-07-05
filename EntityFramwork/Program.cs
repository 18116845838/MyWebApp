using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork
{
	class Program
	{
		static void Main(string[] args)
		{
			//ConsructDb();
			SqlDbContext dbContext = new SqlDbContext();
			//添加
			//User user = new User { Name = "飞哥", IsFemale = true, Password = "123456", CreateTime = DateTime.Now };
			//dbContext.Users.Add(user);
			//dbContext.SaveChanges();

			//删除
			//User user = dbContext.Users.Find(1);
			//dbContext.Users.Remove(user);


			//修改
			//User user = dbContext.Users.Find(1);
			//user.Name="大飞哥";


			dbContext.SaveChanges();
			Console.ReadKey();

		}
		static void ConsructDb()
		{
			SqlDbContext dbContext = new SqlDbContext();
			dbContext.Database.Delete();
			dbContext.Database.Create();
		}
	}
}
