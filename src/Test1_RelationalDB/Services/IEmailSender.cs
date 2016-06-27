using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test1_RelationalDB.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
