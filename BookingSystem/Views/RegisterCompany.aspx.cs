using BookingSystem.Auth;
using BookingSystem.Data.Models;
using BookingSystem.MVP.RegisterCompany;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace BookingSystem.Views
{
    [PresenterBinding(typeof(RegisterCompanyPresenter))]
    public partial class RegisterCompany : MvpPage<RegisterCompanyViewModel>, IRegisterCompanyView
    {
        public event EventHandler OnGetCompany;
        public event EventHandler<CompanyIdEventArgs> OnUpdateCompany;
        public event EventHandler OnGetCategories;
        public ApplicationUserManager Manager { get; set; }
        public Guid EmptyGuid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            EmptyGuid = Guid.Empty;
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
            if (Model.UserCompany.CompanyId == Guid.Empty)
            {
                ListViewCompany.SetEditItem(0);
            }
            return new List<Company>() { this.Model.UserCompany }.AsQueryable();
        }

        protected void ListViewCompany_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            ListViewCompany.SelectedIndex = e.ItemIndex;

            string newImageFileName = UploadImage(((FileUpload)ListViewCompany.Items[e.ItemIndex]
                .FindControl("FileUploadImage")));
            if (!string.IsNullOrEmpty(newImageFileName))
            {
                e.NewValues["CompanyImage"] = newImageFileName;
            }
            e.NewValues["CategoryId"] = ((DropDownList)ListViewCompany.Items[e.ItemIndex]
                .FindControl("DropDownListCategory")).SelectedValue;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewCompany_UpdateItem(Guid? id)
        {
            Guid companyId = ((Guid)ListViewCompany.SelectedDataKey.Value);
            this.OnUpdateCompany?.Invoke(this, new CompanyIdEventArgs(companyId));
        }

        public IQueryable<Category> DropDownListCategory_GetData()
        {
            this.OnGetCategories?.Invoke(this, null);
            return this.Model.Categories;
        }

        protected string UploadImage(FileUpload fileUpload)
        {
            string imageFile = "";
            if (fileUpload.HasFile)
            {
                string filename = Path.GetFileName(fileUpload.FileName);
                string fullpathFilename = Path.Combine(Server.MapPath("~/Images/Companies/"), filename);

                fileUpload.SaveAs(fullpathFilename);

                imageFile = Path.Combine("/Images/Companies/", filename);
            }
            return imageFile;
        }
    }
}