using _17bangMVC.Models;
using Entities;
using Repositoy;
using SRV.SerciceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace SRV.ProdService
{
	public  class UserService :BaseService,IUserService
	{

		public UserModel GetByName(string name)
		{
			throw new NotImplementedException();
		}

		public string GetById(int Id)
		{
			throw new NotImplementedException();
		}

		public int? Register(RegisterModel model)
		{

			User user = new UserRepository(context).GetByName(model.Name);

			if (user!=null)
			{
				return null;
			}//else nothing
			user = new User
			{
				Name = model.Name,
				Password = model.Password
			};

			new Repositorys<User>(context).Save(user);
			return user.Id;
			//throw new NotImplementedException();
		}

		public string GetPwdById(int currentUserId)
		{

			return new UserRepository(context).Find(currentUserId).Password;
		}
	}
}
