using _17bangMVC.Models;
using Entities;
using Repositoy;
using SRV.SerciceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ProdService
{
    public class ArticleService : IAtricleService
	{

		private ArcticleRepository arcticleRepository;
		private UserRepository userRepository;
		public ArticleService()
		{
			SqlDbContext context = new SqlDbContext();
			arcticleRepository = new ArcticleRepository(context);
			userRepository = new UserRepository(context);
		}
		public void Publish(ArcticleModel model,int currentUserId)
        {


			Arcticle arcticle = new Arcticle
			{
				Title = model.Title,
				Body = model.Body
			};

			//可以但没必要
			//User user = userRepository.Find(1);
			User user = userRepository.LoadProxy(1);

			arcticle.Author = user;
			arcticleRepository.Save(arcticle);
		}
    }
}
