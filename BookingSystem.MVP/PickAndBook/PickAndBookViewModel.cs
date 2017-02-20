using BookingSystem.Data.Models;
using System.Linq;

namespace BookingSystem.MVP.PickAndBook
{
    public class PickAndBookViewModel
    {
        public IQueryable<Category> Categories { get; set; }
    }
}
