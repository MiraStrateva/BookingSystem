using BookingSystem.Services.Contracts;
using System;
using System.Linq;
using BookingSystem.Data.Models;
using BookingSystem.Data.Contracts;
using System.Data.Entity;

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

        public IQueryable<Company> GetCompaniesByCategoryIdNameOrDescription(Guid? categoryId, string searchText)
        {
            return GetCompaniesByCategoryId(categoryId)
                        .Where(c => (string.IsNullOrEmpty(c.CompanyName) ? false : c.CompanyName.ToLower().Contains(searchText)) ||
                        (string.IsNullOrEmpty(c.CompanyDescription) ? false : c.CompanyDescription.ToLower().Contains(searchText)));
        }
        
        public Company GetById(Guid? id)
        {
            return id.HasValue ? this.BookingSystemContext.Companies.Find(id) : null;
        }

        public Company GetCompanyByUserId(string userId)
        {
            return this.BookingSystemContext.Companies.FirstOrDefault(c => c.UserId == userId);
        }

        public IQueryable<Company> GetCompaniesByNameOrDescription(string searchText)
        {
            return GetAllCompanies()
                        .Where(c => (string.IsNullOrEmpty(c.CompanyName) ? false : c.CompanyName.ToLower().Contains(searchText)) ||
                        (string.IsNullOrEmpty(c.CompanyDescription) ? false : c.CompanyDescription.ToLower().Contains(searchText)));
        }

        public int UpdateCompany(Company company)
        {
            var entry = this.BookingSystemContext.Entry(company);
            entry.State = EntityState.Modified;

            return this.BookingSystemContext.SaveChanges();
        }

        public int InsertCompany(Company company)
        {
            this.BookingSystemContext.Companies.Add(company);
            return this.BookingSystemContext.SaveChanges();
        }
    }
}
