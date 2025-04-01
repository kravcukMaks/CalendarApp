using CalendarApp1.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Collections.Generic;

namespace CalendarApp1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
        public DbSet<EventComment> EventComments { get; set; }
        public DbSet<RecurringEvent> RecurringEvents { get; set; }
    }
}
