using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public  class Keyword :Entity
	{
		public string Name { get; set; }
		public List<Content> Contents { get; set; }
	}
}
