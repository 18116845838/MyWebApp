using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewViewModel
{
	public class LogModel
	{
		[Required(ErrorMessage ="必须填写用户名")]
		public string Name { get; set; }
		[Required(ErrorMessage ="必须填写密码")]
		[MinLength(4,ErrorMessage ="密码长都不能小于四位数")]
		public string Password { get; set; }
	}
}
