using BookingSystem.Data.Contracts;
using System.Data.Entity;
using BookingSystem.Data.Models;

namespace BookingSystem.Data
{
    public class BookingSystemContext : DbContext, IBookingSystemContext
    {
        public BookingSystemContext()
            :base("DefaultConnection")
        {
        }

        public IDbSet<Booking> Bookings { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Company> Companies { get; set; }

        public IDbSet<Workingtime> Workingtimes { get; set; }
    }
}