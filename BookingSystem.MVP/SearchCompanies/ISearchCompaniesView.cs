using System;
using WebFormsMvp;

namespace BookingSystem.MVP.SearchCompanies
{
    public interface ISearchCompaniesView : IView<SearchCompaniesViewModel>
    {
        event EventHandler<FormGetSearchCompaniesEventArgs> OnSearchCompaniesGetData;
    }
}
