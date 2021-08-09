using NewEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class BaseRepository<T> where T : BaseEntity ,new()
    {
        protected SqlDbContext context;
        protected DbSet<T> dbSet;
		public BaseRepository(SqlDbContext context)
		{
            this.context = context;
            dbSet = this.context.Set<T>();
		}

		public int Save(T entity)
		{
			//context.Entities.Add(entity);
			dbSet.Add(entity);
			context.SaveChanges();
			return entity.Id;
		}
	}
}
