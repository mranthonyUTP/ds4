using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio_201
{
    public partial class Default : System.Web.UI.Page       //WebForm1
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNumero.Text, out int numero))
            {
                ltResultado.Text = "<span style='color:red;'>Ingrese un número válido.</span>";
                return;
            }

            string tabla = "<h3>Tabla del " + numero + "</h3>";

            for (int i = 1; i <= 25; i++)
            {
                tabla += $"{numero} x {i} = {numero * i}<br />";
            }

            ltResultado.Text = tabla;
        }

    }
}