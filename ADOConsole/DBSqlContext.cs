using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ADOConsole
{
	class DBSqlContext :DbContext
	{
		//public DbSet<student> Students { get;set; }
		protected override void OnConfiguring(DbContextOptionsBuilder dbContext )
		{ 
			string connectonStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=17bang;Integrated Security=True;";
			dbContext.UseSqlServer(connectonStr);
			base.OnConfiguring(dbContext);

		}
	}
}
