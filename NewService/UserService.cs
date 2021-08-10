
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
		public int? Register(UserModel model)
		{
			User user = new UserRepository(context).GetByName(model.Name);

			if (user != null)
			{
				return null;
			}//else nothing


			user = mapper.Map<User>(model);
			new BaseRepository<User>(context).Save(user);
			return user.Id;
		}
	}
}
