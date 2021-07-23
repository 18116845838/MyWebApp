﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Global
{
	public static class StringExtension
	{
		public static string MD5Encrypt(this string password)
		{
			byte[] bytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < bytes.Length; i++)
			{
				sb.Append(bytes[i].ToString("x"));
			}
			return sb.ToString();
		}
	}
}
