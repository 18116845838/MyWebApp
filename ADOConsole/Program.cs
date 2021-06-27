using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
namespace ADOConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			#region	用ADO.NET实现以下功能的数据库操作：

			//   注册 / 登录
			//内容：


			//		列表页呈现（包括：过滤 / 分页）
			//		批量标记Message为已读
			#endregion
			//string name = Console.ReadLine();
			//string password = Console.ReadLine();
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=17bang;Integrated Security=True;";
			//using (DbConnection dbConnection=new SqlConnection(connectionString))
			//{
			//	dbConnection.Open();
			//	DbCommand dbCommand = new SqlCommand();
			//	dbCommand.Connection = dbConnection;
			//	dbCommand.CommandText = "SELECT [Password] FROM [User]" +
			//		$"WHERE [UserName]=N'{name}'";
			//	object oPassword= dbCommand.ExecuteScalar();

			//	if (oPassword==null)
			//	{
			//		Console.WriteLine("用户名输入错误");
			//		return;
			//	}//else nothing
			//	if (password!=oPassword.ToString())
			//	{
			//		Console.WriteLine("用户名或者密码错误");
			//	}
			//	else
			//	{
			//		Console.WriteLine("恭喜你登录成功！");
			//	}
			//}
			//		发布 / 修改
			//int id = int.Parse(Console.ReadLine());
			//string title = Console.ReadLine();
			//string content = Console.ReadLine();
			//int NeedRemoteHelp = int.Parse(Console.ReadLine());
			//int Reward = int.Parse(Console.ReadLine());
			using (DbConnection connection =new SqlConnection(connectionString))
			{
				connection.Open();
				DbCommand dbCommand = new SqlCommand();
				dbCommand.Connection = connection;
				//dbCommand.CommandText = $"INSERT Problem(Id,Title,Content,NeedRemoteHelp,Reward) VALUES({id},N'{title}',N'{content}',{NeedRemoteHelp},{Reward})";
				dbCommand.CommandText = $"UPDATE Problem SET Reward = 101 WHERE ID >100 ";
				dbCommand.ExecuteNonQuery();
			}

			//		单页呈现
		}
	}
}
