using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _17bangMVC.Models
{
	public class ArcticleModel
	{
		public string Title { get; set; }
		public string Body { get; set; }
		public User Author { get; set; }
	}
}