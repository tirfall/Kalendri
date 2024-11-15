// Controllers/EventController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KalenderApp.Data;
using KalenderApp.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KalenderApp.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Event/Index
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Account");

            var events = await _context.Events
                .Include(e => e.Category)
                .Where(e => e.UserId == userId)
                .ToListAsync();

            return View(events);
        }

        // GET: /Event/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Event/Create
        [HttpPost]
        public async Task<IActionResult> Create(Event newEvent)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Account");

            // Setting user and default values if not filled
            newEvent.UserId = userId.Value;
            newEvent.Timezone ??= "Europe/Tallinn";
            newEvent.Recurrence ??= "none";
            newEvent.Reminder ??= "none";

            _context.Add(newEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, string lang = "et")
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Account");

            var @event = await _context.Events.FindAsync(id);
            if (@event == null || @event.UserId != userId)
            {
                return NotFound();
            }

            // Set language culture if needed
            CultureInfo newCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;
            ViewBag.Language = lang;

            return View(@event);
        }

        // POST: /Event/DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Account");

            var @event = await _context.Events.FindAsync(id);
            if (@event != null && @event.UserId == userId)
            {
                _context.Events.Remove(@event);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        // GET: /Event/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(int id, string lang = "et")
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Account");

            var @event = await _context.Events.FindAsync(id);
            if (@event == null || @event.UserId != userId)
            {
                return NotFound();
            }

            // Set language culture if needed
            CultureInfo newCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;
            ViewBag.Language = lang;

            ViewBag.Categories = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
            return View(@event);
        }

        // POST: /Event/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Event @event)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Account");

            if (@event.UserId != userId) return Unauthorized();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _context.Events.AnyAsync(e => e.Id == @event.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
            return View(@event);
        }
    }
}
