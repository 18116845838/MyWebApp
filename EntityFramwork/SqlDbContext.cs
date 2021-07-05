using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork
{
	class SqlDbContext : DbContext
	{

		public SqlDbContext() : base("19bang")
		{
			Database.Log = Console.WriteLine;
		}
		public DbSet<User> Users { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<User>().Map(
			//	m =>

			//	{
			//		m.ToTable("Register");
			//	}
			//	);
			modelBuilder.Entity<User>().Property(m => m.Name).HasColumnName("UserName");
			modelBuilder.Entity<User>().Property(m => m.Name).HasMaxLength(256);
			modelBuilder.Entity<User>().Property(m => m.Password).IsRequired();
			//modelBuilder.Entity<User>().HasKey(m => m.Name);
			modelBuilder.Entity<User>().Ignore(m => m.FailedTry);
			modelBuilder.Entity<User>().HasIndex(m => m.CreateTime);
			//modelBuilder.Entity<User>().Property(m=>m.CreateTime).c;
			//base.OnModelCreating(modelBuilder);
		}
	}
}
