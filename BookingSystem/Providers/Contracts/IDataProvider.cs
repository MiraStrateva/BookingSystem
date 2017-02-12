namespace BookingSystem.Providers.Contracts
{
    using BookingSystem.Data;
    using System.Collections.Generic;

    public interface IDataProvider
    {
        IEnumerable<Booking> GetBookingById(int id);

        IEnumerable<Booking> GetBookingByUserId(string userId);

        IEnumerable<Booking> GetBookings();

        IEnumerable<Category> GetCategories();

        IEnumerable<Company> GetCompanies();

        IEnumerable<Company> GetCompaniesByCategoryId(int categoryId);

        IEnumerable<Company> GetCompaniesLastAdded(int count);

        IEnumerable<Company> GetCompanyById(int id);

        IEnumerable<Company> GetCompanyByUserId(string userId);

        IEnumerable<Workingtime> GetWorkingTimeByCompanyId(int companyId);
    }
}
