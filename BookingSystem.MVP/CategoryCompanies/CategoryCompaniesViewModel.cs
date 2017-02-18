using BookingSystem.Data.Models;
using System.Linq;

namespace BookingSystem.MVP.CategoryCompanies
{
    public class CategoryCompaniesViewModel
    {
        public IQueryable<Company> CategorieCompanies { get; set; }

        public string CategoryName { get; set; }
    }
}