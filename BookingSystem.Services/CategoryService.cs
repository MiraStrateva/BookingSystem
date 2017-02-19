using BookingSystem.Services.Contracts;
using System.Linq;
using BookingSystem.Data.Models;
using BookingSystem.Data.Contracts;
using System;
using System.Data.Entity;

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
            return this.BookingSystemContext.Categories.OrderBy(c => c.CategoryId);
        }

        public string GetCategoryNameById(Guid? categoryId)
        {
            return categoryId.HasValue ?
                this.BookingSystemContext.Categories.Find(categoryId).CategoryName :
                string.Empty;
        }

        public int InsertCategory(Category category)
        {
            this.BookingSystemContext.Categories.Add(category);
            return this.BookingSystemContext.SaveChanges();
        }


        public int DeleteCategory(Guid? categoryId)
        {
            if (categoryId.HasValue)
            {
                Category item = this.BookingSystemContext.Categories.Find(categoryId);
                this.BookingSystemContext.Categories.Remove(item);
                return this.BookingSystemContext.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public int UpdateCategory(Category category)
        {
            var entry = this.BookingSystemContext.Entry(category);
            entry.State = EntityState.Modified;

            return this.BookingSystemContext.SaveChanges();
        }

        public Category GetById(Guid? categoryId)
        {
            return this.BookingSystemContext.Categories.Find(categoryId);
        }
    }
}
