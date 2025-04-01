using CalendarApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApp1.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CalendarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Показати всі події
        public async Task<IActionResult> Index()
        {
            var events = await _context.CalendarEvents
                .Include(e => e.Category)
                .Include(e => e.Reminders)
                .Include(e => e.Participants)
                .Include(e => e.Comments)
                .Include(e => e.Recurrence)
                .ToListAsync();

            return View(events);
        }

        // Додати подію
        public IActionResult Create()
        {
            var categories = _context.EventCategories.ToList();
            ViewBag.Categories = categories.Any() ? categories : new List<EventCategory>();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CalendarEvent model, int? categoryId, DateTime? reminderTime, string recurrencePattern)
        {
            if (ModelState.IsValid)
            {
                // Перевіряємо, чи існує вибрана категорія
                if (categoryId.HasValue && !_context.EventCategories.Any(c => c.Id == categoryId.Value))
                {
                    ModelState.AddModelError("CategoryId", "Обрана категорія не існує.");
                    return View(model);
                }

                model.CategoryId = categoryId ?? 1; // Значення за замовчуванням

                _context.CalendarEvents.Add(model);
                await _context.SaveChangesAsync();

                // Додаємо нагадування
                if (reminderTime.HasValue)
                {
                    _context.Reminders.Add(new Reminder { EventId = model.Id, ReminderTime = reminderTime.Value });
                }

                // Додаємо повторення, якщо воно коректне
                if (!string.IsNullOrWhiteSpace(recurrencePattern))
                {
                    if (new[] { "daily", "weekly", "monthly", "yearly" }.Contains(recurrencePattern.ToLower()))
                    {
                        _context.RecurringEvents.Add(new RecurringEvent { EventId = model.Id, RecurrencePattern = recurrencePattern });
                    }
                    else
                    {
                        ModelState.AddModelError("RecurrencePattern", "Некоректний шаблон повторення.");
                        return View(model);
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // Додати коментар до події
        [HttpPost]
        public async Task<IActionResult> AddComment(int eventId, string commentText)
        {
            if (!string.IsNullOrWhiteSpace(commentText))
            {
                var eventEntity = await _context.CalendarEvents.FindAsync(eventId);
                if (eventEntity == null) return NotFound("Подію не знайдено.");

                _context.EventComments.Add(new EventComment
                {
                    EventId = eventEntity.Id,
                    CommentText = commentText,
                    CreatedAt = DateTime.UtcNow
                });

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // Запросити користувача на подію
        [HttpPost]
        public async Task<IActionResult> InviteUser(int eventId, int userId)
        {
            var eventEntity = await _context.CalendarEvents.FindAsync(eventId);
            if (eventEntity == null) return NotFound("Подію не знайдено.");

            if (await _context.EventParticipants.AnyAsync(p => p.EventId == eventId && p.UserId == userId))
            {
                return BadRequest("Користувач вже запрошений.");
            }

            _context.EventParticipants.Add(new EventParticipant
            {
                EventId = eventEntity.Id,
                UserId = userId,
                Status = "Pending"
            });

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Видалити подію
        public async Task<IActionResult> Delete(int id)
        {
            var eventToDelete = await _context.CalendarEvents
                .Include(e => e.Reminders)
                .Include(e => e.Participants)
                .Include(e => e.Comments)
                .Include(e => e.Recurrence)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (eventToDelete == null) return NotFound("Подію не знайдено.");

            _context.CalendarEvents.Remove(eventToDelete);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}

