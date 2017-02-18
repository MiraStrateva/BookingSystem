using BookingSystem.Data;
using BookingSystem.Data.Contracts;
using BookingSystem.MVP.CategoryCompanies;
using BookingSystem.MVP.Default;
using Ninject.Modules;
using System.Reflection;
using System.IO;
using Ninject.Extensions.Conventions;
using BookingSystem.Services;
using BookingSystem.Services.Contracts;

namespace BookingSystem.App_Start.NinjectModules
{
    public class BookingSystemNinjectModule : NinjectModule
    {
        public override void Load()
        {
            //Kernel.Bind(x =>
            //{
            //    x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            //    .SelectAllClasses()
            //    .BindDefaultInterface();
            //});

            // DBContext 
            this.Bind<IBookingSystemContext>().To<BookingSystemContext>().InSingletonScope();
            
            // Services
            this.Bind<ICompanyService>().To<CompanyService>();
            this.Bind<ICategoryService>().To<CategoryService>();
            this.Bind<IBookingService>().To<BookingService>();
            this.Bind<IWorkingtimeService>().To<WorkingtimeService>();

            // Presenters
            this.Bind<DefaultPresenter>().ToSelf();
            this.Bind<CategoryCompaniesPresenter>().ToSelf();
        }
    }
}