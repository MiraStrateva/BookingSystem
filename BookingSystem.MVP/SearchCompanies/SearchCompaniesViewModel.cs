using BookingSystem.Data.Models;
using System.Linq;

namespace BookingSystem.MVP.SearchCompanies
{
    public class SearchCompaniesViewModel
    {
        public IQueryable<Company> SearchCompanies { get; set; }
    }
}
