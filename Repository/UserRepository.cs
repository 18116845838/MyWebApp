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
		public UserRepository()
		{
			context = new SqlDbContext<User>();
		}
		public User GetByName(string name)
		{
			return context.Entities.Where(e => e.Name == name)
				.SingleOrDefault();
		}
	}
}
