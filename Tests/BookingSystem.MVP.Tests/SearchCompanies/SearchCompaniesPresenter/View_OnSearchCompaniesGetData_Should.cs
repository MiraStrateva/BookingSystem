using BookingSystem.MVP.SearchCompanies;
using BookingSystem.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace BookingSystem.MVP.Tests.SearchCompanies.SearchCompaniesPresenter
{
    [TestFixture]
    public class View_OnSearchCompaniesGetData_Should
    {
        [Test]
        public void SetAllCompaniesToViewModel_WhenCalledWithEmptySearchText()
        {
            // Arrange
            var viewMock = new Mock<ISearchCompaniesView>();
            viewMock.Setup(v => v.Model).Returns(new SearchCompaniesViewModel());
            var companyServiceMock = new Mock<ICompanyService>();
            Guid categoryId = Guid.NewGuid();

            BookingSystem.MVP.SearchCompanies.SearchCompaniesPresenter presenter = 
                new BookingSystem.MVP.SearchCompanies.SearchCompaniesPresenter(
                viewMock.Object, companyServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnSearchCompaniesGetData += null,
                new FormGetSearchCompaniesEventArgs(""));

            // Assert
            companyServiceMock.Verify(c => c.GetAllCompanies(), Times.Once);
        }

        [Test]
        public void SetAllCompaniesToViewModel_WhenCalledWithNullSearchText()
        {
            // Arrange
            var viewMock = new Mock<ISearchCompaniesView>();
            viewMock.Setup(v => v.Model).Returns(new SearchCompaniesViewModel());
            var companyServiceMock = new Mock<ICompanyService>();
            Guid categoryId = Guid.NewGuid();

            BookingSystem.MVP.SearchCompanies.SearchCompaniesPresenter presenter =
                new BookingSystem.MVP.SearchCompanies.SearchCompaniesPresenter(
                viewMock.Object, companyServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnSearchCompaniesGetData += null,
                new FormGetSearchCompaniesEventArgs(null));

            // Assert
            companyServiceMock.Verify(c => c.GetAllCompanies(), Times.Once);
        }

        [Test]
        public void SetFilteredCompaniesToViewModel_WhenCalledWithValidSearchText()
        {
            // Arrange
            var viewMock = new Mock<ISearchCompaniesView>();
            viewMock.Setup(v => v.Model).Returns(new SearchCompaniesViewModel());
            var companyServiceMock = new Mock<ICompanyService>();
            Guid categoryId = Guid.NewGuid();

            BookingSystem.MVP.SearchCompanies.SearchCompaniesPresenter presenter =
                new BookingSystem.MVP.SearchCompanies.SearchCompaniesPresenter(
                viewMock.Object, companyServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnSearchCompaniesGetData += null,
                new FormGetSearchCompaniesEventArgs("search"));

            // Assert
            companyServiceMock.Verify(c => c.GetCompaniesByNameOrDescription("search"), Times.Once);
        }
    }
}
