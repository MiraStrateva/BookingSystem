using BookingSystem.Data.Models;
using System;
using System.Linq;

namespace BookingSystem.Services.Contracts
{
    public interface ICompanyService
    {
        IQueryable<Company> GetAllCompanies();

        IQueryable<Company> GetCompaniesByCategoryId(Guid? categoryId);

        IQueryable<Company> GetCompaniesByCategoryIdNameAndDescription(Guid? categoryId, string searchText);

        IQueryable<Company> GetCompaniesLastAdded(int count);

        Company GetCompanyById(Guid? id);

        Company GetCompanyByUserId(string userId);
    }
}
