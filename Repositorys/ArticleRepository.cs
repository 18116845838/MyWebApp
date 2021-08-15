using NewEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
	public class ArticleRepository :BaseRepository<Article>
	{
		public ArticleRepository(SqlDbContext context):base(context)
		{

		}
		public Article Find(int id)
		{

			IQueryable<Article> articles = dbSet.Where(c => c.Id == id)
				.Include(s => s.Author)
				.Include(c=>c.Comments.Select(s => s.Author))
				;
			List<Article> articles1 = articles.ToList();
			return articles.ToList().FirstOrDefault();
		}

	}
}
