using NewEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
	public class UserRepository :BaseRepository<User>
	{
		public UserRepository(SqlDbContext context):base(context)
		{
			
		}
	}
}
