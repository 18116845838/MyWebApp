using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ADOConsole
{
	[Table("Register")]
	[Index("CreateTime", IsUnique = false)]

	class User
	{
		#region MyRegion
		//		将User类映射到数据库：
		//    使用EF的API直接建库建表删库
		//	使用Migration工具建库建表
		//Migration之后，在User类上添加一列：int FailedTry（尝试登陆失败次数），使用Migration工具：
		//    将改动同步到数据库
		//	回退数据库到FailedTry添加之前
		#endregion
		[Key]

		public int Id { get; set; }
		[MaxLength(256)]
		[Column("UserName")]
		public string Name { get; set; }
		public int? Age { get; set; }
		public DateTime? Enroll { get; set; }
		public bool IsFemale { get; set; }
		[Required]
		public string Password { get; set; }
		[NotMapped]
		public int FailedTry { get; set; }
		public DateTime? CreateTime { get; set; }
		public int? EmailId { get; set; }
		public Email Email { get; set; }
		public int Wallet { get; set; }
		#region 分别使用OnModelCreating()和Data Annotations，完成以下配置：

		//   将之前的User类名改为Register，但仍然能对应表User
		//将之前的User属性Name改成UserName，但仍然能对应表User的列Name
		//将Name的长度限制为256

		//Password不能为空
		//将User表的主键设置在Name列上

		//User类中的属性FailedTry不用存储到数据库中
		//给CreateTime属性添加一个非聚集唯一索引

		//CreateTime不能小于2000年1月1日
		#endregion

	}
}
