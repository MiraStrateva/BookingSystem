using BookingSystem.Data.Contracts;
using BookingSystem.Data.Models;
using BookingSystem.Services.Tests.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.Services.Tests.CategoryServiceTests
{
    [TestFixture]
    public class GetAllCategories_Should
    {
        [Test]
        public void ReturnAllCategoriesFromDbSetOrderedByCategoryId_WhenCalled()
        {
            // Arrange
            var contextMock = new Mock<IBookingSystemContext>();
            IEnumerable<Category> categories = GetCategories();
            var expectedCategoryResultSet = categories.OrderBy(c => c.CategoryId).AsQueryable();

            var categorySetMock = QueryableDbSetMock.GetQueryableMockDbSet(categories);
            contextMock.Setup(c => c.Categories).Returns(categorySetMock);

            CategoryService categoryService = new CategoryService(contextMock.Object);

            // Act
            var categoryResultSet = categoryService.GetAllCategories();

            // Assert
            CollectionAssert.AreEqual(expectedCategoryResultSet, categoryResultSet);
        }

        private IEnumerable<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            
            for (int i = 1; i < 4; i++)
            {
                categories.Add(new Category()
                {
                    CategoryId = Guid.NewGuid(),
                    CategoryName = "Name " + i,
                    CategoryDescription = "Description " + i
                });
            }

            return categories;
        }
    }
}
