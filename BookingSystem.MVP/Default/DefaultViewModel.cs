using BookingSystem.Data.Models;
using System.Linq;

namespace BookingSystem.MVP.Default
{
    public class DefaultViewModel
    {
        public IQueryable<Category> DefaultCategories { get; set; }
    }
}
