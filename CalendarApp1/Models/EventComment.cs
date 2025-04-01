using System;

namespace CalendarApp1.Models
{
    public class EventComment
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public CalendarEvent? Event { get; set; }
        public int UserId { get; set; }
        public required string CommentText { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

