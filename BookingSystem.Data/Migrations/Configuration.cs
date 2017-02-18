using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using BookingSystem.Data.Models;

namespace BookingSystem.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BookingSystem.Data.BookingSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BookingSystemContext context)
        {
            if (context.Companies.Any())
            {
                return;
            }

            IList<Category> categories = new List<Category>()
            {
                new Category() { CategoryId = Guid.NewGuid(), CategoryName = "Beauty Salons", 
                                CategoryDescription = "Book your next beauty procedure",
                                CategoryImage = "/Images/Categories/beautysalon.jpg"},
                new Category() { CategoryId = Guid.NewGuid(), CategoryName = "Consultants",
                                CategoryDescription = "Book your next consultant appointment",
                                CategoryImage = "/Images/Categories/consultant.jpg"},
                new Category() { CategoryId = Guid.NewGuid(), CategoryName = "Education",
                                CategoryDescription = "Book your next private lesson",
                                CategoryImage = "/Images/Categories/tutor.jpg"},
                new Category() { CategoryId = Guid.NewGuid(), CategoryName = "Health Clinics",
                                CategoryDescription = "Book your next medical examination",
                                CategoryImage = "/Images/Categories/medical.jpg"},
                new Category() { CategoryId = Guid.NewGuid(), CategoryName = "Sport & Fitness",
                                CategoryDescription = "Book your next individual training hour",
                                CategoryImage = "/Images/Categories/sport.jpg"},
                new Category() { CategoryId = Guid.NewGuid(), CategoryName = "Wellness",
                                CategoryDescription = "Book your next SPA procedure",
                                CategoryImage = "/Images/Categories/wellness.jpg"},
                new Category() { CategoryId = Guid.NewGuid(), CategoryName = "Dental Surgeries",
                                CategoryDescription = "Book your next dental procedure",
                                CategoryImage="/Images/Categories/dentist.jpg"},
                new Category() { CategoryId = Guid.NewGuid(), CategoryName = "Make Up",
                                CategoryDescription = "Book your make up hour. Enjoy!",
                                CategoryImage = "/Images/Categories/make-up.jpg"},
                new Category() { CategoryId = Guid.NewGuid(), CategoryName = "Other",
                                CategoryDescription = "Book your hour in some other hourly services",
                                CategoryImage = "/Images/Categories/other.jpg"}


            };

            context.Categories.AddOrUpdate(categories.ToArray());
        }
    }
}
