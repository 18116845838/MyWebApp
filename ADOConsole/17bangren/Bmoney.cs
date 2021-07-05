using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADOConsole._17bangren
{
	class Bmoney
	{
		//用事务实现帮帮币出售的过程
		// 卖方帮帮币足够，扣减数额后成功提交。
		//  卖房帮帮币不够，事务回滚，买卖双方帮帮币不变。
		public int Id { get; set; }
		public User User { get; set; }
		public int Change { get; set; }
		public int Surplus { get; set; }
		public DateTime DealTime { get; set; }
		public string Message { get; set; }

		public static void  BmoneyDeal(int buyerId, int sellerId, int number)
		{
			DBSqlContext sqlContext = new DBSqlContext();

			using (IDbContextTransaction transaction = sqlContext.Database.BeginTransaction())
			{
				try
				{
					User buyer = sqlContext.Users.Where(u => u.Id == buyerId).SingleOrDefault();
					User seller = sqlContext.Users.Where(u => u.Id == sellerId).SingleOrDefault();

					if (buyer.Wallet<number || seller.Wallet<number)
					{
						return;
					}
					//else nothing
					buyer.Wallet -= number;
					seller.Wallet += number;
					sqlContext.SaveChanges();
					transaction.Commit();

				}
				catch (Exception)
				{
					transaction.Rollback();
					throw;
				}
			}

		}


	}
}
