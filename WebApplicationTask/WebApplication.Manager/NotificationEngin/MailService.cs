using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Manager.NotificationEngin
{
    public class MailService : IMailService
    {
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            await Task.Run(() => Console.WriteLine($"Sending email to {to}: {subject} - {body}"));
        }
    }
}
