using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace Repositoy
{
	//public class SqlDbContext<T> : SqlDbContext where T : Entity
	//{

	//	public DbSet<T> Entities { get; set; }

	//}
	public class SqlDbContext : DbContext
	{
		public SqlDbContext() : base("17bang")
		{
			Database.Log = s => Debug.WriteLine(s);
		}
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>();
			modelBuilder.Entity<Arcticle>();
			base.OnModelCreating(modelBuilder);
		}
	}
}
