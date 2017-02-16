using System.Data.Entity;

namespace BookingSystem.Data.Contracts
{
    public interface IDbContext
    {
        IDbSet<Booking> Bookings { get; }

        IDbSet<Category> Categories { get; }

        IDbSet<Company> Companies { get; }

        IDbSet<Workingtime> Workingtimes { get; }
    }
}
