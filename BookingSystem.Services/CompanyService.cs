using BookingSystem.Services.Contracts;
using System;
using System.Linq;
using BookingSystem.Data.Models;
using BookingSystem.Data.Contracts;

namespace BookingSystem.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IBookingSystemContext BookingSystemContext;

        public CompanyService(IBookingSystemContext bookingSystemContext)
        {
            this.BookingSystemContext = bookingSystemContext;
        }

        public IQueryable<Company> GetAllCompanies()
        {
            return this.BookingSystemContext.Companies;
        }

        public IQueryable<Company> GetCompaniesByCategoryId(Guid? categoryId)
        {
            return categoryId.HasValue ?
                this.BookingSystemContext.Companies.Where(c => c.CategoryId == categoryId) :
                null;
        }

        public IQueryable<Company> GetCompaniesByCategoryIdNameAndDescription(Guid? categoryId, string searchText)
        {
            return GetCompaniesByCategoryId(categoryId)
                        .Where((c => string.IsNullOrEmpty(c.CompanyName) ? false : c.CompanyName.ToLower().Contains(searchText)) ||
                        (string.IsNullOrEmpty(c.CompanyDescription) ? false : c.CompanyDescription.ToLower().Contains(searchText)));
        }

        public IQueryable<Company> GetCompaniesLastAdded(int count)
        {
            throw new NotImplementedException();
        }

        public Company GetCompanyById(Guid? id)
        {
            return id.HasValue ? this.BookingSystemContext.Companies.Find(id) : null;
        }

        public Company GetCompanyByUserId(string userId)
        {
            return this.BookingSystemContext.Companies.FirstOrDefault(c => c.UserId == userId);
        }
    }
}
