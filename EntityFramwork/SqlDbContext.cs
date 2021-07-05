using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork
{
	class SqlDbContext:DbContext
	{
		
		public SqlDbContext():base("19bang")
		{
			Database.Log = Console.WriteLine;
		}
		public DbSet<User> Users { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder);
		}
	}
}
