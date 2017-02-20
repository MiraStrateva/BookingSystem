using System;
using System.Web.ModelBinding;
using WebFormsMvp;

namespace BookingSystem.MVP.Categories
{
    public interface ICategoriesView : IView<CategoriesViewModel>
    {
        event EventHandler OnGetData;
        event EventHandler<CategoryInsertEventArgs> OnInsertItem;
        event EventHandler<IdEventArgs> OnDeleteItem;
        event EventHandler<IdEventArgs> OnUpdateItem;

        ModelStateDictionary ModelState { get; }
        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
