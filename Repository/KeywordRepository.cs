using Entities;
using Repositoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public  class KeywordRepository : Repositorys<Keywords>
	{
		public KeywordRepository(SqlDbContext context) : base(context)
		{

		}

		public List<Keywords> Get()
		{
			return dbSet.SqlQuery("SELECT * FROM KEYWORDS").ToList();
		}
	}
}
