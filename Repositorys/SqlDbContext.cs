using NewEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
	public  class SqlDbContext :DbContext
	{
		public SqlDbContext() :base("New_17bang")
		{
			Database.Log = s => Debug.WriteLine(s);
		}
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>();

			base.OnModelCreating(modelBuilder);
		}
	}
}
