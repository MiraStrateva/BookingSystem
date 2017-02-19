using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Companies = new HashSet<Company>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CategoryId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string CategoryName { get; set; }

        [Required]
        public string CategoryDescription { get; set; }

        [Required]
        public string CategoryImage { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}