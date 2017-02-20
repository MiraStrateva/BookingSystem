using System;

namespace BookingSystem.MVP.SearchCompanies
{
    public class FormGetSearchCompaniesEventArgs : EventArgs
    {
        public string searchText { get; private set; }

        public FormGetSearchCompaniesEventArgs(string searchText)
        {
            this.searchText = searchText;
        }
    }
}
