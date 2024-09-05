namespace WebApplicationTask.Controllers.Reminders.Dtos
{
    public class ReminderDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public DateTime ReminderDateTime { get; set; }
    }
}
