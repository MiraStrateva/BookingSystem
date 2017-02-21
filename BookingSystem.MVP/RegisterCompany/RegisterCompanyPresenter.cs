using BookingSystem.Data.Models;
using BookingSystem.Services.Contracts;
using Bytes2you.Validation;
using System;
using WebFormsMvp;
using Microsoft.AspNet.Identity;

namespace BookingSystem.MVP.RegisterCompany
{
    public class RegisterCompanyPresenter : Presenter<IRegisterCompanyView>
    {
        private readonly ICompanyService companyService;
        private readonly ICategoryService categoryService;

        public RegisterCompanyPresenter(IRegisterCompanyView view, ICompanyService companyService, ICategoryService categoryService) 
            : base(view)
        {
            Guard.WhenArgument(companyService, "companyService").IsNull().Throw();
            Guard.WhenArgument(categoryService, "categoryService").IsNull().Throw();

            this.companyService = companyService;
            this.categoryService = categoryService; 
            this.View.OnGetCompany += View_OnGetCompany;
            this.View.OnUpdateCompany += View_OnUpdateCompany;
            this.View.OnGetCategories += View_OnGetCategories;
        }

        private void View_OnGetCategories(object sender, EventArgs e)
        {
            this.View.Model.Categories = this.categoryService.GetAllCategories();
        }

        private void View_OnUpdateCompany(object sender, CompanyIdEventArgs e)
        {
            Company item = this.companyService.GetById(e.CompanyId);
            bool insertMode = false;

            if (item == null)
            {
                item = new Company();
                insertMode = true;
            }
            this.View.TryUpdateModel(item);
            if (this.View.ModelState.IsValid)
            {
                string userId = this.View.User.Identity.GetUserId();

                IdentityResult roleResult;
                if (!this.View.Manager.IsInRole(userId, "Company"))
                {
                    roleResult = this.View.Manager.AddToRole(userId, "Company");
                    if (!roleResult.Succeeded)
                    {
                        this.View.ModelState.AddModelError("", "Company Role is not added");
                        return;
                    }
                }
                if (this.View.Manager.IsInRole(userId, "Client"))
                {
                    roleResult = this.View.Manager.RemoveFromRole(userId, "Client");
                    if (!roleResult.Succeeded)
                    {
                        this.View.ModelState.AddModelError("", "Client Role is not removed");
                        return;
                    }
                }

                if (insertMode)
                {
                    item.UserId = userId;
                    this.companyService.InsertCompany(item);
                }
                else
                {
                    this.companyService.UpdateCompany(item);
                }
            }
        }

        private void View_OnGetCompany(object sender, EventArgs e)
        {
            string userId = this.View.User.Identity.GetUserId();
            Company item = this.companyService.GetCompanyByUserId(userId);
            if (item == null)
            {
                item = new Company();
            }
            this.View.Model.UserCompany = item;
        }
    }
}
