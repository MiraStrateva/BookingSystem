using NUnit.Framework;
using Moq;
using BookingSystem.MVP.Categories;
using System.Web.ModelBinding;
using System;
using BookingSystem.Data.Models;
using BookingSystem.Services.Contracts;

namespace BookingSystem.MVP.Tests.Categories.CategoriesPresenterTests
{
    [TestFixture]
    public class View_OnUpdateItem_Should
    {
        [Test]
        public void AddModelError_WhenItemIsNotFound()
        {
            // Arrange
            var viewMock = new Mock<ICategoriesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            Guid categoryId = Guid.NewGuid();
            string errorKey = string.Empty;
            string expectedError = String.Format("Item with id {0} was not found", categoryId);
            var categoryServiceMock = new Mock<ICategoryService>();
            categoryServiceMock.Setup(c => c.GetById(categoryId)).Returns<Category>(null);

            CategoriesPresenter categoriesPresenter = new CategoriesPresenter(viewMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnUpdateItem += null, new IdEventArgs(categoryId));

            // Assert
            Assert.AreEqual(1, viewMock.Object.ModelState[errorKey].Errors.Count);
            StringAssert.AreEqualIgnoringCase(expectedError, 
                viewMock.Object.ModelState[errorKey].Errors[0].ErrorMessage);
        }

        [Test]
        public void NotCallTryUpdateModel_WhenItemIsNotFound()
        {
            // Arrange
            var viewMock = new Mock<ICategoriesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            Guid categoryId = Guid.NewGuid();
            var categoryServiceMock = new Mock<ICategoryService>();
            categoryServiceMock.Setup(c => c.GetById(categoryId)).Returns<Category>(null);

            CategoriesPresenter categoriesPresenter = new CategoriesPresenter(viewMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnUpdateItem += null, new IdEventArgs(categoryId));

            // Assert
            viewMock.Verify(v => v.TryUpdateModel(It.IsAny<Category>()), Times.Never());
        }

        [Test]
        public void CallTryUpdateModel_WhenItemIsFound()
        {
            // Arrange
            var viewMock = new Mock<ICategoriesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            Guid categoryId = Guid.NewGuid();
            var categoryServiceMock = new Mock<ICategoryService>();
            categoryServiceMock.Setup(c => c.GetById(categoryId))
                .Returns(new Category(){ CategoryId = categoryId, CategoryName = "Category 1" });

            CategoriesPresenter categoriesPresenter = new CategoriesPresenter(viewMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnUpdateItem += null, new IdEventArgs(categoryId));

            // Assert
            viewMock.Verify(v => v.TryUpdateModel(It.IsAny<Category>()), Times.Once());
        }

        [Test]
        public void CallUpdateCategory_WhenItemIsFoundAndIsInValidState()
        {
            // Arrange
            var viewMock = new Mock<ICategoriesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            Guid categoryId = Guid.NewGuid();
            var categoryServiceMock = new Mock<ICategoryService>();
            var category = new Category() { CategoryId = categoryId, CategoryName = "Category 1" };
            categoryServiceMock.Setup(c => c.GetById(categoryId)).Returns(category);

            CategoriesPresenter categoriesPresenter = new CategoriesPresenter(viewMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnUpdateItem += null, new IdEventArgs(categoryId));

            // Assert
            categoryServiceMock.Verify(c => c.UpdateCategory(category), Times.Once());
        }

        [Test]
        public void NotCallUpdateCategory_WhenItemIsFoundAndIsInInvalidState()
        {
            // Arrange
            var viewMock = new Mock<ICategoriesView>();
            var modelState = new ModelStateDictionary();
            modelState.AddModelError("test key", "test message");
            viewMock.Setup(v => v.ModelState).Returns(modelState);

            Guid categoryId = Guid.NewGuid();
            var categoryServiceMock = new Mock<ICategoryService>();
            var category = new Category() { CategoryId = categoryId, CategoryName = "Category 1" };
            categoryServiceMock.Setup(c => c.GetById(categoryId)).Returns(category);

            CategoriesPresenter categoriesPresenter = new CategoriesPresenter(viewMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnUpdateItem += null, new IdEventArgs(categoryId));

            // Assert
            categoryServiceMock.Verify(c => c.UpdateCategory(category), Times.Never());
        }
    }
}
