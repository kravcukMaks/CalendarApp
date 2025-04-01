namespace CalendarApp1.Models
{
    public class EventCategory
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public List<CalendarEvent>? Events { get; set; }
    }
}

