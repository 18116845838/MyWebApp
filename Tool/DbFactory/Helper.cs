﻿using Repositoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFactory
{
	class Helper
	{
		private static SqlDbContext _context;
		static Helper()
		{
			_context = new SqlDbContext();
		}
		internal static SqlDbContext GetContext() => _context;

	}
}
