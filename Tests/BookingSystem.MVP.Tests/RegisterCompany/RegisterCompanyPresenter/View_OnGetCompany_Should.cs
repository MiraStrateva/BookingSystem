using BookingSystem.Data.Models;
using BookingSystem.MVP.RegisterCompany;
using BookingSystem.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Security.Claims;
using System.Security.Principal;

namespace BookingSystem.MVP.Tests.RegisterCompany.RegisterCompanyPresenter
{
    [TestFixture]
    public class View_OnGetCompany_Should
    {
        [Test]
        public void SetNewCompanyInViewModel_WhenNoCompanyFoundForLoggedUser()
        {
            // Arrange
            string userId = Guid.NewGuid().ToString();
            var identity = new GenericIdentity(userId, "");
            var nameIdentifierClaim = new Claim(ClaimTypes.NameIdentifier, userId);
            identity.AddClaim(nameIdentifierClaim);
            var userMock = new Mock<IPrincipal>();
            userMock.Setup(x => x.Identity).Returns(identity);

            var viewMock = new Mock<IRegisterCompanyView>();
            viewMock.Setup(v => v.Model).Returns(new RegisterCompanyViewModel());
            viewMock.Setup(v => v.User).Returns(userMock.Object);

            var categoryServiceMock = new Mock<ICategoryService>();
            var companyServiceMock = new Mock<ICompanyService>();
            companyServiceMock.Setup(c => c.GetCompanyByUserId(userId))
                .Returns<Company>(null);

            BookingSystem.MVP.RegisterCompany.RegisterCompanyPresenter registerCompanyPresenter =
                new BookingSystem.MVP.RegisterCompany.RegisterCompanyPresenter(viewMock.Object, 
                companyServiceMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnGetCompany += null, EventArgs.Empty);

            // Assert
            Assert.AreEqual(Guid.Empty, viewMock.Object.Model.UserCompany.CompanyId);
        }

        [Test]
        public void SetCorrectUserCompanyInViewModel_WhenExistsCompanyForLoggedUser()
        {
            // Arrange
            string userId = Guid.NewGuid().ToString();
            var identity = new GenericIdentity(userId, "");
            var nameIdentifierClaim = new Claim(ClaimTypes.NameIdentifier, userId);
            identity.AddClaim(nameIdentifierClaim);
            var userMock = new Mock<IPrincipal>();
            userMock.Setup(x => x.Identity).Returns(identity);

            var viewMock = new Mock<IRegisterCompanyView>();
            viewMock.Setup(v => v.Model).Returns(new RegisterCompanyViewModel());
            viewMock.Setup(v => v.User).Returns(userMock.Object);

            var categoryServiceMock = new Mock<ICategoryService>();
            var companyServiceMock = new Mock<ICompanyService>();
            Guid companyId = Guid.NewGuid();
            Company userCompany = new Company() { UserId = userId, CompanyId = companyId };
            companyServiceMock.Setup(c => c.GetCompanyByUserId(userId))
                .Returns(userCompany);

            BookingSystem.MVP.RegisterCompany.RegisterCompanyPresenter registerCompanyPresenter =
                new BookingSystem.MVP.RegisterCompany.RegisterCompanyPresenter(viewMock.Object,
                companyServiceMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnGetCompany += null, EventArgs.Empty);

            // Assert
            Assert.AreEqual(companyId, viewMock.Object.Model.UserCompany.CompanyId);
        }
    }
}
