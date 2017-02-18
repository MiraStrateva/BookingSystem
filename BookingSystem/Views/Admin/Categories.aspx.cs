using BookingSystem.Data.Models;
using System;
using System.IO;
using System.Web.UI.WebControls;

namespace BookingSystem.Views.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        protected void ButtonInsertCategory_Click(object sender, EventArgs e)
        {
            EntityDataSourceCategories.Insert();
        }

        protected void CategoriesDataSource_Inserting(
                object sender,
                EntityDataSourceChangingEventArgs e)
        {
            var newCategory = (e.Entity as Category);
            string newCategoryName = ((TextBox)GridViewCategories.FooterRow.FindControl("FTextBoxCategoryName")).Text;
            string newCategoryDescription = ((TextBox)GridViewCategories.FooterRow.FindControl("FTextBoxCategoryDescription")).Text;
            string newCategoryImageFileName = UploadImage(((FileUpload)GridViewCategories.FooterRow.FindControl("FFileUploadControl")));

            newCategory.CategoryName = newCategoryName;
            newCategory.CategoryDescription = newCategoryDescription;
            newCategory.CategoryImage = newCategoryImageFileName;
    }

        protected void CategoriesDataSource_Inserted(
                object sender,
                EntityDataSourceChangedEventArgs e)
        {
            GridViewCategories.DataBind();
        }
        
        protected void EntityDataSourceCategories_Updating(object sender, EntityDataSourceChangingEventArgs e)
        {
            var editCategory = (e.Entity as Category);
            string editCategoryName = ((TextBox)GridViewCategories.Rows[GridViewCategories.EditIndex].FindControl("TextBoxCategoryName")).Text;
            string editCategoryDescription = ((TextBox)GridViewCategories.Rows[GridViewCategories.EditIndex].FindControl("TextBoxCategoryDescription")).Text;
            string editCategoryImageFileName = UploadImage(((FileUpload)GridViewCategories.Rows[GridViewCategories.EditIndex].FindControl("FileUploadControl")));

            editCategory.CategoryName = editCategoryName;
            editCategory.CategoryDescription = editCategoryDescription;
            editCategory.CategoryImage = editCategoryImageFileName;
        }

        protected void EntityDataSourceCategories_Updated(object sender, EntityDataSourceChangedEventArgs e)
        {
            GridViewCategories.DataBind();
        }

        // TODO: Make abstract
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
    }
}