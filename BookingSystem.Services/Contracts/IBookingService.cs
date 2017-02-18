using BookingSystem.Data.Models;
using System;
using System.Linq;

namespace BookingSystem.Services.Contracts
{
    public interface IBookingService
    {
        IQueryable<Booking> GetAllBookings();

        Booking GetBookingById(Guid id);

        IQueryable<Booking> GetBookingByUserId(string userId);

        IQueryable<Booking> GetBookingByCompanyId(Guid companyId);
    }
}
