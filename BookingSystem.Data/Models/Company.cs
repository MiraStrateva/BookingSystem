using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Data.Models
{
    public class Company
    {
        public Company()
        {
            this.Workingtimes = new HashSet<Workingtime>();
            this.Bookings = new HashSet<Booking>();
        }

        public Guid CompanyId { get; set; }

        [Required]
        [Index(IsUnique=true)]
        [MaxLength(50)]
        public string CompanyName { get; set; }

        public string CompanyDescription { get; set; }

        [Required]
        [MaxLength(50)] 
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string ContactName { get; set; }

        public string CompanyImage { get; set; }

        public string CompanyWebsite { get; set; }

        public bool IsActive { get; set; }

        [MaxLength(128)]
        public string UserId { get; set; }

        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Workingtime> Workingtimes { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}