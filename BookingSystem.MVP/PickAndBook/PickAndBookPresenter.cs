using BookingSystem.Services.Contracts;
using Bytes2you.Validation;
using WebFormsMvp;

namespace BookingSystem.MVP.PickAndBook
{
    public class PickAndBookPresenter : Presenter<IPickAndBookView>
    {
        private ICategoryService categoryService;

        public PickAndBookPresenter(IPickAndBookView view, ICategoryService categoryService)
            : base(view)
        {
            Guard.WhenArgument(categoryService, "categoryService").IsNull().Throw();

            this.categoryService = categoryService;

            this.View.OnCategoriesGetData += View_OnCategoriesGetData1; ;
        }

        private void View_OnCategoriesGetData1(object sender, System.EventArgs e)
        {
            this.View.Model.Categories = this.categoryService.GetAllCategoriesWithIncludedCompanies();
        }
    }
}
