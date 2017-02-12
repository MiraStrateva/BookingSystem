namespace BookingSystem.Presenters.Contracts
{
    using BookingSystem.Models;
    using System;
    using WebFormsMvp;

    public interface IDefaultView : IView<CategoryViewModel>
    {
        event EventHandler OnStart;
    }
}
