using BookingSystem.Data.Contracts;
using BookingSystem.Data.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Data.Entity;

namespace BookingSystem.Services.Tests.CategoryServiceTests
{
    [TestFixture]
    public class GetCategoryNameById_Should
    {
        [Test]
        public void ReturnCorrectCategoryName_WhenValidCategoryIdIsPassed()
        {
            // Arrange
            var contextMock = new Mock<IBookingSystemContext>();
            var categorySetMock = new Mock<IDbSet<Category>>();
            contextMock.Setup(c => c.Categories).Returns(categorySetMock.Object);

            Guid categoryId = Guid.NewGuid();
            string categoryName = "My Category";
            Category category = new Category(){ CategoryId = categoryId, CategoryName = categoryName };

            categorySetMock.Setup(c => c.Find(categoryId)).Returns(category);

            CategoryService categoryService = new CategoryService(contextMock.Object);

            // Act
            string resultCategoryName = categoryService.GetCategoryNameById(categoryId);

            // Assert
            Assert.AreEqual(categoryName, resultCategoryName);
        }

        [Test]
        public void ReturnEmptyCategoryName_WhenNullCategoryIdIsPassed()
        {
            // Arrange
            var contextMock = new Mock<IBookingSystemContext>();
            var categorySetMock = new Mock<IDbSet<Category>>();
            contextMock.Setup(c => c.Categories).Returns(categorySetMock.Object);

            Guid categoryId = Guid.NewGuid();
            string categoryName = "My Category";
            Category category = new Category() { CategoryId = categoryId, CategoryName = categoryName };

            categorySetMock.Setup(c => c.Find(categoryId)).Returns(category);

            CategoryService categoryService = new CategoryService(contextMock.Object);

            // Act
            string resultCategoryName = categoryService.GetCategoryNameById(null);

            // Assert
            Assert.AreEqual(string.Empty, resultCategoryName);
        }

        [Test]
        public void ReturnEmptyCategoryName_WhenCategoryNotFound()
        {
            // Arrange
            var contextMock = new Mock<IBookingSystemContext>();
            var categorySetMock = new Mock<IDbSet<Category>>();
            contextMock.Setup(c => c.Categories).Returns(categorySetMock.Object);

            Guid categoryId = Guid.NewGuid();
            string categoryName = "My Category";
            Category category = new Category() { CategoryId = categoryId, CategoryName = categoryName };

            categorySetMock.Setup(c => c.Find(categoryId)).Returns<Category>(null);

            CategoryService categoryService = new CategoryService(contextMock.Object);

            // Act
            string resultCategoryName = categoryService.GetCategoryNameById(Guid.NewGuid());

            // Assert
            Assert.AreEqual(string.Empty, resultCategoryName);
        }
    }
}
