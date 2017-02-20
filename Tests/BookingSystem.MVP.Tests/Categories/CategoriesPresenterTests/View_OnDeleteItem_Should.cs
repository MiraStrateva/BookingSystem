using BookingSystem.MVP.Categories;
using BookingSystem.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace BookingSystem.MVP.Tests.Categories.CategoriesPresenterTests
{
    [TestFixture]
    public class View_OnDeleteItem_Should
    {
        [Test]
        public void CallDeleteCategory_WithPassesCategoryId()
        {
            // Arrange
            var viewMock = new Mock<ICategoriesView>();
            var categoryServiceMock = new Mock<ICategoryService>();

            var categoryPresenter = new CategoriesPresenter(viewMock.Object, categoryServiceMock.Object);
            Guid categoryId = Guid.NewGuid();

            // Act
            viewMock.Raise(v => v.OnDeleteItem += null, new IdEventArgs(categoryId));

            // Assert
            categoryServiceMock.Verify(c => c.DeleteCategory(categoryId), Times.Once());
        }
    }
}
