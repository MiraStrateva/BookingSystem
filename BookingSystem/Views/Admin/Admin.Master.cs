namespace BookingSystem.Views.Admin
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Web;
    using System.Web.UI.WebControls;

    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}