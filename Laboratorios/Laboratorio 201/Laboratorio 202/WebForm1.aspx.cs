using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio_202
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtN.Text, out int n) || n <= 0)
            {
                ltTabla.Text = "<span style='color:red;'>Ingrese un número entero positivo.</span>";
                return;
            }

            string html = "<table border='1' cellpadding='6'>";

            for (int i = 0; i < n; i++)
            {
                html += "<tr>";

                for (int j = 0; j < n; j++)
                {
                    // Condición para la diagonal inversa:
                    // i + j == n - 1
                    if (i + j == n - 1)
                        html += "<td style='text-align:center;'>1</td>";
                    else
                        html += "<td style='text-align:center;'>0</td>";
                }

                html += "</tr>";
            }

            html += "</table>";

            ltTabla.Text = html;
        }


    }
}