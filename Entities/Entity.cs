using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Entity
    {
		public Entity()
		{
            CreateTime = DateTime.Now;
		}
        public int Id { get; set; }
        public DateTime CreateTime { get; protected set; }

    }
}
