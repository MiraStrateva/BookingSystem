using System;

namespace BookingSystem.MVP.Categories
{
    public class CategoryInsertEventArgs : EventArgs
    {
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }            

        public CategoryInsertEventArgs(string name, string description, string image)
        {
            this.name = name;
            this.description = description;
            this.image = image;
        }
    }
}
