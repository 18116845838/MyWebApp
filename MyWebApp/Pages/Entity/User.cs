using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Pages.Article
{
	public class User : Entity
	{
		public string Name { get; set; }
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[DataType(DataType.Password)]
		public string ValidatePassword { get; set; }
		public string Captcha { get; set; }
		public int Age { get; set; }
		public string InvitationCode { get; set; }

		public string QQ { get; set; }
		public string Wechat { get; set; }
		public string phone { get; set; }
		public string postscript { get; set; }

		public bool IsMale { get; set; }
	}
}