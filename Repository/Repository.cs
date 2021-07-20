
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositoy
{
    public class Repositorys<T> where T : Entities.Entity
    {
        protected SqlDbContext<T> context;
		public Repositorys()
		{

			context = new SqlDbContext<T>();
		}
        public int Save(T entity)
        {
            context.Entities.Add(entity);

			context.SaveChanges();
            return entity.Id;
        }
    }
}
