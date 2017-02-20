using BookingSystem.Services.Contracts;
using WebFormsMvp;
using Bytes2you.Validation;

namespace BookingSystem.MVP.CategoryCompanies
{
    public class CategoryCompaniesPresenter : Presenter<ICategoryCompaniesView>
    {
        private readonly ICompanyService companyService;
        private readonly ICategoryService categoryService;

        public CategoryCompaniesPresenter(ICategoryCompaniesView view, 
            ICompanyService companyService,
            ICategoryService categoryService) 
            : base(view)
        {
            Guard.WhenArgument(companyService, "companyService").IsNull().Throw();
            Guard.WhenArgument(categoryService, "categoryService").IsNull().Throw();

            this.companyService = companyService;
            this.categoryService = categoryService;

            this.View.OnCategoryCompaniesGetData += View_OnCategoryCompaniesGetData;
        }

        private void View_OnCategoryCompaniesGetData(object sender, FormGetCategoryCompaniesEventArgs e)
        {
            string searchText = string.IsNullOrEmpty(e.searchText) ? string.Empty : e.searchText.ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                this.View.Model.CategorieCompanies = this.companyService.GetCompaniesByCategoryId(e.categoryId);
            }
            else
            {
                this.View.Model.CategorieCompanies = this.companyService.GetCompaniesByCategoryIdNameOrDescription(e.categoryId, searchText);
            }
            this.View.Model.CategoryName = this.categoryService.GetCategoryNameById(e.categoryId);
        }
    }
}
