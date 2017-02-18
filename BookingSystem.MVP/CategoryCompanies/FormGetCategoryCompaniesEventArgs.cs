using System;

namespace BookingSystem.MVP.CategoryCompanies
{
    public class FormGetCategoryCompaniesEventArgs : EventArgs
    {
        public Guid? categoryId { get; private set; }

        public FormGetCategoryCompaniesEventArgs(Guid? categoryId)
        {
            this.categoryId = categoryId;
        }
    }
}
