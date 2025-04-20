using MimeKit;
using MVC_Core_SocialMediaProject.Models;
using MailKit.Net.Smtp;
using MVC_Core_SocialMediaProject.Services.Interfaces;
using System.Drawing;
using Humanizer;
using Microsoft.Extensions.Options;

namespace MVC_Core_SocialMediaProject.Services.Implementation
{
    public class ExtraService:IExtraservice
    {
        EmailSettings _settings;
        public ExtraService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public string GenerateOTP(int size)
        {
            string data = "0123456789";
            string otp = "";
            Random r = new Random();

            for (int i = 1; i <= size; i++)
            {
                int p = r.Next(0, data.Length-1);
                otp =otp + p;
            }
            return otp;
        }

        public string GetRandomPassword(int length)
        {
            string data = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXZY0123456789@#$";
            string password = "";
            Random r = new Random();

            for (int i = 1; i <= length; i++)
            {
                int p = r.Next(0, data.Length - 1);
                password = password + data[p];
            }
            return password;
        }

        public void SendEmail(EmailModel email)
        { 
            MimeMessage message = new MimeMessage();
            MailboxAddress emailform = new MailboxAddress(_settings.UserName, _settings.EmailAddress);
            MailboxAddress mailto = new MailboxAddress(email.UserName, email.EmailAddress);
            message.From.Add(emailform);
            message.To.Add(mailto);
            message.Subject = email.Subject;

            BodyBuilder body = new BodyBuilder();
            body.HtmlBody = email.Message;
            message.Body = body.ToMessageBody();

            SmtpClient smtp = new SmtpClient();
            smtp.Timeout = 2000000;
            smtp.Connect(_settings.Host, _settings.Port, _settings.UseSSL);
            smtp.Authenticate(_settings.EmailAddress, _settings.Password);
            smtp.Send(message);
            smtp.Disconnect(true);
            smtp.Dispose();
        }
    }
}
