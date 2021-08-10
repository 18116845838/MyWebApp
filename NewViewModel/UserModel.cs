using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewViewModel
{
	public class UserModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "必须填写用户名")]
		public string Name { get; set; }
		[Required(ErrorMessage = "必须填写邀请人")]

		public string InviterBy { get; set; }
		[Required(ErrorMessage = "必须填写邀请码")]

		public string InviterByCode { get; set; }
		[Required(ErrorMessage = "必须填写密码")]
		[MinLength(4,ErrorMessage ="密码长度必须大于四位数字")]
		public string Password { get; set; }
		public string Icon { get; set; }
		public string Email { get; set; }
	}
}
