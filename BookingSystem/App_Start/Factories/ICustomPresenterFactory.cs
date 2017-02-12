namespace BookingSystem.App_Start.Factories
{
    using System;
    using WebFormsMvp;

    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}
