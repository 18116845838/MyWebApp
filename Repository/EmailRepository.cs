using Entities;
using Repositoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class EmailRepository : Repositorys<Email>
	{
		public EmailRepository(SqlDbContext context) : base(context)
		{

		}
	}
}
