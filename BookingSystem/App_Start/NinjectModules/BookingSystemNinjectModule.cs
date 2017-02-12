namespace BookingSystem.App_Start.NinjectModules
{
    using Data;
    using Data.Contracts;
    using Ninject.Modules;
    using Presenters;
    using Providers;
    using Providers.Contracts;

    public class BookingSystemNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDataProvider>().To<DataProvider>();
            this.Bind<IDbContext>().To<BookingSystemDbContext>();
            this.Bind<DefaultPresenter>().ToSelf();      
        }
    }
}