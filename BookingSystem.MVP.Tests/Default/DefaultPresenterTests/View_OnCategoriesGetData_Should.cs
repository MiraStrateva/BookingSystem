using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using BookingSystem.MVP.Default;
using BookingSystem.Services.Contracts;
using BookingSystem.Data.Models;

namespace BookingSystem.MVP.Tests.Default.DefaultPresenterTests
{
    [TestFixture]
    public class View_OnCategoriesGetData_Should
    {
        [Test]
        public void AddCategoriesToViewModel_WhenOnCategoriesGetDataEventIsRaised()
        {
            // Arrange
            var viewMock = new Mock<IDefaultView>();
            viewMock.Setup(v => v.Model).Returns(new DefaultViewModel());
            var categories = GetCategories();
            var categoryServiceMock = new Mock<ICategoryService>();
            categoryServiceMock.Setup(c => c.GetAllCategories())
                .Returns(categories);

            DefaultPresenter defaultPresenter = new DefaultPresenter(viewMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnCategoriesGetData += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEquivalent(categories, viewMock.Object.Model.DefaultCategories);
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
