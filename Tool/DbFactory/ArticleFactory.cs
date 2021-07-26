using Entities;
using Repositoy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFactory
{
	class ArticleFactory
	{
		internal static void Create()
		{
			Article article = new Article
			{
				Author = UserFactory.zhangsan,
				Title = "",
				Body = Read("")
			};

			//article.Publilsh();
			new ArcticleRepository(Helper.GetContext()).Save(article);

		}
		internal static string Read(string name)
		{
			//获取当前工作环境路径
			string path = Environment.CurrentDirectory.Replace("\\bin\\Debug",string.Empty);
			return File.ReadAllText(Path.Combine(path,"articles",$"{ name}.txt"));
		}

	}
}
