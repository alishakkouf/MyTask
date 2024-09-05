using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data.Models.Departments;
using WebApplication.Data.Models.Reminders;
using WebApplication.Domain.Departments;
using WebApplication.Domain.Reminders;

namespace WebApplication.Data.Providers
{
    internal class ReminderProvider : GenericProvider<Reminder>, IReminderProvider
    {
        private readonly IMapper _mapper;

        public ReminderProvider(ApplicationDbContext context, IMapper mapper)
        {
            DbContext = context;
            _mapper = mapper;
        }

        public async Task<List<ReminderDomain>> GetAllAsync()
        {
            var data = await ActiveDbSet.ToListAsync();

            return _mapper.Map<List<ReminderDomain>>(data);
        }

        public async Task CreateAsync(CreateReminderDomain createReminder)
        {
            var toBeCreated = new Reminder
            {
                Title = createReminder.Title,
                ReminderDateTime = createReminder.ReminderDateTime
            };

            await DbContext.Reminders.AddAsync(toBeCreated);
            await DbContext.SaveChangesAsync();
        }
    }
}
