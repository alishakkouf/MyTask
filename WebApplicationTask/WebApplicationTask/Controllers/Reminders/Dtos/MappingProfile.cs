using AutoMapper;
using WebApplication.Domain.Departments;
using WebApplication.Domain.Reminders;
using WebApplicationTask.Controllers.Departments.Dtos;

namespace WebApplicationTask.Controllers.Reminders.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateReminderDto, CreateReminderDomain>();
            CreateMap<ReminderDomain, ReminderDto>();
        }
    }
}
