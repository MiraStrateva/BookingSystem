using BookingSystem.Data.Models;
using BookingSystem.MVP.RegisterCompany;
using BookingSystem.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.MVP.Tests.RegisterCompany.RegisterCompanyPresenter
{
    [TestFixture]
    public class View_OnGetCategories_Should
    {
        [Test]
        public void AddCategoriesToViewModel_WhenOnGetCategoriesEventIsRaised()
        {
            // Arrange
            var viewMock = new Mock<IRegisterCompanyView>();
            viewMock.Setup(v => v.Model).Returns(new RegisterCompanyViewModel());
            var categories = GetCategories();
            var categoryServiceMock = new Mock<ICategoryService>();
            var companyServiceMock = new Mock<ICompanyService>();
            categoryServiceMock.Setup(c => c.GetAllCategories())
                .Returns(categories);

            BookingSystem.MVP.RegisterCompany.RegisterCompanyPresenter registerCompanyPresenter = 
                new BookingSystem.MVP.RegisterCompany.RegisterCompanyPresenter(viewMock.Object, companyServiceMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnGetCategories += null, EventArgs.Empty);

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
