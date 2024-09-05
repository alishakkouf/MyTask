using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Domain.Reminders
{
    public class CreateReminderDomain
    {
        public string? Title { get; set; }

        public DateTime ReminderDateTime { get; set; }
    }
}
