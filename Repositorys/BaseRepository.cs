using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class BaseRepository<T> where T : NewEntity.BaseEntity ,new()
    {
        protected SqlDbContext context;
        protected DbSet dbSet;
		public BaseRepository(SqlDbContext context)
		{
            this.context = context;
            dbSet = context.Set<T>();
		}
    }
}
