namespace BookingSystem.Views
{
    using System;
    using WebFormsMvp.Web;
    using Models;
    using Presenters;
    using WebFormsMvp;
    using Presenters.Contracts;

    [PresenterBinding(typeof(DefaultPresenter))]
    public partial class _Default : MvpPage<CategoryViewModel>, IDefaultView
    {
        public event EventHandler OnStart;
        protected void Page_Load(object sender, EventArgs e)
        {
            // BookingSystemDataEntities entities = new BookingSystemDataEntities();
            this.OnStart?.Invoke(sender, e);

            this.DataListCategories.DataSource = this.Model.Categories;
            this.DataListCategories.DataBind();

            //this.ListViewCategories.DataSource = this.Model.Categories;
            //this.ListViewCategories.DataBind();
        }
    }
}