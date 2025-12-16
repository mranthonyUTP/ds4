using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROD_REPOSTERIA_WEB.Admin
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarReportes();

        }

        private void CargarReportes()
        {
            using (SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["ConexionReposteria"].ConnectionString))
            {
                cn.Open();

                // Total de postres
                SqlCommand cmdTotal = new SqlCommand(
                    "SELECT COUNT(*) FROM Postres", cn);
                lblTotalPostres.Text = cmdTotal.ExecuteScalar().ToString();

                // Precio promedio
                SqlCommand cmdProm = new SqlCommand(
                    "SELECT AVG(Precio) FROM Postres", cn);
                lblPromedio.Text = Convert.ToDecimal(cmdProm.ExecuteScalar()).ToString("F2");

                // Postre más caro
                SqlCommand cmdCaro = new SqlCommand(
                    "SELECT TOP 1 Nombre FROM Postres ORDER BY Precio DESC", cn);
                lblMasCaro.Text = cmdCaro.ExecuteScalar().ToString();

                // Postre más barato
                SqlCommand cmdBarato = new SqlCommand(
                    "SELECT TOP 1 Nombre FROM Postres ORDER BY Precio ASC", cn);
                lblMasBarato.Text = cmdBarato.ExecuteScalar().ToString();
            }
        }
    }
}