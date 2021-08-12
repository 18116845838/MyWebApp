
using NewEntity;
using NewGlobal;
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
			user.Password = user.Password.MD5Encrypt();
			userRepository.Save(user);
			return user.Id;
		}

		public UserModel GetByName(string inviterBy)
		{
			return  mapper.Map<UserModel>(userRepository.GetByName(inviterBy));
		
		}

		public void ChangePassword(ChangePasswordModel model)
		{
			User user = GetCurrentUser();
			if (user == null)
			{
				throw new ArgumentException("用户未登录");
			}//else nothing
			if (user.Password!=model.Password)
			{
				throw new ArgumentException("原密码输入错误");
			}//else nothing
			user.Password = model.NewPassword;
			new UserRepository(context).Change();
		}
	}
}
