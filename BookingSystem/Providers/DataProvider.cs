using BookingSystem.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookingSystem.Data;
using BookingSystem.Data.Contracts;

namespace BookingSystem.Providers
{
    public class DataProvider : IDataProvider
    {
        private readonly IDbContext dbContext;
        public DataProvider(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Booking> GetBookingById(int id)
        {
            return this.dbContext.Bookings.Where(b => b.BookingID == id).ToList();
        }

        public IEnumerable<Booking> GetBookingByUserId(string userId)
        {
            return this.dbContext.Bookings.Where(b => b.UserID == userId).ToList();
        }

        public IEnumerable<Booking> GetBookings()
        {
            return this.dbContext.Bookings.ToList();
        }

        public IEnumerable<Category> GetCategories()
        {
            return this.dbContext.Categories.ToList();
        }

        public IEnumerable<Company> GetCompanies()
        {
            return this.dbContext.Companies.ToList();
        }

        public IEnumerable<Company> GetCompaniesByCategoryId(int categoryId)
        {
            return this.dbContext.Companies.Where(c => c.Service.CategoryID == categoryId).ToList();
        }

        public IEnumerable<Company> GetCompaniesLastAdded(int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> GetCompanyById(int id)
        {
            return this.dbContext.Companies.Where(c => c.CompanyID == id).ToList();
        }

        public IEnumerable<Company> GetCompanyByUserId(string userId)
        {
            return this.dbContext.Companies.Where(c => c.UserID == userId).ToList();
        }

        public IEnumerable<Workingtime> GetWorkingTimeByCompanyId(int companyId)
        {
            return this.dbContext.Workingtimes.Where(w => w.CompanyID == companyId).ToList();
        }
    }
}