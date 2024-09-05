using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Manager.NotificationEngin
{
    public class MessageService
    {
        public void OnReminderCreated(object source, EventArgs args) => Console.WriteLine("Message is sent");
    }
}
