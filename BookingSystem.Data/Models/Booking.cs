using System;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Data.Models
{
    public class Booking
    {
        public Guid BookingId { get; set; }

        [MaxLength(128)]
        public string UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public String ClientName { get; set; }

        [Required]
        [MaxLength(20)]
        public String ClientPhone { get; set; }

        [Required]
        public DateTime StartFrom { get; set; }

        [Required]
        public DateTime EndAt { get; set; }

        public Guid CompanyId { get; set; }

        public Company Company { get; set; }
    }
}