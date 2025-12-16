using System;
using System.Web;
using System.Web.UI;

namespace PROD_REPOSTERIA_WEB
{
    public partial class Logout : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                Session.Abandon();
            }
            catch { /* ignore */ }

            // redirect to landing
            Response.Redirect("~/LandingPage.aspx");
        }
    }
}