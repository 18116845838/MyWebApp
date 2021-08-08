using Entities;
using Repositoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public  class KeywordRepository : Repositorys<Keyword>
	{
		public KeywordRepository(SqlDbContext context) : base(context)
		{

		}

		public List<Keyword> GetRandom()
		{
			Random random = new Random();
			List<Keyword> keywords = dbSet.SqlQuery("SELECT * FROM KEYWORDS ").ToList();
			return keywords.Skip(random.Next(keywords.Count)).Take(20).ToList();
		}
	}
}
