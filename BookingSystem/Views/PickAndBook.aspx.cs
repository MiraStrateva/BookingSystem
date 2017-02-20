using BookingSystem.Data.Models;
using BookingSystem.MVP.PickAndBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace BookingSystem.Views
{
    [PresenterBinding(typeof(PickAndBookPresenter))]
    public partial class PickAndBook : MvpPage<PickAndBookViewModel>, IPickAndBookView
    {
        public event EventHandler OnCategoriesGetData;

        public IQueryable<Category> ListViewCategories_GetData()
        {
            this.OnCategoriesGetData?.Invoke(this, null);

            return this.Model.Categories;
        }

        protected void LinkButtonSearch_Click(object sender, EventArgs e)
        {
            string textToSearchFor = this.TextBoxSearchParam.Text;
            string queryParam = string.IsNullOrEmpty(textToSearchFor) ? string.Empty : string.Format("?q={0}", textToSearchFor);
            Response.Redirect("~/Views/SearchCompanies" + queryParam);
        }
    }
}