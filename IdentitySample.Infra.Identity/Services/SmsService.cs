using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentitySample.Infra.Identity.Services
{
    public class SmsService : ISmsSender
    {
        public Task SendSmsAsync(string number, string message)
        {
            return Task.FromResult(0);
        }
    }
}
