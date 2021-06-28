using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


namespace ADOConsole
{
	class Dbhelper
	{
		private const string connectionString =
			@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=17bang;Integrated Security=True;";

		private int ExecuteNonQuery(string cmdText, params IDataParameter[] parameters)
		{
			IDbCommand command = new SqlCommand();
			command.CommandText = cmdText;
			for (int i = 0; i < parameters.Length; i++)
			{
				command.Parameters.Add(parameters[i]);
			}
			return ExecuteNonQuery(command);
		}
		private int ExecuteNonQuery(IDbCommand command)
		{
			using (IDbConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					connection.Open();
					command.Connection = connection;
					return command.ExecuteNonQuery();
				}
				catch (Exception)
				{

					throw;
				}
				
			}
		}
		
		public int Insert(string cmdText, params IDataParameter[] parameters)
		{
			return ExecuteNonQuery(cmdText, parameters);
		}
		public int Delect(string cmdText, params IDataParameter[] parameters)
		{
			return ExecuteNonQuery(cmdText, parameters);
		}
		public int Update(string cmdText, params IDataParameter[] parameters)
		{
			return ExecuteNonQuery(cmdText, parameters);
		}	

		//public object ExecuteScalar(string cmdText, params IDataParameter[] parameters)
		//{
		//	IDbCommand command = new SqlCommand();
		//	command.CommandText = cmdText;
		//	for (int i = 0; i < parameters.Length; i++)
		//	{
		//		command.Parameters.Add(parameters[i]);
		//	}
		//	return ExecuteNonQuery(command);
		//}
	}
}
