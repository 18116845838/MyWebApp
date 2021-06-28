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



			//		批量标记Message为已读

			//string name = Console.ReadLine();
			//string password = Console.ReadLine();
			//string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=17bang;Integrated Security=True;";
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
			//using (DbConnection connection =new SqlConnection(connectionString))
			//{
			//	connection.Open();
			//	DbCommand dbCommand = new SqlCommand();
			//	dbCommand.Connection = connection;
			//	//dbCommand.CommandText = $"INSERT Problem(Id,Title,Content,NeedRemoteHelp,Reward) VALUES({id},N'{title}',N'{content}',{NeedRemoteHelp},{Reward})";
			//	dbCommand.CommandText = $"UPDATE Problem SET Reward = 101 WHERE ID >100 ";
			//	dbCommand.ExecuteNonQuery();
			//}
			//		单页呈现
			//using (DbConnection connection =new SqlConnection(connectionString))
			//{
			//	connection.Open();
			//	DbCommand command = new SqlCommand();
			//	command.Connection = connection;
			//	command.CommandText = "SELECT * FROM Problem";
			//	DbDataReader dbDataReader = command.ExecuteReader();
			//	while (dbDataReader.Read())
			//	{
			//		for (int i = 0; i < dbDataReader.FieldCount; i++)
			//		{
			//			Console.Write(dbDataReader[i]+"     ");
			//		}
			//		Console.WriteLine();
			//	}
			//}
			//		列表页呈现（包括：过滤 / 分页）
			//Console.WriteLine("选择跳转到第几页");
			//int option = int.Parse(Console.ReadLine());
			//using (DbConnection connection =new SqlConnection(connectionString))
			//{
			//	connection.Open();
			//	DbCommand dbCommand = new SqlCommand();
			//	dbCommand.Connection = connection;

			//	dbCommand.CommandText = $"SELECT *FROM" +
			//		$"( SELECT *, ROW_NUMBER() OVER(ORDER BY ID ) DID FROM Problem) pp " +
			//		$"WHERE pp.DID BETWEEN {option*3-2} AND {option*3} ";
			//	DbDataReader dbDataReader = dbCommand.ExecuteReader();
			//	while (dbDataReader.Read())
			//	{
			//		for (int i = 0; i < dbDataReader.FieldCount; i++)
			//		{
			//			Console.Write(dbDataReader[i]+"     ");
			//		}
			//		Console.WriteLine();
			//	}

			//}
			#endregion
			#region 用“参数化查询”改写之前拼接的SQL代码
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=17bang;Integrated Security=True;";
			//int id = int.Parse(Console.ReadLine());
			//using (DbConnection dbConnection =new SqlConnection(connectionString))
			//{
			//	dbConnection.Open();
			//	DbCommand command = new SqlCommand();
			//	command.Connection = dbConnection;
			//	command.CommandText = "SELECT * FROM Problem WHERE ID = @id";
			//	DbParameter pId = new SqlParameter("@id", id);
			//	command.Parameters.Add(pId);
			//	DbDataReader dbDataReader = command.ExecuteReader();

			//	while (dbDataReader.Read())
			//	{
			//		for (int i = 0; i < dbDataReader.FieldCount; i++)
			//		{
			//			Console.WriteLine(dbDataReader[i]);
			//		}
			//	}
			//}
			//用事务完成帮帮币的交易
			//int amount =int.Parse(Console.ReadLine());
			//int balace =int.Parse(Console.ReadLine());
			//int userId =int.Parse(Console.ReadLine());
			//using (DbConnection connection =new SqlConnection(connectionString))
			//{
			//	connection.Open();
			//	IDbCommand dbCommand = new SqlCommand();
			//	dbCommand.Connection = connection;
			//	using (IDbTransaction transaction =connection.BeginTransaction())
			//	{
			//		try
			//		{
			//			dbCommand.Transaction = transaction;
			//			dbCommand.CommandText = $"INSERT BangMoney  VALUES(@amount,@balace,@userId)";
			//			DbParameter dbamount = new SqlParameter("@amount",amount);
			//			DbParameter dbbalace = new SqlParameter("@balace", balace);
			//			DbParameter dbuserId = new SqlParameter("@userId", userId);

			//			dbCommand.Parameters.Add(dbamount);
			//			dbCommand.Parameters.Add(dbbalace);
			//			dbCommand.Parameters.Add(dbuserId);
			//			dbCommand.ExecuteNonQuery();
			//			transaction.Commit();

			//		}
			//		catch (Exception)
			//		{
			//			transaction.Rollback();
			//			throw;
			//		}
			//	}
			//}

			#endregion
			Dbhelper dbhelper = new Dbhelper();
			int id = 5;
			string cmd = "SELECT * FROM Problem WHERE ID = @id";
			IDataParameter[] dbDataParameter = new SqlParameter[] {
				new SqlParameter("@id",117)
			};
			//IDataParameter Parameter = new SqlParameter("@id", 6);


			IDbCommand[] commands = new IDbCommand[dbDataParameter.Length];
			Console.WriteLine(dbhelper.Insert(cmd, dbDataParameter)); 
		}
	}

}
