using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WebApplication.Domain.Reminders;
using WebApplication.Manager.NotificationEngin;

namespace WebApplication.Manager
{
    public class ReminderManager : IReminderManager
    {
        private readonly IReminderProvider _reminderProvider;
        private readonly IMediator _mediator;

        public ReminderManager(IReminderProvider reminderProvider, IMediator mediator)
        {
           _reminderProvider = reminderProvider;
            _mediator = mediator;
        }

        public async Task CreateAsync(CreateReminderDomain createReminder)
        {
            await _reminderProvider.CreateAsync(createReminder);

            var emailRequest = new EmailRequest("alishakkouf404@gmail.com", "Reminder Created", "Test");
            await _mediator.Send(emailRequest);
        }

        public async Task<List<ReminderDomain>> GetAllAsync()
        {
            return await _reminderProvider.GetAllAsync();
        }
                
    }
}
