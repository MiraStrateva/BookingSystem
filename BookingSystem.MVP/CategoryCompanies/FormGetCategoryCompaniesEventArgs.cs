using System;

namespace BookingSystem.MVP.CategoryCompanies
{
    public class FormGetCategoryCompaniesEventArgs : EventArgs
    {
        public Guid? categoryId { get; private set; }
        public string searchText { get; private set; }

        public FormGetCategoryCompaniesEventArgs(Guid? categoryId, string searchText)
        {
            this.categoryId = categoryId;
            this.searchText = searchText;
        }
    }
}
