// Controllers/AccountController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using KalenderApp.Data;
using KalenderApp.Models;
using System.Threading.Tasks;

namespace KalenderApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ApplicationDbContext context, ILogger<AccountController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                // Save UserId in session if the password is verified
                HttpContext.Session.SetInt32("UserId", user.Id);
                return RedirectToAction("Index", "Event");
            }

            // Incorrect credentials
            ViewBag.ErrorMessage = "Неверный email или пароль.";
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        // POST: /Account/Register
      
        public async Task<IActionResult> Register(User newUser)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Vigane vormi sisend.";
                return View(newUser);
            }

            // Устанавливаем таймзону по умолчанию, если она не была указана
            newUser.Timezone ??= "Europe/Tallinn";

            // Проверка наличия пользователя с таким же email
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == newUser.Email);
            if (existingUser != null)
            {
                ViewBag.ErrorMessage = "Kasutaja selle e-posti aadressiga on juba olemas.";
                return View(newUser);
            }

            // Хешируем пароль перед сохранением
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            // Устанавливаем сессию для нового пользователя
            HttpContext.Session.SetInt32("UserId", newUser.Id);
            return RedirectToAction("Index", "Event");
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear session
            return RedirectToAction("Login");
        }
    }
}
