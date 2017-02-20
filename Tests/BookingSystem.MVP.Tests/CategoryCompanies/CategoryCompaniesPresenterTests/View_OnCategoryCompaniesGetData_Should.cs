using BookingSystem.Data.Models;
using BookingSystem.MVP.CategoryCompanies;
using BookingSystem.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.MVP.Tests.CategoryCompanies.CategoryCompaniesPresenterTests
{
    [TestFixture]
    public class View_OnCategoryCompaniesGetData_Should
    {
        [Test]
        public void CallGetCompaniesByCategoryId_WhenRaisedWithEmptySearchParameter()
        {
            // Arrange
            var viewMock = new Mock<ICategoryCompaniesView>();
            viewMock.Setup(v => v.Model).Returns(new CategoryCompaniesViewModel());
            var companyServiceMock = new Mock<ICompanyService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            Guid categoryId = Guid.NewGuid();

            CategoryCompaniesPresenter presenter = new CategoryCompaniesPresenter(
                viewMock.Object, companyServiceMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnCategoryCompaniesGetData += null, 
                new FormGetCategoryCompaniesEventArgs(categoryId, ""));

            // Assert
            companyServiceMock.Verify(c => c.GetCompaniesByCategoryId(categoryId), Times.Once);
        }

        [Test]
        public void CallGetCompaniesByCategoryIdNameOrDescription_WhenRaisedWithValidSearchParameter()
        {
            // Arrange
            var viewMock = new Mock<ICategoryCompaniesView>();
            viewMock.Setup(v => v.Model).Returns(new CategoryCompaniesViewModel());
            var companyServiceMock = new Mock<ICompanyService>();
            var categoryServiceMock = new Mock<ICategoryService>();

            Guid categoryId = Guid.NewGuid();
            string searchText = "Search";

            CategoryCompaniesPresenter presenter = new CategoryCompaniesPresenter(
                viewMock.Object, companyServiceMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnCategoryCompaniesGetData += null,
                new FormGetCategoryCompaniesEventArgs(categoryId, searchText));

            // Assert
            companyServiceMock.Verify(c => c.GetCompaniesByCategoryIdNameOrDescription(categoryId, searchText.ToLower()), Times.Once);
        }

        [Test]
        public void AddCategoriesToViewModel_WhenOnCategoryCompaniesGetDataEventIsRaisedWithEmptySearchParameter()
        {
            // Arrange
            var viewMock = new Mock<ICategoryCompaniesView>();
            viewMock.Setup(v => v.Model).Returns(new CategoryCompaniesViewModel());
            var companyServiceMock = new Mock<ICompanyService>();
            var categoryServiceMock = new Mock<ICategoryService>();

            Guid[] categoryIds = new Guid[2];
            Guid categoryId = Guid.NewGuid();
            categoryIds[0] = categoryId;
            categoryIds[1] = Guid.NewGuid();
            IQueryable<Company> companies = GetCompanies(categoryIds).AsQueryable();
            IQueryable<Company> expectedResult = companies.Where(c => c.CategoryId == categoryId).AsQueryable();

            companyServiceMock.Setup(c => c.GetCompaniesByCategoryId(categoryId))
                .Returns(expectedResult);

            CategoryCompaniesPresenter presenter = new CategoryCompaniesPresenter(
                viewMock.Object, companyServiceMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnCategoryCompaniesGetData += null,
                new FormGetCategoryCompaniesEventArgs(categoryId, ""));

            // Assert
            CollectionAssert.AreEquivalent(expectedResult, viewMock.Object.Model.CategorieCompanies);
        }

        public void AddCategoriesToViewModel_WhenOnCategoryCompaniesGetDataEventIsRaisedWithValidSearchParameter()
        {
            // Arrange
            var viewMock = new Mock<ICategoryCompaniesView>();
            viewMock.Setup(v => v.Model).Returns(new CategoryCompaniesViewModel());
            var companyServiceMock = new Mock<ICompanyService>();
            var categoryServiceMock = new Mock<ICategoryService>();

            Guid[] categoryIds = new Guid[2];
            Guid categoryId = Guid.NewGuid();
            categoryIds[0] = categoryId;
            categoryIds[1] = Guid.NewGuid();
            string searchText = "Name";
            IQueryable<Company> companies = GetCompanies(categoryIds).AsQueryable();
            IQueryable<Company> expectedResult = companies.Where(c => c.CategoryId == categoryId &&
                        (string.IsNullOrEmpty(c.CompanyName) ? false : c.CompanyName.ToLower().Contains(searchText)) ||
                        (string.IsNullOrEmpty(c.CompanyDescription) ? false : c.CompanyDescription.ToLower().Contains(searchText))).AsQueryable();

            companyServiceMock.Setup(c => c.GetCompaniesByCategoryIdNameOrDescription(categoryId, searchText))
                .Returns(expectedResult);

            CategoryCompaniesPresenter presenter = new CategoryCompaniesPresenter(
                viewMock.Object, companyServiceMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnCategoryCompaniesGetData += null,
                new FormGetCategoryCompaniesEventArgs(categoryId, searchText));

            // Assert
            CollectionAssert.AreEquivalent(expectedResult, viewMock.Object.Model.CategorieCompanies);
        }

        [Test]
        public void AddCategoryNameToViewModel_WhenOnCategoryCompaniesGetDataEventIsRaised()
        {
            // Arrange
            var viewMock = new Mock<ICategoryCompaniesView>();
            viewMock.Setup(v => v.Model).Returns(new CategoryCompaniesViewModel());
            var companyServiceMock = new Mock<ICompanyService>();
            var categoryServiceMock = new Mock<ICategoryService>();

            Guid categoryId = Guid.NewGuid();
            string categoryName = "Category1"; 
            
            categoryServiceMock.Setup(c => c.GetCategoryNameById(categoryId))
                .Returns(categoryName);

            CategoryCompaniesPresenter presenter = new CategoryCompaniesPresenter(
                viewMock.Object, companyServiceMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnCategoryCompaniesGetData += null,
                new FormGetCategoryCompaniesEventArgs(categoryId, ""));

            // Assert
            categoryServiceMock.Verify(c => c.GetCategoryNameById(categoryId), Times.Once);
            Assert.AreEqual(categoryName, viewMock.Object.Model.CategoryName);
        }

        private IEnumerable<Company> GetCompanies(Guid[] categoryIds)
        {
            List<Company> companies = new List<Company>();
            int index = 1;

            foreach (Guid categoryId in categoryIds)
            {
                for (int i = index; i < index + 3; i++)
                {
                    companies.Add(new Company()
                    {
                        CompanyId = Guid.NewGuid(),
                        CompanyName = "Name " + i,
                        CompanyDescription = "Description " + i,
                        CategoryId = categoryId
                    });
                }
                index += 3;
            }

            return companies;
        }
    }
}
