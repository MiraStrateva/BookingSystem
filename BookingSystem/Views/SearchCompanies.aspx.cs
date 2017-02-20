using BookingSystem.Data.Models;
using BookingSystem.MVP.SearchCompanies;
using System;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.UI;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace BookingSystem.Views
{
    [PresenterBinding(typeof(SearchCompaniesPresenter))]
    public partial class SearchCompanies : MvpPage<SearchCompaniesViewModel>, ISearchCompaniesView
    {
        public event EventHandler<FormGetSearchCompaniesEventArgs> OnSearchCompaniesGetData;

        public IQueryable<Company> ListViewCompanies_GetData([QueryString] string q)
        {
            this.OnSearchCompaniesGetData?.Invoke(this, new FormGetSearchCompaniesEventArgs(q));

            return this.Model.SearchCompanies;
        }

        protected void LinkButtonSearch_Click(object sender, EventArgs e)
        {
            string textToSearchFor = this.TextBoxSearchParam.Text;
            string queryParam = string.IsNullOrEmpty(textToSearchFor) ? string.Empty : string.Format("?q={0}", textToSearchFor);
            Response.Redirect("~/Views/SearchCompanies" + queryParam);
        }
    }
}