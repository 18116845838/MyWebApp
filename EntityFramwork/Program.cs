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
