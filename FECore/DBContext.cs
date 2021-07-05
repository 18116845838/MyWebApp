using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FECore
{
	class DBsqlContext :DbContext
	{
		public DbSet<Person> Persons { get; set; }
		public DbSet<Student>  Students { get; set; }
		public DbSet<Teacher>   Teachers { get; set; }
		public DbSet<Classroom>   Classrooms { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			string str = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = 20bang;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
			optionsBuilder.UseSqlServer(str)
				.EnableSensitiveDataLogging()
				.LogTo((id, level) => level == Microsoft.Extensions.Logging.LogLevel.Information, log => Console.WriteLine(log));
			optionsBuilder.UseLazyLoadingProxies();
			base.OnConfiguring(optionsBuilder);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>().HasBaseType((Type)null);
			modelBuilder.Entity<Teacher>().HasBaseType((Type)null);
			modelBuilder.Entity<Teacher>()
				.HasCheckConstraint("CK_Salary", "Salary>=0");
			modelBuilder.Entity<Student>().HasOne<Bad>(s => s.SleepIn)
				.WithOne(b => b.Owner)
				.HasForeignKey<Student>(s => s.SleepInId)
				.OnDelete(DeleteBehavior.Cascade);
			base.OnModelCreating(modelBuilder);
		}
	}
}
