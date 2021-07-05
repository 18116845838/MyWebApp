using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FECore
{
	class Program
	{
		static void Main(string[] args)
		{
			DBsqlContext dBsqlContext = new DBsqlContext();

			//Student student = dBsqlContext.Students.Include(s => s.SleepIn).Where(s =>  s.Id == 3 ).Single();
			//dBsqlContext.Teachers.Include(t => t.Students).Where(t => t.Id == 1).Single();
			//Student student = dBsqlContext.Students.Where(s => s.Name == "zhouli").SingleOrDefault();
			//var s = dBsqlContext.Entry(student);
			//s.Collection(f => f.Teachers).Load();

			//Bad bad = dBsqlContext.Find<Bad>(2);
			//dBsqlContext.Entry(bad).Reference(b => b.Owner).Load();
			//dBsqlContext.Remove(bad);


			//开启事务
			using (IDbContextTransaction dbContext =dBsqlContext.Database.BeginTransaction())
			{
				try
				{
					Student student = dBsqlContext.Students.Where(s => s.Name == "lizhibo").SingleOrDefault();

					student.Name = "tiantian";
					dBsqlContext.SaveChanges();
					Teacher teacher = dBsqlContext.Teachers.Where(t => t.Id == 1).SingleOrDefault();
					//teacher.Salary = -100;
					dBsqlContext.SaveChanges();
					dbContext.Commit();
				}
				catch (Exception)
				{
					dbContext.Rollback();
					throw;
				}

			}


			//teacher.Students.Clear();


			//解决一加N的问题
			//foreach (var item in dBsqlContext.Classrooms.Include(c=>c.Students).ToList())
			//{
			//	Console.WriteLine(item.Name);
			//	foreach (var c in item.Students)
			//	{
			//		Console.WriteLine(c.Name);
			//	}
			//}

			//一加N的问题造成性能浪费
			//foreach (var item in dBsqlContext.Classrooms.ToList())
			//{
			//	Console.WriteLine(item.Name);
			//	foreach (var student in item.Students)
			//	{
			//		Console.WriteLine(student.Name);
			//	}
			//}

			//数据准备
			//var db = dBsqlContext.Database;
			//db.EnsureDeleted();
			//db.EnsureCreated();


			//Student lzb = new Student { Name = "lizhibo" };
			//Student lw = new Student { Name = "liwi" };
			//Student zl = new Student { Name = "zhouli" };
			//Student zdh = new Student { Name = "zhoudinghao" };

			//Classroom sql = new Classroom { Name = "sql" };
			//Classroom Csharp = new Classroom { Name = "Csharp" };

			//Csharp.Students = new List<Student> { lzb, zl };
			//sql.Students = new List<Student> { zl, lw, zdh };

			//Teacher fg = new Teacher { Name = "fg" };
			//Teacher xy = new Teacher { Name = "xiaoyu" };

			//fg.Students = new List<Student> { lzb, zdh, zl };
			//xy.Students = new List<Student> { zl, lw };

			//Bad bad = new Bad { Location = "闭包间" };
			//Bad bad2 = new Bad { Location = "抽象工厂" };
			//zl.SleepIn = bad;
			//lw.SleepIn = bad2;
			//dBsqlContext.AddRange(fg, xy);
			//dBsqlContext.AddRange(sql, Csharp);
			////dBsqlContext.AddRange(bad, bad2);


			//dBsqlContext.SaveChanges();

		}
	}
}
