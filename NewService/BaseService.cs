using AutoMapper;
using NewEntity;
using NewGlobal;
using NewViewModel;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NewService
{
	public class BaseService
	{
		protected readonly static MapperConfiguration config;
		static BaseService()
		{
			config = new MapperConfiguration(
				cfg => cfg.CreateMap<User, UserModel>().ReverseMap()
				);
		}
		protected IMapper mapper { get { return config.CreateMapper(); } }

		protected SqlDbContext context
		{
			get
			{
				if (HttpContext.Current.Items[Keys.DbContext] == null)
				{
					SqlDbContext cx = new SqlDbContext();
					HttpContext.Current.Items[Keys.DbContext] = cx;
				}//else nothing
				return  HttpContext.Current.Items[Keys.DbContext] as SqlDbContext;
				
			}
		}
	}
}
