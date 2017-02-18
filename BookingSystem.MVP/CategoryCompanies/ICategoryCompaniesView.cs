using System;
using WebFormsMvp;

namespace BookingSystem.MVP.CategoryCompanies
{
    public interface ICategoryCompaniesView : IView<CategoryCompaniesViewModel>
    {
        event EventHandler<FormGetCategoryCompaniesEventArgs> OnCategoryCompaniesGetData;
    }
}
