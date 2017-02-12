namespace BookingSystem.App_Start.Factories
{
    using System;
    using WebFormsMvp;
    using WebFormsMvp.Binder;

    public class WebFormsMvpPresenterFactory : IPresenterFactory
    {
        private readonly ICustomPresenterFactory factory;

        public WebFormsMvpPresenterFactory(ICustomPresenterFactory factory)
        {
            this.factory = factory;
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            return this.factory.GetPresenter(presenterType, viewInstance);
        }

        public void Release(IPresenter presenter)
        {
            var disposable = presenter as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}