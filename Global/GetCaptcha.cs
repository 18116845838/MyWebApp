using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global
{
	public static class GetCaptcha
	{
		private static Random random;
		static GetCaptcha()
		{
			random = new Random();
		}
		public static string GetCaptchastring()//生成字符串
		{
			string num = "1234567890qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";

			string captchaString = null;
			for (int i = 0; i < 4; i++)
			{
				captchaString += num.Substring(random.Next(num.Length), 1);
			}
			return captchaString;
		}

		public static Bitmap BitmapTast(out string session)//生成画布
		{
			Bitmap bitmapTast = new Bitmap(80, 30);
			Graphics g = Graphics.FromImage(bitmapTast);
			session = GetCaptchastring();

			g.Clear(Color.White);
			for (int i = 0; i < 10; i++)
			{
				g.DrawLine(new Pen(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)))
				, new Point(random.Next(130), random.Next(60)), new Point(random.Next(130), random.Next(60)));
			}
			for (int i = 0; i < 50; i++)
			{
				bitmapTast.SetPixel(random.Next(bitmapTast.Width), random.Next(bitmapTast.Height),
					Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)));
			}
			g.DrawString(session, new Font("宋体", 25), new SolidBrush(Color.FromArgb
				(random.Next(255), random.Next(255), random.Next(255))), new PointF(0,0));
			return bitmapTast;


		}


	}
}
