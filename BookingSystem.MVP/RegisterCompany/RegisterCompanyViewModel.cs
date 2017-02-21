using BookingSystem.Data.Models;
using System.Linq;

namespace BookingSystem.MVP.RegisterCompany
{
    public class RegisterCompanyViewModel
    {
        public Company UserCompany { get; set; }
        public IQueryable<Category> Categories { get; set; }
    }
}
