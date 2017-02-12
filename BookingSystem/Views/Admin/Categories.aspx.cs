namespace BookingSystem.Views.Admin
{
    using BookingSystem.Data;
    using System;
    using System.IO;
    using System.Web.UI.WebControls;

    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                string fullpathFilename = Server.MapPath("~/Images/Categories/") + filename;
                ((FileUpload)GridViewCategories.FooterRow.FindControl("FFileUploadControl"))
                    .SaveAs(fullpathFilename);
                newCategory.CategoryImage = fullpathFilename;
            }

            newCategory.CategoryName = newCategoryName;
            newCategory.CategoryDescription = newCategoryDescription;
        }

        protected void ButtonInsertService_Click(object sender, EventArgs e)
        {
            EntityDataSourceServices.Insert();
        }

        protected void CategoriesDataSource_Inserted(
                object sender,
                EntityDataSourceChangedEventArgs e)
        {
            GridViewCategories.DataBind();
        }

        protected void ServicesDataSource_Inserting(
                object sender,
                EntityDataSourceChangingEventArgs e)
        {
            var newService = (e.Entity as Service);
            string newServiceName = ((TextBox)GridViewServices.FooterRow.FindControl("FTextBoxServiceName")).Text;
            string newServiceDescription = ((TextBox)GridViewServices.FooterRow.FindControl("FTextBoxServiceDescription")).Text;
            int newCategoryID = int.Parse(GridViewCategories.SelectedDataKey.Value.ToString());

            newService.ServiceName = newServiceName;
            newService.ServiceDescription = newServiceDescription;
            newService.CategoryID = newCategoryID;
        }

        protected void ServicesDataSource_Inserted(
                object sender,
                EntityDataSourceChangedEventArgs e)
        {
            GridViewServices.DataBind();
        }

        protected void EntityDataSourceCategories_Updating(object sender, EntityDataSourceChangingEventArgs e)
        {

        }

        protected void EntityDataSourceCategories_Updated(object sender, EntityDataSourceChangedEventArgs e)
        {

        }
    }
}