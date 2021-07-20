using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace Repositoy
{
	public class UserRepository : Repositorys<User>
	{
		public UserRepository(SqlDbContext context) : base(context)
		{
			context = new SqlDbContext();
		}

		public User Find(int id)
		{
			return dbSet.Where(u => u.Id == id)
				.SingleOrDefault();
		}
		public User GetByName(string name)
		{
			return dbSet.Where(e => e.Name == name)
				.SingleOrDefault();
		}
	}
}
