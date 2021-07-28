using Entities;
using Repository;
using Repositoy;
using SRV.SerciceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace SRV.ProdService
{
	public class EmailService : BaseService, IEmailService
	{
		private EmailRepository emailRepository;
		public EmailService()
		{
			emailRepository = new EmailRepository(context);
		}

		public void ValidationEmail(EmailModel model, out string code)
		{
			DateTime now = DateTime.Now;
			code = Global.GetCaptcha.GetCaptchastring();



			MailMessage mail = new MailMessage
			{
				From = new MailAddress("feige_20200214@163.com"),
				Body = $"欢迎注册，您的验证码是{code}  <a href='http://localhost:4297/Write/?HasValid=true&Code={code}'>点击直接验证 </a>",
				Subject = "您正在使用邮箱绑定账号",
				IsBodyHtml = true
			};
			mail.To.Add(model.EMail);
			SmtpClient client = new SmtpClient
			{
				Host = "smtp.163.com",
				Port = 25,
				//用密码和客户端授权密码
				Credentials = new NetworkCredential("feige_20200214", "yz17bang"),
				EnableSsl = false
			};
			client.Send(mail);

			//异步
			//client.SendAsync(mail, null);
		}

		public void Save(EmailModel model)
		{
			model.HasValid = true;
			model.UserId = 1;
			Email email= mapper.Map<Email>(model);
			emailRepository.Save(email);
		}
	}
}
