namespace BookingSystem.Data
{
    using BookingSystem.Data.Contracts;
    using System.Data.Entity;

    public class BookingSystemDbContext : BookingSystemDataEntities, IDbContext
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

        IDbSet<Service> IDbContext.Services
        {
            get
            {
                return base.Services;
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