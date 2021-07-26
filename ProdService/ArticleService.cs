using _17bangMVC.Models;
using AutoMapper;
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
    public class ArticleService :BaseService, IAtricleService
	{

		private ArcticleRepository arcticleRepository;
		private UserRepository userRepository;
		public ArticleService()
		{
			//SqlDbContext context = new SqlDbContext();
			arcticleRepository = new ArcticleRepository(context);
			userRepository = new UserRepository(context);

		}

		public void Edit(int id, ArcticleModel model)
		{
			Article arcticle = arcticleRepository.Find(id);
			//用传入的参数修改数据库中的参数
			mapper.Map<ArcticleModel, Article>(model, arcticle);
			
		}

		public ArcticleModel GetById(int id)
		{
			Article arcticle = arcticleRepository.Find(id);
			
			ArcticleModel model =	mapper.Map<ArcticleModel>(arcticle);
			return model;
		}

		public ArcticleModel GetEdit(int id)
		{
			Article arcticle = arcticleRepository.Find(id);
			return mapper.Map<ArcticleModel>(arcticle);
		}

		public void Publish(ArcticleModel model/*,int currentUserId*/)
        {

			if (GetCurrentUser()==null)
			{
				throw new ArgumentException("用户未登录");
			}//else nothing
			Article arcticle = new Article
			{
				Title = model.Title,
				Body = model.Body,
				Author=GetCurrentUser()
			   
			};

			//可以但没必要
			//User user = userRepository.Find(currentUserId);
			//User user = userRepository.LoadProxy(1);
			//arcticle.Author = user;
			arcticleRepository.Save(arcticle);
		}
    }
}
