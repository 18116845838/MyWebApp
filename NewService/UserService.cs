
using NewEntity;
using NewViewModel;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewService
{
	public class UserService : BaseService
	{
		private UserRepository userRepository;
		public UserService()
		{
			userRepository = new UserRepository(context);
		}
		public int? Register(UserModel model)
		{
			User user = userRepository.GetByName(model.Name);

			if (user != null)
			{
				return null;
			}//else nothing


			user = mapper.Map<User>(model);
			userRepository.Save(user);
			return user.Id;
		}

		public UserModel GetByName(string inviterBy)
		{
			return  mapper.Map<UserModel>(userRepository.GetByName(inviterBy));
		
		}
	}
}
