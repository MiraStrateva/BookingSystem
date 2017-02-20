using System;
using NUnit.Framework;
using Moq;
using BookingSystem.Data.Contracts;
using BookingSystem.Data.Models;
using System.Data.Entity;

namespace BookingSystem.Services.Tests.CategoryServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnNull_WhenIdParameterIsNull()
        {
            // Arange
            var contextMock = new Mock<IBookingSystemContext>();
            CategoryService categoryService = new CategoryService(contextMock.Object);

            // Act
            Category categoryResult = categoryService.GetById(null);

            // Assert
            Assert.IsNull(categoryResult);
        }

        [Test]
        public void ReturnCategory_WhenIdIsValid()
        {
            // Arange
            var contextMock = new Mock<IBookingSystemContext>();
            var categorySetMock = new Mock<IDbSet<Category>>();
            contextMock.Setup(c => c.Categories).Returns(categorySetMock.Object);
            Guid categoryId = Guid.NewGuid();
            Category category = new Category() { CategoryId = categoryId, CategoryName = "Category 1" };

            categorySetMock.Setup(c => c.Find(categoryId)).Returns(category);

            CategoryService categoryService = new CategoryService(contextMock.Object);

            // Act
            Category categoryResult = categoryService.GetById(categoryId);

            // Assert
            Assert.AreSame(category, categoryResult);
        }
    }
}
