using System;

namespace CalendarApp1.Models
{
    public class Reminder
    {
        public int Id { get; set; }
        public int EventId { get; set; } 
        public CalendarEvent? Event { get; set; } 
        public DateTime ReminderTime { get; set; }
    }

}
