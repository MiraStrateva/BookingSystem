using System;

namespace BookingSystem.MVP.RegisterCompany
{
    public class CategoryIdEventArgs : EventArgs
    {
        public Guid? CategoryId { get; private set; }

        public CategoryIdEventArgs(Guid? categoryId)
        {
            this.CategoryId = categoryId;
        }
    }
}
