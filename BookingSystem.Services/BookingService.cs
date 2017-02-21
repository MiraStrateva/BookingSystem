using BookingSystem.Services.Contracts;
using System;
using System.Linq;
using BookingSystem.Data.Models;
using BookingSystem.Data.Contracts;

namespace BookingSystem.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingSystemContext BookingSystemContext;

        public BookingService(IBookingSystemContext bookingSystemContext)
        {
            this.BookingSystemContext = bookingSystemContext;
        }

        public IQueryable<Booking> GetAllBookings()
        {
            return this.BookingSystemContext.Bookings;
        }

        public IQueryable<Booking> GetBookingByCompanyId(Guid companyId)
        {
            return this.BookingSystemContext.Bookings.Where(b => b.CompanyId == companyId);
        }

        public Booking GetBookingById(Guid id)
        {
            return this.BookingSystemContext.Bookings.Find(id);
        }

        public IQueryable<Booking> GetBookingByUserId(string userId)
        {
            return this.BookingSystemContext.Bookings.Where(b => b.UserId == userId);
        }
    }
}
