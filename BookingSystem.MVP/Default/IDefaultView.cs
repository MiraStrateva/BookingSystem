using System;
using WebFormsMvp;

namespace BookingSystem.MVP.Default
{
    public interface IDefaultView : IView<DefaultViewModel>
    {
        event EventHandler OnCategoriesGetData;
    }
}
