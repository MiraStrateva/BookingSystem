using BookingSystem.Data.Contracts;
using BookingSystem.Data.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;
using BookingSystem.Services.Tests.Mocks;

namespace BookingSystem.Services.Tests.CompanyServicesTests
{
    [TestFixture]
    public class GetCompaniesByCategoryIdNameOrDescription_Should
    {
        [Test]
        public void RerurnCorrectResults_WhenTitleMatches()
        {
            // Arrange
            var contextMock = new Mock<IBookingSystemContext>();
            Guid[] categoryIds = new Guid[2];
            Guid testCategoryId = Guid.NewGuid();

            categoryIds[0] = testCategoryId;
            categoryIds[1] = Guid.NewGuid();

            IEnumerable<Company> companies = GetCompanies(categoryIds);
            string searchTerm = "Name";
            var expectedCompanyResultSet = companies.Where(c => c.CategoryId.Equals(testCategoryId) && 
                                c.CompanyName.ToLower().Contains(searchTerm)).AsQueryable();
                                        
            var companySetMock = QueryableDbSetMock.GetQueryableMockDbSet(companies);
            contextMock.Setup(c => c.Companies).Returns(companySetMock);

            CompanyService companyService = new CompanyService(contextMock.Object);

            // Act
            var companyResultSet = companyService.GetCompaniesByCategoryIdNameOrDescription(testCategoryId, searchTerm);

            // Assert
            CollectionAssert.AreEquivalent(expectedCompanyResultSet, companyResultSet);
        }

        [Test]
        public void RerurnCorrectResults_WhenDescriptionMatches()
        {
            // Arrange
            var contextMock = new Mock<IBookingSystemContext>();
            Guid[] categoryIds = new Guid[2];
            Guid testCategoryId = Guid.NewGuid();

            categoryIds[0] = testCategoryId;
            categoryIds[1] = Guid.NewGuid();

            IEnumerable<Company> companies = GetCompanies(categoryIds);
            string searchTerm = "desCription 1";
            var expectedCompanyResultSet = companies.Where(c => c.CategoryId.Equals(testCategoryId) &&
                                c.CompanyDescription.ToLower().Contains(searchTerm)).AsQueryable();

            var companySetMock = QueryableDbSetMock.GetQueryableMockDbSet(companies);
            contextMock.Setup(c => c.Companies).Returns(companySetMock);

            CompanyService companyService = new CompanyService(contextMock.Object);

            // Act
            var companyResultSet = companyService.GetCompaniesByCategoryIdNameOrDescription(testCategoryId, searchTerm);

            // Assert
            CollectionAssert.AreEquivalent(expectedCompanyResultSet, companyResultSet);
        }

        private IEnumerable<Company> GetCompanies(Guid[] categoryIds)
        {
            List<Company> companies = new List<Company>();
            int index = 1;

            foreach (Guid categoryId in categoryIds)
            {
                for (int i = index; i < index + 3; i++)
                {
                    companies.Add(new Company() { CompanyId = Guid.NewGuid(),
                        CompanyName = "Name " + i,
                        CompanyDescription = "Description " + i,
                        CategoryId = categoryId });
                }
                index += 3; 
            }

            return companies;
        }
    }
}
