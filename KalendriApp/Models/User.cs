// Models/User.cs
using System.ComponentModel.DataAnnotations;

namespace KalenderApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Timezone { get; set; } // Исправление: добавлено свойство Timezone
    }
}
