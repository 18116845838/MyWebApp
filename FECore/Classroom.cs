using System.Collections.Generic;

namespace FECore
{
	public class Classroom
	{
		public int Id { get; set; }

		public string Name { get; set; }
		public virtual List<Student> Students { get; set; }
	}
}