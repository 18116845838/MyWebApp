using System;
using System.Collections.Generic;
using System.Text;

namespace FECore
{
	public class Bad :BaseEntity
	{
		public string Location { get; set; }
		public virtual Student Owner { get; set; }
		//public int OwnerID { get; set; }
	}
}
