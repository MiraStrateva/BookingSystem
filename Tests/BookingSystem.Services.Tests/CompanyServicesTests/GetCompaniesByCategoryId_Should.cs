using BookingSystem.Data.Contracts;
using BookingSystem.Data.Models;
using BookingSystem.Services.Tests.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Services.Tests.CompanyServicesTests
{
    [TestFixture]
    public class GetCompaniesByCategoryId_Should
    {
        [Test]
        public void ReturnNull_WhenNullCategoryIdPassed()
        {
            // Arrange
            var contextMock = new Mock<IBookingSystemContext>();
            CompanyService companyService = new CompanyService(contextMock.Object);

            // Act
            var result = companyService.GetCompaniesByCategoryId(null);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void ReturnCorrectResults_WhenCategoryIdMatches()
        {
            // Arange
            var contextMock = new Mock<IBookingSystemContext>();
            Guid[] categoryIds = new Guid[2];
            Guid testCategoryId = Guid.NewGuid();

            categoryIds[0] = testCategoryId;
            categoryIds[1] = Guid.NewGuid();

            IEnumerable<Company> companies = GetCompanies(categoryIds);

            var expectedCompanyResultSet = companies.Where(c => c.CategoryId.Equals(testCategoryId)).AsQueryable();

            var companySetMock = QueryableDbSetMock.GetQueryableMockDbSet(companies);
            contextMock.Setup(c => c.Companies).Returns(companySetMock);

            CompanyService companyService = new CompanyService(contextMock.Object);

            // Act
            IQueryable<Company> resultSet = companyService.GetCompaniesByCategoryId(testCategoryId);

            // Assert
            CollectionAssert.AreEqual(expectedCompanyResultSet, resultSet);
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
