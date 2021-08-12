using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewViewModel
{
	public class ChangePasswordModel
	{
		[Required(ErrorMessage = "必须填写原密码")]
		[MinLength(4,ErrorMessage ="密码长度必须大于四位数字")]
		public string Password { get; set; }


		[Required(ErrorMessage = "必须填写新密码")]
		[MinLength(4, ErrorMessage ="密码长度必须大于四位数字")]
		public string NewPassword { get; set; }

	}
}
