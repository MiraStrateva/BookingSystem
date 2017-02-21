using BookingSystem.Services.Contracts;
using Bytes2you.Validation;
using WebFormsMvp;

namespace BookingSystem.MVP.SearchCompanies
{
    public class SearchCompaniesPresenter : Presenter<ISearchCompaniesView>
    {
        private readonly ICompanyService companyService;

        public SearchCompaniesPresenter(ISearchCompaniesView view, ICompanyService companyService)
            : base(view)
        {
            Guard.WhenArgument(companyService, "companyService").IsNull().Throw();
            this.companyService = companyService;

            this.View.OnSearchCompaniesGetData += View_OnSearchCompaniesGetData;
        }

        private void View_OnSearchCompaniesGetData(object sender, FormGetSearchCompaniesEventArgs e)
        {
            string searchText = string.IsNullOrEmpty(e.searchText) ? string.Empty : e.searchText.ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                this.View.Model.SearchCompanies = this.companyService.GetAllCompanies();
            }
            else
            {
                this.View.Model.SearchCompanies = this.companyService.GetCompaniesByNameOrDescription(searchText);
            }
        }
    }
}
