using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Laboratorio_192;

namespace Laboratorio_192
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetItem_Click(object sender, EventArgs e)
        {
            Class1 api = new Class1();
            string result = api.GetItems();

            ltResultado.Text = result;
        }

    }
}