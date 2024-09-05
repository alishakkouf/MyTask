using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Domain.Reminders
{
    public interface IReminderProvider
    {
        /// <summary>
        /// Get All reminders
        /// </summary>
        /// <returns></returns>
        Task<List<ReminderDomain>> GetAllAsync();

        /// <summary>
        /// Create new reminder
        /// </summary>
        Task CreateAsync(CreateReminderDomain createReminder);
    }
}
