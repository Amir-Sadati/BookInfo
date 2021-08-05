using BookInfo.Application.Interfaces;
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
        public async Task SendEmail(string EmailAddress,string Subject, string Message)
        {
             using (var Client = new SmtpClient())
            {
                var Credential = new NetworkCredential
                {
                    UserName="amirsadati79",
                    Password= "GussWhat", // :D
                };

                Client.Credentials = Credential;
                Client.Host = "smtp.gmail.com";
                Client.Port = 587;
                Client.EnableSsl = true;

                using (var emailMessage = new MailMessage())
                {
                    emailMessage.To.Add(new MailAddress(EmailAddress));
                    emailMessage.From = new MailAddress("amirsadati79@gmail.com");
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
