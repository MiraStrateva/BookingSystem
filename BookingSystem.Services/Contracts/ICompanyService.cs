using BookingSystem.Data.Models;
using System;
using System.Linq;

namespace BookingSystem.Services.Contracts
{
    public interface ICompanyService
    {
        IQueryable<Company> GetAllCompanies();

        IQueryable<Company> GetCompaniesByCategoryId(Guid? categoryId);

        IQueryable<Company> GetCompaniesByNameOrDescription(string searchText);

        IQueryable<Company> GetCompaniesByCategoryIdNameOrDescription(Guid? categoryId, string searchText);

        IQueryable<Company> GetCompaniesLastAdded(int count);

        Company GetById(Guid? id);

        Company GetCompanyByUserId(string userId);

        int UpdateCompany(Company company);

        int InsertCompany(Company company);
    }
}
