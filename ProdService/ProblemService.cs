using AutoMapper;
using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace SRV.ProdService
{
	public class ProblemService : BaseService
	{
		private ProblemRepository problemRepository;
		public ProblemService()
		{
			problemRepository = new ProblemRepository(context);
		}
		public int Publish(ProblemModel model)
		{
			Problem problem = mapper.Map<Problem>(model);

			return 1;
		}

		public IList<ProblemModel> Get()
		{

			List<Content> problems = problemRepository.Get();


			return mapper.Map<List<ProblemModel>>(problems);
		}
	}
}
