using System;
using BookingSystem.MVP.Default;
using WebFormsMvp.Web;
using WebFormsMvp;
using System.Linq;

namespace BookingSystem.Views
{
    [PresenterBinding(typeof(DefaultPresenter))]
    public partial class _Default : MvpPage<DefaultViewModel>, IDefaultView
    {
        public event EventHandler OnCategoriesGetData;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.OnCategoriesGetData?.Invoke(sender, e);

            this.DataListCategories.DataSource = this.Model.DefaultCategories.ToList();
            this.DataListCategories.DataBind();
        }
    }
}