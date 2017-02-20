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
        
        public IQueryable<Company> ListViewCategoryCompanies_GetData([QueryString] Guid? categoryId, [Control] string TextBoxSearchParam)
        {
            this.OnCategoryCompaniesGetData?.Invoke(this, new FormGetCategoryCompaniesEventArgs(categoryId, TextBoxSearchParam));
            this.CategoryName = this.Model.CategoryName;
            
            return this.Model.CategorieCompanies;
        }
    }
}