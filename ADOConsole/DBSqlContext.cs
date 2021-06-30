using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace ADOConsole
{
	class DBSqlContext :DbContext
	{
		//public DbSet<student> Students { get;set; }
		protected override void OnConfiguring(DbContextOptionsBuilder dbContext )
		{ 
			string connectonStr = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = 17bang; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
			dbContext.UseSqlServer(connectonStr);
			base.OnConfiguring(dbContext);

		}
	}
}
