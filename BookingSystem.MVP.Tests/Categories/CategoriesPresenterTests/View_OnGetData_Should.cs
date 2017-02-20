using BookingSystem.Data.Models;
using BookingSystem.MVP.Categories;
using BookingSystem.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.MVP.Tests.Categories.CategoriesPresenterTests
{
    [TestFixture]
    public class View_OnGetData_Should
    {
        [Test]
        public void AddCategoriesToViewModel_WhenOnGetDataEventIsRaised()
        {
            // Arrange
            var viewMock = new Mock<ICategoriesView>();
            viewMock.Setup(v => v.Model).Returns(new CategoriesViewModel());
            var categories = GetCategories();
            var categoryServiceMock = new Mock<ICategoryService>();
            categoryServiceMock.Setup(c => c.GetAllCategories())
                .Returns(categories);

            CategoriesPresenter categoriesPresenter = new CategoriesPresenter(viewMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnGetData += null, EventArgs.Empty);

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
