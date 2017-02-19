using BookingSystem.Data.Models;
using System;
using System.Linq;

namespace BookingSystem.Services.Contracts
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAllCategories();

        string GetCategoryNameById(Guid? categoryId);

        int InsertCategory(Category category);

        int DeleteCategory(Guid? categoryId);

        int UpdateCategory(Category category);

        Category GetById(Guid? categoryId);
    }
}
