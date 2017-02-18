using BookingSystem.Data.Models;
using BookingSystem.MVP.CategoryCompanies;
using System;
using System.Linq;
using System.Web.ModelBinding;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace BookingSystem.Views
{
    [PresenterBinding(typeof(CategoryCompaniesPresenter))]
    public partial class CategoryCompanies : MvpPage<CategoryCompaniesViewModel>, ICategoryCompaniesView
    {
        public event EventHandler<FormGetCategoryCompaniesEventArgs> OnCategoryCompaniesGetData;
        public string CategoryName;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButtonSearch_Click(object sender, EventArgs e)
        {

        }

        public IQueryable<Company> ListViewCategoryCompanies_GetData([QueryString] Guid? categoryId)
        {
            this.OnCategoryCompaniesGetData?.Invoke(this, new FormGetCategoryCompaniesEventArgs(categoryId));
            this.CategoryName = this.Model.CategoryName;

            return this.Model.CategorieCompanies;
        }
    }
}