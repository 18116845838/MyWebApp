using Global;
using Repositoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SRV.ProdService
{
	public class BaseService
	{
		private UserRepository userRepository;
		//protected SqlDbContext _context;
		protected SqlDbContext context
		{
			get
			{
				if (HttpContext.Current.Items[Keys.DbContext]==null)
				{
					HttpContext.Current.Items[Keys.DbContext]= new SqlDbContext();

				}
				return  (SqlDbContext)HttpContext.Current.Items[Keys.DbContext];
			}
		}
		public BaseService()
		{

			userRepository = new UserRepository(context);
		}
	}
}
