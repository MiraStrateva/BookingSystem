using BookingSystem.Data.Models;
using BookingSystem.MVP.RegisterCompany;
using System;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace BookingSystem.Views
{
    [PresenterBinding(typeof(RegisterCompanyPresenter))]
    public partial class RegisterCompany : MvpPage<RegisterCompanyViewModel>, IRegisterCompanyView
    {
        public event EventHandler OnGetCompany;
        public event EventHandler<CategoryIdEventArgs> OnUpdateCompany;
        public event EventHandler OnGetCategories;

        protected void Page_Load(object sender, EventArgs e)
        {
            User.Identity
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Company> ListViewCompany_GetData()
        {
            this.OnGetCompany?.Invoke(this, null);
            return this.Model.UserCompany;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewCompany_UpdateItem(Guid? id)
        {
            this.OnUpdateCompany?.Invoke(this, new CategoryIdEventArgs(id));
        }

        public IQueryable<Category> DropDownListCategory_GetData()
        {
            this.OnGetCategories?.Invoke(this, null);
            return this.Model.Categories;
        }
    }
}