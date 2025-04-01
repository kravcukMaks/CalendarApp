using System;

namespace CalendarApp1.Models
{
    public class RecurringEvent
    {

        public int Id { get; set; }
        public int EventId { get; set; }
        public CalendarEvent? Event { get; set; }
        public required string RecurrencePattern { get; set; } 
        public DateTime? EndDate { get; set; }
    }
}