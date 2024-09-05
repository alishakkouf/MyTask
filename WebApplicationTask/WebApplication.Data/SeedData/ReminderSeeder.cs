using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Data.Models.Reminders;

namespace WebApplication.Data.SeedData
{
    public class ReminderSeeder : IDataSeeder
    {
        public void Seed(ApplicationDbContext context)
        {
            Console.WriteLine("Seeding reminders...");

            // Check if there are any existing Reminders to avoid seeding duplicates
            if (context.Reminders.Any())
            {
                Console.WriteLine("Reminders already exist. Skipping seed.");
                return;
            }

            var reminders = new List<Reminder>
            {
                new Reminder
                {
                    Title = "Reminder 1", ReminderDateTime = DateTime.Now,
                },
                new Reminder
                {
                    Title = "Reminder 2", ReminderDateTime = DateTime.Now,
                }
            };

            // Add the reminders to the context and save changes
            context.Reminders.AddRange(reminders);
            context.SaveChanges();

            Console.WriteLine("reminders seeding complete.");
        }
    }
}

