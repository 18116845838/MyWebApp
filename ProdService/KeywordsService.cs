using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repository;
using Repositoy;
using ViewModel;

namespace SRV.ProdService
{
	public class KeywordsService : BaseService
	{
		public KeywordRepository keywordRepository;
		public KeywordsService()
		{
			keywordRepository = new KeywordRepository(context);
		}
		public IList<KeywordsModel> Get()
		{
			IList<Keywords> key = keywordRepository.GetRandom();
			IList<KeywordsModel> keywords = new List<KeywordsModel>();
			KeywordsModel model = new KeywordsModel();

			foreach (var item in key)
			{
				model = new KeywordsModel();
				model.Keyword= item.Keyword;
				keywords.Add(model);
			}
			return keywords;
		}
	}
}
