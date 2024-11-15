using Microsoft.EntityFrameworkCore;
using KalenderApp.Models;
using BCrypt.Net;

namespace KalenderApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Начальное заполнение для таблицы Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Работа", Color = "#FF0000" },
                new Category { Id = 2, Name = "Личное", Color = "#00FF00" },
                new Category { Id = 3, Name = "Семья", Color = "#0000FF" }
            );

            // Начальное заполнение для таблицы Users с зашифрованными паролями
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "admin@example.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("adminpassword"),
                    Timezone = "Europe/Tallinn"
                },
                new User
                {
                    Id = 2,
                    Name = "User",
                    Email = "user@example.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("userpassword"),
                    Timezone = "Europe/Tallinn"
                }
            );

            // Начальное заполнение для таблицы Events
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Title = "Встреча с командой",
                    Description = "Обсуждение проекта",
                    StartDateTime = DateTime.Now.AddDays(1),
                    EndDateTime = DateTime.Now.AddDays(1).AddHours(2),
                    UserId = 1,
                    CategoryId = 1,
                    Recurrence = "none",
                    Timezone = "Europe/Tallinn",
                    Reminder = "email"
                },
                new Event
                {
                    Id = 2,
                    Title = "День рождения",
                    Description = "День рождения друга",
                    StartDateTime = DateTime.Now.AddDays(2),
                    EndDateTime = DateTime.Now.AddDays(2).AddHours(3),
                    UserId = 2,
                    CategoryId = 2,
                    Recurrence = "yearly",
                    Timezone = "Europe/Tallinn",
                    Reminder = "notification"
                }
            );
        }
    }
}
