using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Auditing;

namespace WebApplication.Data.Models.Reminders
{
    public class Reminder : IAuditedEntity
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public DateTime ReminderDateTime { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public long? ModifierUserId { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool? IsDeleted { get; set; } = false;       
    }
}
