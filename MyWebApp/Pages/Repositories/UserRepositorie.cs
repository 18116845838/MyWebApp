using MyWebApp.Pages.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Pages.Repositories
{
	public class UserRepositorie
	{
		static IList<User> users;
		static UserRepositorie()
		{
			users = new List<User>
			{
				new User
				{
					Id =1,
					Name="飞哥",
					IsMale=true,
					Password="123456",
					InvitationCode="1234",
					Level=9

				}   ,
				new User
				{
					Id =2,
					Name="小鱼",
					IsMale=true,
					Password="123456",
					InvitationCode="1234",
					Level=7

				} 
				
			};

		}

		public IList<User> Get()
		{
			return users;
		}

	}
}
