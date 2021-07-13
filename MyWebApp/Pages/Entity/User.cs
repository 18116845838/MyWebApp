using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Pages.Article
{
	public class User : Entity
	{
		[Required(ErrorMessage ="* 姓名不能为空")]
		public string Name { get; set; }
		[DataType(DataType.Password)]
		[Required(ErrorMessage ="* 必须输入密码")]
		[MinLength(4,ErrorMessage ="* 最小长度为4")]
		public string Password { get; set; }
		//[DataType(DataType.Password)]
		//public string ConfirmPassword { get; set; }
		public string Captcha { get; set; }
		public int Age { get; set; }
		//[Required(ErrorMessage = "* 邀请人不能为空")]
		public User InviterBy { get; set; }
		public string InvitationCode { get; set; }

		public string QQ { get; set; }
		public string Wechat { get; set; }
		public string phone { get; set; }
		public string postscript { get; set; }

		public bool IsMale { get; set; }
	}
}