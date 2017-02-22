using BookingSystem.Data.Models;
using BookingSystem.MVP.PickAndBook;
using BookingSystem.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.MVP.Tests.PickAndBook.PickAndBookPresenter
{
    [TestFixture]
    public class View_OnCategoriesGetData_Should
    {
        [Test]
        public void AddCategoriesToViewModel_WhenOnCategoriesGetDataEventIsRaised()
        {
            // Arrange
            var viewMock = new Mock<IPickAndBookView>();
            viewMock.Setup(v => v.Model).Returns(new PickAndBookViewModel());
            var categories = GetCategories();
            var categoryServiceMock = new Mock<ICategoryService>();
            categoryServiceMock.Setup(c => c.GetAllCategoriesWithIncludedCompanies())
                .Returns(categories);

            BookingSystem.MVP.PickAndBook.PickAndBookPresenter pickAndBookPresenter = 
                new BookingSystem.MVP.PickAndBook.PickAndBookPresenter(viewMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnCategoriesGetData += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEquivalent(categories, viewMock.Object.Model.Categories);
        }

        private IQueryable<Category> GetCategories()
        {
            return new List<Category>()
            {
                new Category
                {
                    CategoryId = Guid.NewGuid(),
                    CategoryName = "Category 1",
                    CategoryDescription = "Category Description 1"
                },
                new Category
                {
                    CategoryId = Guid.NewGuid(),
                    CategoryName = "Category 2",
                    CategoryDescription = "Category Description 2"
                }
            }.AsQueryable();
        }
    }
}
