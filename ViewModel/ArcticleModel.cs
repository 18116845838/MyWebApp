
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace _17bangMVC.Models
{
	public class ArcticleModel
	{
		public string Title { get; set; }
		[AllowHtml]
		public string Body { get; set; }
		public Entities.User Author { get; set; }
	}
}