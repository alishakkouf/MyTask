namespace WebApplicationTask.Controllers.Reminders.Dtos
{
    public class CreateReminderDto
    {
        public string? Title { get; set; }

        public DateTime ReminderDateTime { get; set; }
    }
}
