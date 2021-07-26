using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFactory
{
	class Program
	{
		static void Main(string[] args)
		{

			//		构建剧本，完成以下数据的生成：

			//   张三和李四的注册
			//张三发布了8篇李四发布了4篇文章
			Helper.GetContext().Database.Log = Console.WriteLine;
			Helper.GetContext().Database.Delete();
			Helper.GetContext().Database.Create();
			UserFactory.Create();
			ArticleFactory.Create();
		}
	}
}
