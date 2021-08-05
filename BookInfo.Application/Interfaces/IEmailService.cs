using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(string EmailAddress, string Subject, string Message);
    }
}
