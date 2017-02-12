namespace BookingSystem.Models
{
    using BookingSystem.Data;
    using System.Collections.Generic;

    public class CategoryViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}