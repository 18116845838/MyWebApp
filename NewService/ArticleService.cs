using NewViewModel;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewService
{
	public class ArticleService : BaseService
	{
		public ArticleModel Get()
		{
			return mapper.Map<ArticleModel>(new ArticleRepository(context).Find(2));
		}
	}
}
