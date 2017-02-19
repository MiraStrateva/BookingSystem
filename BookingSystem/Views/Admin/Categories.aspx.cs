using BookingSystem.MVP.Categories;
using System;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace BookingSystem.Views.Admin
{
    [PresenterBinding(typeof(CategoriesPresenter))]
    public partial class Categories : MvpPage<CategoriesViewModel>, ICategoriesView
    {
        public event EventHandler OnGetData;
        public event EventHandler<CategoryInsertEventArgs> OnInsertItem;
        public event EventHandler<IdEventArgs> OnDeleteItem;
        public event EventHandler<IdEventArgs> OnUpdateItem;

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable GridViewCategories_GetData()
        {
            this.OnGetData?.Invoke(this, null);
            return this.Model.Categories;
        }

        protected void ButtonInsertCategory_Click(object sender, EventArgs e)
        {
            string newCategoryName = ((TextBox)GridViewCategories.FooterRow.FindControl("FTextBoxCategoryName")).Text;
            string newCategoryDescription = ((TextBox)GridViewCategories.FooterRow.FindControl("FTextBoxCategoryDescription")).Text;
            string newCategoryImageFileName = UploadImage(((FileUpload)GridViewCategories.FooterRow.FindControl("FFileUploadControl")));
            
            this.OnInsertItem?.Invoke(this, 
                new CategoryInsertEventArgs(newCategoryName, newCategoryDescription, newCategoryImageFileName));
        }
        
        protected void GridViewCategories_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewCategories.SelectedIndex = e.RowIndex;
        }
        
        protected void GridViewCategories_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewCategories.SelectedIndex = e.RowIndex;

            string newImageFileName = UploadImage(((FileUpload)GridViewCategories.Rows[e.RowIndex].FindControl("FileUploadControl")));
            if (!string.IsNullOrEmpty(newImageFileName))
            {
                e.NewValues["CategoryImage"] = newImageFileName;
            }
        }

        protected string UploadImage(FileUpload fileUpload)
        {
            string imageFile = "";
            if (fileUpload.HasFile)
            {
                string filename = Path.GetFileName(fileUpload.FileName);
                string fullpathFilename = Path.Combine(Server.MapPath("~/Images/Categories/"), filename);

                fileUpload.SaveAs(fullpathFilename);

                imageFile = Path.Combine("/Images/Categories/", filename);
            }
            return imageFile;
        }
        
        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_UpdateItem(Guid? id)
        {
            Guid categoryId = ((Guid)GridViewCategories.SelectedDataKey.Value);
            this.OnUpdateItem?.Invoke(this, new IdEventArgs(categoryId));
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_DeleteItem(Guid? id)
        {
            Guid categoryId = ((Guid)GridViewCategories.SelectedDataKey.Value);
            this.OnDeleteItem?.Invoke(this, new IdEventArgs(categoryId));
        }
    }
}