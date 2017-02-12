namespace BookingSystem.Presenters
{
    using BookingSystem.Presenters.Contracts;
    using BookingSystem.Providers.Contracts;
    using WebFormsMvp;

    public class DefaultPresenter : Presenter<IDefaultView>
    {
        private readonly IDataProvider provider;

        public DefaultPresenter(IDefaultView view, IDataProvider provider) 
            : base(view)
        {
            this.provider = provider;

            this.View.OnStart += View_OnStart;
        }

        private void View_OnStart(object sender, System.EventArgs e)
        {
            View.Model.Categories = provider.GetCategories();
        }
    }
}