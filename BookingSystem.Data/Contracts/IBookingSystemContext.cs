using BookingSystem.Data.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BookingSystem.Data.Contracts
{
    public interface IBookingSystemContext : IBookingSystemBaseContext
    {
        DbEntityEntry Entry(object entity);

        IDbSet<Booking> Bookings { get; }

        IDbSet<Category> Categories { get; }

        IDbSet<Company> Companies { get; }

        IDbSet<Workingtime> Workingtimes { get; }
    }
}
