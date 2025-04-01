namespace CalendarApp1.Models
{
    public class EventParticipant
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public CalendarEvent? Event { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; } = "Pending"; // 'Pending', 'Accepted', 'Declined'
    }
}
