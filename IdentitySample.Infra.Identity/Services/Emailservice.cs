using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentitySample.Infra.Identity.Services
{
    public class EmailService : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.FromResult(0);
        }
    }
}
