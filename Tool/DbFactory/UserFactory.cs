using Entities;
using Repositoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFactory
{
	class UserFactory
	{
		internal static User zhangsan;
		internal static User lisi;


		internal static void Create()
		{
			zhangsan = Register("张三");
			lisi = Register("李四");
		}
		internal static User Register(string name)
		{
			const string pwd = "123456";
			User user = new User
			{
				Name = name,
				Password = pwd,

			};
			user.GetType().GetProperty("CreateTime")
			.SetValue(user, Helper.BaseLine());

			UserRepository repository = new UserRepository(Helper.GetContext());
			repository.Save(user);
			return user;
		}
	}
}
