using BookingSystem.Data.Models;
using BookingSystem.Services.Contracts;
using Bytes2you.Validation;
using System;
using WebFormsMvp;

namespace BookingSystem.MVP.Categories
{
    public class CategoriesPresenter : Presenter<ICategoriesView>
    {
        private readonly ICategoryService categoryService;

        public CategoriesPresenter(ICategoriesView view, ICategoryService categoryService):
            base(view)
        {
            Guard.WhenArgument(categoryService, "categoryService").IsNull().Throw();

            this.categoryService = categoryService;

            this.View.OnGetData += View_OnGetData;
            this.View.OnInsertItem += View_OnInsertItem;
            this.View.OnDeleteItem += View_OnDeleteItem;
            this.View.OnUpdateItem += View_OnUpdateItem;
        }

        private void View_OnUpdateItem(object sender, IdEventArgs e)
        {
            Category item = this.categoryService.GetById(e.Id);
            
            if (item == null)
            {
                // The item wasn't found
                this.View.ModelState.AddModelError("", String.Format("Item with id {0} was not found", e.Id));
                return;
            }
            this.View.TryUpdateModel(item);
            if (this.View.ModelState.IsValid)
            {
                this.categoryService.UpdateCategory(item);
            }
        }

        private void View_OnDeleteItem(object sender, IdEventArgs e)
        {
            this.categoryService.DeleteCategory(e.Id);
        }

        private void View_OnInsertItem(object sender, CategoryInsertEventArgs e)
        {
            if (string.IsNullOrEmpty(e.image))
            {
                this.View.ModelState.AddModelError("", "Category Image cannot be empty!");
                return;
            }

            Category item = new Category()
            {
                CategoryName = e.name,
                CategoryDescription = e.description,
                CategoryImage = e.image
            };

            this.categoryService.InsertCategory(item);
        }

        private void View_OnGetData(object sender, System.EventArgs e)
        {
            this.View.Model.Categories = this.categoryService.GetAllCategories();
        }
    }
}
