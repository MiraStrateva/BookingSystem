using System;
using NUnit.Framework;
using Moq;
using BookingSystem.Data.Contracts;
using BookingSystem.Data.Models;
using System.Data.Entity;

namespace BookingSystem.Services.Tests.CompanyServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnNull_WhenIdParameterIsNull()
        {
            // Arange
            var contextMock = new Mock<IBookingSystemContext>();
            CompanyService companyService = new CompanyService(contextMock.Object);

            // Act
            Company companyResult = companyService.GetById(null);

            // Assert
            Assert.IsNull(companyResult);
        }

        [Test]
        public void ReturnCompany_WhenIdIsValid()
        {
            // Arange
            var contextMock = new Mock<IBookingSystemContext>();
            var companySetMock = new Mock<IDbSet<Company>>();
            contextMock.Setup(c => c.Companies).Returns(companySetMock.Object);
            Guid companyId = Guid.NewGuid();
            Company company = new Company() { CompanyId = companyId, CompanyName = "Company 1" };

            companySetMock.Setup(c => c.Find(companyId)).Returns(company);

            CompanyService companyService = new CompanyService(contextMock.Object);

            // Act
            Company companyResult = companyService.GetById(companyId);

            // Assert
            Assert.AreSame(company, companyResult);
        }
    }
}
