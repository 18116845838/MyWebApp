using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repository;
using Repositoy;

namespace SRV.ProdService
{
	public class KeywordsService:BaseService
	{
		public KeywordRepository keywordRepository;
		public KeywordsService()
		{
			keywordRepository = new KeywordRepository(context);
		}
		public IList<Keywords> Get()
		{
			return keywordRepository.Get();
		}
	}
}
