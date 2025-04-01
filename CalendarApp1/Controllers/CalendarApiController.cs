using CalendarApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApp1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalendarApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CalendarApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Отримати всі події (API)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalendarEvent>>> GetEvents()
        {
            var events = await _context.CalendarEvents.ToListAsync();
            return Ok(events);
        }

        // Отримати конкретну подію
        [HttpGet("{id}")]
        public async Task<ActionResult<CalendarEvent>> GetEvent(int id)
        {
            var eventItem = await _context.CalendarEvents.FindAsync(id);
            if (eventItem == null)
                return NotFound("Подія не знайдена.");

            return Ok(eventItem);
        }

        // Додати подію
        [HttpPost]
        public async Task<ActionResult<CalendarEvent>> CreateEvent(CalendarEvent model)
        {
            _context.CalendarEvents.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEvent), new { id = model.Id }, model);
        }

        // Видалити подію
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var eventToDelete = await _context.CalendarEvents.FindAsync(id);
            if (eventToDelete == null)
                return NotFound("Подія не знайдена.");

            _context.CalendarEvents.Remove(eventToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
