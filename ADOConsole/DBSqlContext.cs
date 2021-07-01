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
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().ToTable("Register")
				.Property(u=>u.Name).HasColumnName("UserName");
			modelBuilder.Entity<User>(u=> {
				u.Property(m => m.Password).IsRequired();
				u.HasKey(m => m.Name);
				u.Ignore(m => m.FailedTry);
				u.HasIndex(m => m.CreateTime);
				u.HasCheckConstraint("CK_CreateTime", "CreateTime>'2000-1-1'");
				}) ;
		}
	}
}
