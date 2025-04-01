using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Tracing;

namespace CalendarApp1.Models
{
    public class CalendarEvent
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } 
        public required string EventDescription { get; set; }  

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty ;

        [Required]
        public DateTime EventDate { get; set; }

        public int? CategoryId { get; set; }
        public EventCategory? Category { get; set; }

        public List<Reminder>? Reminders { get; set; }
        public List<EventParticipant>? Participants { get; set; }
        public List<EventComment>? Comments { get; set; }
        public RecurringEvent? Recurrence { get; set; }
    }
}


