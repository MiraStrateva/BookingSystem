using BookingSystem.Data.Models;
using BookingSystem.MVP.Categories;
using BookingSystem.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Web.ModelBinding;

namespace BookingSystem.MVP.Tests.Categories.CategoriesPresenterTests
{
    [TestFixture]
    public class View_OnInsertItem_Should
    {
        [Test]
        public void AddModelError_WhenImageIsNull()
        {
            // Arrange
            var viewMock = new Mock<ICategoriesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            string errorKey = string.Empty;
            string expectedError = String.Format("Category Image cannot be empty!");
            var categoryServiceMock = new Mock<ICategoryService>();
            
            CategoriesPresenter categoriesPresenter = new CategoriesPresenter(viewMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnInsertItem += null, new CategoryInsertEventArgs("Category 1", "Description 1", null));

            // Assert
            Assert.AreEqual(1, viewMock.Object.ModelState[errorKey].Errors.Count);
            StringAssert.AreEqualIgnoringCase(expectedError,
                viewMock.Object.ModelState[errorKey].Errors[0].ErrorMessage);
        }

        [Test]
        public void AddModelError_WhenImageIsEmpty()
        {
            // Arrange
            var viewMock = new Mock<ICategoriesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            string errorKey = string.Empty;
            string expectedError = String.Format("Category Image cannot be empty!");
            var categoryServiceMock = new Mock<ICategoryService>();

            CategoriesPresenter categoriesPresenter = new CategoriesPresenter(viewMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnInsertItem += null, new CategoryInsertEventArgs("Category 1", "Description 1", string.Empty));

            // Assert
            Assert.AreEqual(1, viewMock.Object.ModelState[errorKey].Errors.Count);
            StringAssert.AreEqualIgnoringCase(expectedError,
                viewMock.Object.ModelState[errorKey].Errors[0].ErrorMessage);
        }

        [Test]
        public void CallInsertCategory_WhenCorrectParametersArePassed()
        {
            // Arrange
            var viewMock = new Mock<ICategoriesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            string categoryName = "Category 1";
            string categoryDescription = "Description 1";
            string categoryImage = "Image 1";

            var categoryServiceMock = new Mock<ICategoryService>();

            CategoriesPresenter categoriesPresenter = new CategoriesPresenter(viewMock.Object,
                categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnInsertItem += null,
                new CategoryInsertEventArgs(categoryName, categoryDescription, categoryImage));

            // Assert
            categoryServiceMock.Verify(c => c.InsertCategory(It.IsAny<Category>()), Times.Once());
        }

        [Test]
        public void CallInsertCategory_WithCorrectlyConstructedItem()
        {
            // Arrange
            var viewMock = new Mock<ICategoriesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            string categoryName = "Category 1";
            string categoryDescription = "Description 1";
            string categoryImage = "Image 1";

            var categoryServiceMock = new Mock<ICategoryService>();
            
            CategoriesPresenter categoriesPresenter = new CategoriesPresenter(viewMock.Object, 
                categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnInsertItem += null, 
                new CategoryInsertEventArgs(categoryName, categoryDescription, categoryImage));

            // Assert
            categoryServiceMock.Verify(c => c.InsertCategory(It.Is<Category>(cat => cat.CategoryName == categoryName 
                                                        && cat.CategoryDescription == categoryDescription
                                                        && cat.CategoryImage == categoryImage)), Times.Once());
        }
    }
}
