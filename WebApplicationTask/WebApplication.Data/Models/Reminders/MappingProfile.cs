using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebApplication.Data.Models.Departments;
using WebApplication.Domain.Departments;
using WebApplication.Domain.Reminders;

namespace WebApplication.Data.Models.Reminders
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Reminder, ReminderDomain>().ReverseMap();
        }
    }
}
