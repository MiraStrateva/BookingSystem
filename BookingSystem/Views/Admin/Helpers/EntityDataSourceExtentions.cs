namespace BookingSystem.Views.Admin
{
    using System;
    using System.Collections.Specialized;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public static class EntityDataSourceExtentions
    {
        private static bool DefaultOperationCallback(int affectedRows, Exception ex)
        {
            return false;
        }

        public static void Insert(this EntityDataSource dataSource)
        {
            (dataSource as IDataSource).GetView(string.Empty).Insert(new OrderedDictionary(), DefaultOperationCallback);
        }
    }
}