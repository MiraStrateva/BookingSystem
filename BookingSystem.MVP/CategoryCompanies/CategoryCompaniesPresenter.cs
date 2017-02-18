using BookingSystem.Services.Contracts;
using WebFormsMvp;

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
            this.companyService = companyService;
            this.categoryService = categoryService;

            this.View.OnCategoryCompaniesGetData += View_OnCategoryCompaniesGetData;
        }

        private void View_OnCategoryCompaniesGetData(object sender, FormGetCategoryCompaniesEventArgs e)
        {
            this.View.Model.CategorieCompanies = this.companyService.GetCompaniesByCategoryId(e.categoryId);
            this.View.Model.CategoryName = this.categoryService.GetCategoryNameById(e.categoryId);
        }
    }
}
