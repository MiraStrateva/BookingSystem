using BookingSystem.Auth;
using System;
using System.Security.Principal;
using System.Web;
using System.Web.ModelBinding;
using WebFormsMvp;

namespace BookingSystem.MVP.RegisterCompany
{
    public interface IRegisterCompanyView : IView<RegisterCompanyViewModel>
    {
        event EventHandler OnGetCompany;
        event EventHandler<CompanyIdEventArgs> OnUpdateCompany;
        event EventHandler OnGetCategories;

        ModelStateDictionary ModelState { get; }
        IPrincipal User { get; }
        ApplicationUserManager Manager { get; set; }
        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
