
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositoy
{
	public class Repositorys<T> where T : Entities.Entity, new()
	{
		protected SqlDbContext context;
		protected DbSet<T> dbSet;
		public Repositorys(SqlDbContext context)
		{
			//context = new SqlDbContext();
			this.context = context;

			dbSet = context.Set<T>();

		}
		public int Save(T entity)
		{
			//context.Entities.Add(entity);
			dbSet.Add(entity);

			context.SaveChanges();
			return entity.Id;
		}
		/// <summary>
		/// 仅仅是用来临时使用，无法真正修改对象
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public T LoadProxy(int id)
		{
			T entity = new T { Id = id };
			dbSet.Attach(entity);
			return entity;
		}
		public T Find(int id)
		{
			return dbSet.Find(id);
		}
	}
}
