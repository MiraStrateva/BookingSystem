namespace BookingSystem.Data
{
    using BookingSystem.Data.Contracts;
    using System.Data.Entity;

    public class BookingSystemDbContext : BookingSystemEntities, IDbContext
    {
        IDbSet<Booking> IDbContext.Bookings
        {
            get
            {
                return base.Bookings;
            }
        }

        IDbSet<Category> IDbContext.Categories
        {
            get
            {
                return base.Categories;
            }
        }

        IDbSet<Company> IDbContext.Companies
        {
            get
            {
                return base.Companies;
            }
        }

        IDbSet<Workingtime> IDbContext.Workingtimes
        {
            get
            {
                return base.Workingtimes;
            }
        }
    }
}