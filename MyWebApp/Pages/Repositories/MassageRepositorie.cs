using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E = MyWebApp.Pages.Entity;
namespace MyWebApp.Pages.Repositories
{
	public class MassageRepositorie
	{
		static IList<E.Message> messages;
		static MassageRepositorie()
		{
			messages = new List<E.Message>
			{
				new E.Message
				{
					Id = 1,
					CreateTime=DateTime.Now,
					Content="你因为登录获得系统随机分配给你的 帮帮豆 4 枚，可用于感谢赞赏等。 "
				},
				new E.Message{
					Id=2,
					CreateTime=DateTime.Now.AddDays(2),
					Content="你因为登录获得系统随机分配给你的 帮帮豆 3 枚，可用于感谢赞赏等。 "
				},
				new E.Message{
										Id=3,
					CreateTime=DateTime.Now.AddDays(4),
					Content="你因为登录获得系统随机分配给你的 帮帮豆 18 枚，可用于感谢赞赏等。 "	
				}
			};

		}
		public IList<E.Message> Get()
		{
			return messages;
		}
		public void Dalete(int id)
		{
			messages.Remove(messages.Where(m => m.Id == id).SingleOrDefault()); 
		}
	}
}
