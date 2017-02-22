using BookingSystem.Data.Models;
using BookingSystem.MVP.RegisterCompany;
using BookingSystem.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.ModelBinding;

namespace BookingSystem.MVP.Tests.RegisterCompany.RegisterCompanyPresenter
{
    [TestFixture]
    public class View_OnUpdateCompany_Should
    {
        [Test]
        public void CallInsertCompany_WhenCompanyForLoggedUserIsNotFound()
        {
            // Arrange
            string userId = Guid.NewGuid().ToString();
            var identity = new GenericIdentity(userId, "");
            var nameIdentifierClaim = new Claim(ClaimTypes.NameIdentifier, userId);
            identity.AddClaim(nameIdentifierClaim);
            var userMock = new Mock<IPrincipal>();
            userMock.Setup(x => x.Identity).Returns(identity);
            userMock.Setup(x => x.IsInRole("Company")).Returns(true);
            userMock.Setup(x => x.IsInRole("Client")).Returns(false);

            var viewMock = new Mock<IRegisterCompanyView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            viewMock.Setup(v => v.User).Returns(userMock.Object);

            Guid companyId = Guid.NewGuid();
            var categoryServiceMock = new Mock<ICategoryService>();
            var companyServiceMock = new Mock<ICompanyService>();
            companyServiceMock.Setup(c => c.GetById(companyId))
                .Returns<Company>(null);

            BookingSystem.MVP.RegisterCompany.RegisterCompanyPresenter registerCompanyPresenter =
                new BookingSystem.MVP.RegisterCompany.RegisterCompanyPresenter(viewMock.Object,
                companyServiceMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnUpdateCompany += null, new CompanyIdEventArgs(companyId));

            // Assert
            viewMock.Verify(v => v.TryUpdateModel(It.IsAny<Company>()), Times.Once());
            companyServiceMock.Verify(v => v.InsertCompany(It.IsAny<Company>()), Times.Once);
            companyServiceMock.Verify(v => v.UpdateCompany(It.IsAny<Company>()), Times.Never);
        }

        [Test]
        public void CallUpdateCompany_WhenCompanyForLoggedUserIsFound()
        {
            // Arrange
            string userId = Guid.NewGuid().ToString();
            var identity = new GenericIdentity(userId, "");
            var nameIdentifierClaim = new Claim(ClaimTypes.NameIdentifier, userId);
            identity.AddClaim(nameIdentifierClaim);
            var userMock = new Mock<IPrincipal>();
            userMock.Setup(x => x.Identity).Returns(identity);
            userMock.Setup(x => x.IsInRole("Company")).Returns(true);
            userMock.Setup(x => x.IsInRole("Client")).Returns(false);

            var viewMock = new Mock<IRegisterCompanyView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            viewMock.Setup(v => v.User).Returns(userMock.Object);

            Guid companyId = Guid.NewGuid();
            var categoryServiceMock = new Mock<ICategoryService>();
            var companyServiceMock = new Mock<ICompanyService>();
            companyServiceMock.Setup(c => c.GetById(companyId))
                .Returns(new Company() { CompanyId = companyId, UserId = userId, CompanyName = "Company 1" });

            BookingSystem.MVP.RegisterCompany.RegisterCompanyPresenter registerCompanyPresenter =
                new BookingSystem.MVP.RegisterCompany.RegisterCompanyPresenter(viewMock.Object,
                companyServiceMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnUpdateCompany += null, new CompanyIdEventArgs(companyId));

            // Assert
            viewMock.Verify(v => v.TryUpdateModel(It.IsAny<Company>()), Times.Once());
            companyServiceMock.Verify(v => v.InsertCompany(It.IsAny<Company>()), Times.Never);
            companyServiceMock.Verify(v => v.UpdateCompany(It.IsAny<Company>()), Times.Once);
        }
    }
}
