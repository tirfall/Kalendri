// Models/Event.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KalenderApp.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public string Recurrence { get; set; }

        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public string Timezone { get; set; } // Lisatud Timezone

        public string Reminder { get; set; }
    }
}
