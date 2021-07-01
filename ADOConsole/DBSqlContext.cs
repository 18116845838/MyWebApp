using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace ADOConsole
{
	class DBSqlContext :DbContext
	{
		public DbSet<User> Users { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder dbContext )
		{
			string connectonStr = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = 17bang; Integrated Security = True; ";
			dbContext.UseSqlServer(connectonStr);
			base.OnConfiguring(dbContext);

		}

	}
}
