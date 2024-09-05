using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Manager.NotificationEngin
{
    public interface IMailService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
