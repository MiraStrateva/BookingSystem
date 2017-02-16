namespace BookingSystem.Views.Admin
{
    using BookingSystem.Data;
    using System;
    using System.IO;
    using System.Web.UI.WebControls;

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
            
            // Upload image
            if (((FileUpload)GridViewCategories.FooterRow.FindControl("FFileUploadControl")).HasFile)
            {
                string filename = Path.GetFileName(((FileUpload)GridViewCategories.FooterRow.FindControl("FFileUploadControl")).FileName);
                string fullpathFilename = Path.Combine(Server.MapPath("~/Images/Categories/"), filename);

                ((FileUpload)GridViewCategories.FooterRow.FindControl("FFileUploadControl"))
                    .SaveAs(fullpathFilename);

                // newCategory.CategoryImage = Path.Combine("~/Images/Categories/", filename);
                newCategory.CategoryImage = Path.Combine("http://localhost:59329/Images/Categories/", filename);
            }

            newCategory.CategoryName = newCategoryName;
            newCategory.CategoryDescription = newCategoryDescription;
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

            // Upload image
            if (((FileUpload)GridViewCategories.Rows[GridViewCategories.EditIndex].FindControl("FileUploadControl")).HasFile)
            {
                string filename = Path.GetFileName(((FileUpload)GridViewCategories.Rows[GridViewCategories.EditIndex].FindControl("FileUploadControl")).FileName);
                string fullpathFilename = Path.Combine(Server.MapPath("~/Images/Categories/"), filename);

                ((FileUpload)GridViewCategories.Rows[GridViewCategories.EditIndex].FindControl("FileUploadControl"))
                    .SaveAs(fullpathFilename);

                // newCategory.CategoryImage = Path.Combine("~/Images/Categories/", filename);
                editCategory.CategoryImage = Path.Combine("http://localhost:59329/Images/Categories/", filename);
            }

            editCategory.CategoryName = editCategoryName;
            editCategory.CategoryDescription = editCategoryDescription;
        }

        protected void EntityDataSourceCategories_Updated(object sender, EntityDataSourceChangedEventArgs e)
        {
            GridViewCategories.DataBind();
        }
    }
}