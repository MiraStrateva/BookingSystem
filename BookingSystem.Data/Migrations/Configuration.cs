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
                new Category() { CategoryName = "Beauty Salons", 
                                CategoryDescription = "Book your next beauty procedure",
                                CategoryImage = "/Images/Categories/beautysalon.jpg"},
                new Category() { CategoryName = "Consultants",
                                CategoryDescription = "Book your next consultant appointment",
                                CategoryImage = "/Images/Categories/consultant.jpg"},
                new Category() { CategoryName = "Education",
                                CategoryDescription = "Book your next private lesson",
                                CategoryImage = "/Images/Categories/tutor.jpg"},
                new Category() { CategoryName = "Health Clinics",
                                CategoryDescription = "Book your next medical examination",
                                CategoryImage = "/Images/Categories/medical.jpg"},
                new Category() { CategoryName = "Sport & Fitness",
                                CategoryDescription = "Book your next individual training hour",
                                CategoryImage = "/Images/Categories/sport.jpg"},
                new Category() { CategoryName = "Wellness",
                                CategoryDescription = "Book your next SPA procedure",
                                CategoryImage = "/Images/Categories/wellness.jpg"},
                new Category() { CategoryName = "Dental Surgeries",
                                CategoryDescription = "Book your next dental procedure",
                                CategoryImage="/Images/Categories/dentist.jpg"},
                new Category() { CategoryName = "Make Up",
                                CategoryDescription = "Book your make up hour. Enjoy!",
                                CategoryImage = "/Images/Categories/make-up.jpg"},
                new Category() { CategoryName = "Other",
                                CategoryDescription = "Book your hour in some other hourly services",
                                CategoryImage = "/Images/Categories/other.jpg"}


            };

            context.Categories.AddOrUpdate(categories.ToArray());
        }
    }
}
