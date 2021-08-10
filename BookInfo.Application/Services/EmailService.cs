using BookInfo.Application.Interfaces;
using BookInfo.Domain.Classes;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Application.Services
{
   public class EmailService :IEmailService
    {
        private readonly IOptionsSnapshot<EmailInfo> _emailinfo;

        public EmailService(IOptionsSnapshot<EmailInfo>emailinfo)
        {
            _emailinfo = emailinfo;
        }
        public async Task SendEmailAsync(string EmailAddress,string Subject, string Message)
        {
             using (var Client = new SmtpClient())
            {
                var Credential = new NetworkCredential
                {
                    UserName=_emailinfo.Value.UserName,
                    Password=_emailinfo.Value.Password,
                };

                Client.Credentials = Credential;
                Client.Host = _emailinfo.Value.Host;
                Client.Port = _emailinfo.Value.Port;
                Client.EnableSsl = true;

                using (var emailMessage = new MailMessage())
                {
                    emailMessage.To.Add(new MailAddress(EmailAddress));
                    emailMessage.From = new MailAddress(_emailinfo.Value.Address);
                    emailMessage.Subject = Subject;
                    emailMessage.IsBodyHtml = true;
                    emailMessage.Body = Message;

                    Client.Send(emailMessage);
                };

                await Task.CompletedTask;
            }
                
          
        }
    }
}
