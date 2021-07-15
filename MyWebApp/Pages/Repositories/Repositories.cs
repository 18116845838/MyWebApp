using MyWebApp.Pages.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MyWebApp.Pages.Repositories
{
	public class Repositories
	{
		static IList<Content> Contents;

		static Repositories()
		{
			Contents = new List<Content> {
				new Content
				{
					Id=1,
					Title="Java：面向对象：继承 / 多态",
					Body="继承使用关键字extends表示继承，super表示基类 public class OnlineStudent extends Student {public OnlineStudent(int age) {super(age);}}final：修饰类/方法，同sealedinstanceof：同is，没有asPerson fg = new Teacher();System.out.println(fg instanceof Person);System.out.println(fg instanceof ",
					PublishTime=DateTime.Now,
					Answer=100,
					Summary=20,
					Reward=30,
					Author=new User{
						Id=1,
						Name="飞哥",
						Level=9
					},
					Keywords=new List<Keyword>
					{
						new Keyword
						{
							Name="Java"
						},
						new Keyword
						{
							Name="面向对象"
						},
						new Keyword
						{
							Name="继承"
						}
					}

				},
				new Content
				{
					Id=2,
					Title="J&C：面向对象：构造函数 / 禁止继承 / 抽象类 / 接口",
					Body="继承使用关键字extends表示继承，super表示基类 public class OnlineStudent extends Student {public OnlineStudent(int age) {super(age);}}final：修饰类/方法，同sealedinstanceof：同is，没有asPerson fg = new Teacher();System.out.println(fg instanceof Person);System.out.println(fg instanceof ",
					PublishTime=DateTime.Now,
					Answer=100,
					Summary=20,
					Reward=30,
					Author=new User{
						Id=1,
						Name="小鱼",
						Level=7
					},
					Keywords=new List<Keyword>
					{
						new Keyword
						{
							Name="C#"
						},
						new Keyword
						{
							Name="面向对象"
						},
						new Keyword
						{
							Name="多态"
						}
					}

				},new Content
				{
					Id=3,
					Title=" python爬虫不能够得到网址",
					Body="想十年之后最希望的场景：帮助更多：被应试教育抛弃被劣质教育荒废的同学为野生程序猿正名 ，让源栈的同学可以骄傲的行走在阳光之下！从低端码农向高端人才培养迈进做那种想起来就让你热泪盈眶的事。最不能接受的场景：关门倒闭了像某内某鸟一样，顶风臭十里两害相权，哪怕我教室还是这么十来个学生，但每个学生都学有所成，至少觉得学费还值，不怨我飞哥，也就OK了。关键是人：同志，你在哪儿？一般的公司，是一个利益共同体。但做教育，我希望而且必须保证，源栈是一个理想共同体。在今天的社会，还能不能找到这样的人，找到很多很多这样的人？",
					PublishTime=DateTime.Now,
					Answer=100,
					Summary=20,
					Reward=30,
					Author=new User{
						Id=3,
						Name="小鱼",
						Level=9

					},
					Keywords=new List<Keyword>
					{
						new Keyword
						{
							Name="Sql"
						},
						new Keyword
						{
							Name="参数化"
						},
						new Keyword
						{
							Name="Update"
						}
					}

				},new Content
				{
					Id=4,
					Title=" 西安大专应届生找个JAVA开发的工作，有没有推荐的 / ",
					Body="本人3个月后毕业，自学3年JAVA，对J2EE的一整套开发体系非常熟悉，OA类的项目做的比较多。荣获第八届蓝桥杯JAVA C组个人赛全国一等奖，之后去上海实习几个月，因为一些原因必须回西安发展，但是投简历无数，要么没有音信，要么第一轮面试结束没有消息，要么学历不过关--。智联上西安的JAVA校招几乎没有，1个月过去了，还是没有工作，我都不求工资，只求有长远发展，不会的我都愿意学，但是不想去那种混日子的公司，要有激情，有创新，有热血的公司。有没有推荐的，或者那位大神觉得我可以内推一下我，至少给个面试机会……",
					PublishTime=DateTime.Now,
					Answer=100,
					Summary=20,
					Reward=30,
					Author=new User{
						Id=1,
						Name="飞哥",
						Level=2
					},
					Keywords=new List<Keyword>
					{
						new Keyword
						{
							Name="Java"
						},
						new Keyword
						{
							Name="面向对象"
						},
						new Keyword
						{
							Name="继承"
						}
					}

				},new Content
				{
					Id=5,
					Title="星光计划（alpha版）：加入我们，一起证明：没有一纸文凭，仍然可以活得精彩！",
					Body="继承使用关键字extends表示继承，super表示基类 public class OnlineStudent extends Student {public OnlineStudent(int age) {super(age);}}final：修饰类/方法，同sealedinstanceof：同is，没有asPerson fg = new Teacher();System.out.println(fg instanceof Person);System.out.println(fg instanceof ",
					PublishTime=DateTime.Now,
					Answer=100,
					Summary=20,
					Reward=30,
					Author=new User{
						Id=1,
						Name="飞哥",
						Level=5
					},
					Keywords=new List<Keyword>
					{
						new Keyword
						{
							Name="Java"
						},
						new Keyword
						{
							Name="面向对象"
						},
						new Keyword
						{
							Name="继承"
						}
					}

				},new Content
				{
					Id=6,
					Title="被文凭割裂的社会，难道你没有感到一种绝望吗？",
					Body="继承使用关键字extends表示继承，super表示基类 public class OnlineStudent extends Student {public OnlineStudent(int age) {super(age);}}final：修饰类/方法，同sealedinstanceof：同is，没有asPerson fg = new Teacher();System.out.println(fg instanceof Person);System.out.println(fg instanceof ",
					PublishTime=DateTime.Now,
					Answer=100,
					Summary=20,
					Reward=30,
					Author=new User{
						Id=1,
						Name="飞哥",
					},
					Keywords=new List<Keyword>
					{
						new Keyword
						{
							Name="Java"
						},
						new Keyword
						{
							Name="面向对象"
						},
						new Keyword
						{
							Name="继承"
						}
					}

				},new Content
				{
					Id=7,
					Title="mock.js：模拟后台响应",
					Body="继承使用关键字extends表示继承，super表示基类 public class OnlineStudent extends Student {public OnlineStudent(int age) {super(age);}}final：修饰类/方法，同sealedinstanceof：同is，没有asPerson fg = new Teacher();System.out.println(fg instanceof Person);System.out.println(fg instanceof ",
					PublishTime=DateTime.Now,
					Answer=100,
					Summary=20,
					Reward=30,
					Author=new User{
						Id=1,
						Name="飞哥",
					},
					Keywords=new List<Keyword>
					{
						new Keyword
						{
							Name="Java"
						},
						new Keyword
						{
							Name="面向对象"
						},
						new Keyword
						{
							Name="继承"
						}
					}

				},new Content
				{
					Id=8,
					Title="Git远程：push / pull / clone / fetch / conflict",
					Body="继承使用关键字extends表示继承，super表示基类 public class OnlineStudent extends Student {public OnlineStudent(int age) {super(age);}}final：修饰类/方法，同sealedinstanceof：同is，没有asPerson fg = new Teacher();System.out.println(fg instanceof Person);System.out.println(fg instanceof ",
					PublishTime=DateTime.Now,
					Answer=100,
					Summary=20,
					Reward=30,
					Author=new User{
						Id=1,
						Name="飞哥",
					},
					Keywords=new List<Keyword>
					{
						new Keyword
						{
							Name="Java"
						},
						new Keyword
						{
							Name="面向对象"
						},
						new Keyword
						{
							Name="继承"
						}
					}

				}


			};
		}
		public IList<Article.Content> Get(int pageIndex, int pageSize)
		{
			return Contents.Skip((pageIndex - 1) * pageSize)
				.Take(pageSize).ToList();
			//return Articles;
		}
		public int GetCount()
		{
			return Contents.Count();
		}
		//		利用内存读写Repository，完成内容（求助/文章/意见建议）的

		//   新建
		public void Add(Content content)
		{
			Contents.Add(content);
		}
		//	修改：通过id修改正确的内容，并予以显示（提示：?id=3）。能完成基本内容（比如：标题/正文）修改就行，不需要富文本、关键字之类的附加功能

		public void Alter(int id,string alterTitel="",string alterBody = "")
		{
			Content content= Contents.Where(c => c.Id == id).SingleOrDefault();
			if (alterTitel.Length>0)
			{
				content.Title = alterTitel;

			}//else nothing
			if (alterBody.Length>0)
			{
				content.Body = alterBody;
			}//else nothing
		}
		//完成消息页面的：

		//标记已读
		//删除

	}
}
