using System;
using WebFormsMvp;

namespace BookingSystem.MVP.PickAndBook
{
    public interface IPickAndBookView : IView<PickAndBookViewModel>
    {
        event EventHandler OnCategoriesGetData;
    }
}
