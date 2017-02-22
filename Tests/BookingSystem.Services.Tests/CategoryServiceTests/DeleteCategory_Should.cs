using BookingSystem.Data.Contracts;
using BookingSystem.Data.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Data.Entity;

namespace BookingSystem.Services.Tests.CategoryServiceTests
{
    [TestFixture]
    public class DeleteCategory_Should
    {
        [Test]
        public void ReturnZero_WhenCalledWithNoExistingGuid()
        {
            // Arange
            var contextMock = new Mock<IBookingSystemContext>();
            var categorySetMock = new Mock<IDbSet<Category>>();
            contextMock.Setup(c => c.Categories).Returns(categorySetMock.Object);
            CategoryService categoryService = new CategoryService(contextMock.Object);

            // Act
            var result = categoryService.DeleteCategory(Guid.NewGuid());

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ReturnZero_WhenCalledWithNull()
        {
            // Arange
            var contextMock = new Mock<IBookingSystemContext>();
            var categorySetMock = new Mock<IDbSet<Category>>();
            contextMock.Setup(c => c.Categories).Returns(categorySetMock.Object);
            CategoryService categoryService = new CategoryService(contextMock.Object);

            // Act
            var result = categoryService.DeleteCategory(null);

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}
