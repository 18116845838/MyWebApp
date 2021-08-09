using Entities;
using Repositoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class ProblemRepository : Repositorys<Problem>
	{

		public ProblemRepository(SqlDbContext context) : base(context)
		{
			//context = new SqlDbContext();
		}

		public List<Content> Get()
		{
			//return dbSet.SqlQuery("SELECT * FROM Contents").OrderByDescending(p => p.PublishTime)
			var contents= context.Contents.Include("Author")/*.Include("Keywords")*/
			   .ToList();
			return contents;


			//return context.Set<Content>().Where(m=>m.CreateTime>DateTime.Now.AddDays(-19));
		}
	}
}
