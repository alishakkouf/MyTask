using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data.Models.Departments;
using WebApplication.Domain.Reminders;
using WebApplicationTask.Controllers.Departments.Dtos;
using WebApplicationTask.Controllers.Reminders.Dtos;

namespace WebApplicationTask.Controllers.Reminders
{
    public class RemindersController : Controller
    {
        private readonly IReminderManager _reminderManager;
        private readonly IMapper _mapper;

        public RemindersController(IReminderManager reminderManager, IMapper mapper)
        {
            _reminderManager = reminderManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var reminders = await _reminderManager.GetAllAsync();

            return View(_mapper.Map<List<ReminderDto>>(reminders));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReminderDto createReminder)
        {
            if (ModelState.IsValid)
            {
                await _reminderManager.CreateAsync(_mapper.Map<CreateReminderDomain>(createReminder));

                return RedirectToAction(nameof(Index));
            }
            return View(createReminder);
        }
    }
}
