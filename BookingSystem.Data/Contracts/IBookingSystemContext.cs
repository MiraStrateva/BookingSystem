using BookingSystem.Data.Models;
using System.Data.Entity;

namespace BookingSystem.Data.Contracts
{
    public interface IBookingSystemContext
    {
        IDbSet<Booking> Bookings { get; }

        IDbSet<Category> Categories { get; }

        IDbSet<Company> Companies { get; }

        IDbSet<Workingtime> Workingtimes { get; }

        int SaveChanges();
    }
}
