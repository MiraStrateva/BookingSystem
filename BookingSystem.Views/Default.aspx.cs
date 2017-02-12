namespace BookingSystem.Views
{
    using System;
    using Models;
    using Presenters.Contracts;
    using WebFormsMvp.Web;

    public partial class _Default : MvpPage<CategoryViewModel>, IDefaultView
    {
        public event EventHandler OnStart;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.OnStart?.Invoke(sender, e);

            this.DataListCategories.DataSource = this.Model.Categories;
            this.DataListCategories.DataBind();
        }
    }
}