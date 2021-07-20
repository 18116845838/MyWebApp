using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositoy
{
	public class ArcticleRepository :Repositorys<Arcticle>
	{
		public ArcticleRepository()
		{
			context = new SqlDbContext<Arcticle>();
		}
		//public 
	}
}
