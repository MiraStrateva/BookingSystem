using BookingSystem.Services.Contracts;
using System;
using System.Linq;
using BookingSystem.Data.Models;
using BookingSystem.Data.Contracts;

namespace BookingSystem.Services
{
    public class WorkingtimeService : IWorkingtimeService
    {
        private readonly IBookingSystemContext BookingSystemContext;

        public WorkingtimeService(IBookingSystemContext bookingSystemContext)
        {
            this.BookingSystemContext = bookingSystemContext;
        }

        public Workingtime GetWorkingtimeByCompanyId(Guid companyId)
        {
            return this.BookingSystemContext.Workingtimes.FirstOrDefault(w => w.CompanyId == companyId);
        }

        public Workingtime GetWorkingtimeById(Guid id)
        {
            return this.BookingSystemContext.Workingtimes.FirstOrDefault(w => w.WorkingtimeId == id);
        }
    }
}
