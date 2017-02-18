using BookingSystem.Services.Contracts;
using System.Linq;
using BookingSystem.Data.Models;
using BookingSystem.Data.Contracts;
using System;

namespace BookingSystem.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IBookingSystemContext BookingSystemContext;

        public CategoryService(IBookingSystemContext bookingSystemContext)
        {
            this.BookingSystemContext = bookingSystemContext;
        }

        public IQueryable<Category> GetAllCategories()
        {
            return this.BookingSystemContext.Categories;
        }

        public string GetCategoryNameById(Guid? categoryId)
        {
            return categoryId.HasValue ?
                this.BookingSystemContext.Categories.Find(categoryId).CategoryName :
                string.Empty;
        }
    }
}
