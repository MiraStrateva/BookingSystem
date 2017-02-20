using BookingSystem.Data.Models;
using System.Linq;

namespace BookingSystem.MVP.Categories
{
    public class CategoriesViewModel
    {
        public IQueryable<Category> Categories { get; set; }
    }
}
