using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramwork
{
	[Table("Register")]
	public class User
	{
		//   将之前的User类名改为Register，但仍然能对应表User
		//将之前的User属性Name改成UserName，但仍然能对应表User的列Name
		//将Name的长度限制为256

		//Password不能为空
		//将User表的主键设置在Name列上

		//User类中的属性FailedTry不用存储到数据库中
		//给CreateTime属性添加一个非聚集唯一索引

		//CreateTime不能小于2000年1月1日
		public int Id { get; set; }
		[Column("UserName"),MaxLength(256)/*Key*/]
		public string Name { get; set; }
		public int? Age { get; set; }
		public DateTime? Enroll { get; set; }
		public bool IsFemale { get; set; }
		[Required]
		public string Password { get; set; }
		[NotMapped]
		public int FailedTry { get; set; }
		[Index(IsClustered =false)]
		public DateTime? CreateTime { get; set; }
		public int? EmailId { get; set; }
		public int Wallet { get; set; }
	}
}