using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace PROD_REPOSTERIA_WEB.Admin
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Authorization: only allow Admin role to access this page
            var role = Session["UserRole"] as string;
            if (string.IsNullOrEmpty(role) || !role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                // Redirect non-admin users back to landing page
                Response.Redirect("~/LandingPage.aspx");
                return;
            }

            if (!IsPostBack)
                CargarReportes();
        }

        private void CargarReportes()
        {
            // prepare DataTable for top expensive repeater
            var dtTopExp = new DataTable();
            dtTopExp.Columns.Add("Nombre", typeof(string));
            dtTopExp.Columns.Add("Precio", typeof(decimal));

            using (SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["ConexionReposteria"].ConnectionString))
            {
                cn.Open();

                // Total de postres
                using (SqlCommand cmdTotal = new SqlCommand("SELECT COUNT(*) FROM Postres", cn))
                {
                    object tot = cmdTotal.ExecuteScalar();
                    lblTotalPostres.Text = (tot != null ? tot.ToString() : "0");
                }

                // Precio promedio
                using (SqlCommand cmdProm = new SqlCommand("SELECT AVG(Precio) FROM Postres", cn))
                {
                    object prom = cmdProm.ExecuteScalar();
                    decimal promDec = prom != null && prom != DBNull.Value ? Convert.ToDecimal(prom) : 0m;
                    lblPromedio.Text = promDec.ToString("F2");
                }

                // Postre más caro
                using (SqlCommand cmdCaro = new SqlCommand("SELECT TOP 1 Nombre FROM Postres WHERE Estado = 1 ORDER BY Precio DESC", cn))
                {
                    object caro = cmdCaro.ExecuteScalar();
                    lblMasCaro.Text = caro != null ? caro.ToString() : "-";
                }

                // Postre más barato
                using (SqlCommand cmdBarato = new SqlCommand("SELECT TOP 1 Nombre FROM Postres WHERE Estado = 1 ORDER BY Precio ASC", cn))
                {
                    object barato = cmdBarato.ExecuteScalar();
                    lblMasBarato.Text = barato != null ? barato.ToString() : "-";
                }

                // Top 5 más caros
                using (SqlCommand cmdTop = new SqlCommand("SELECT TOP 5 Nombre, Precio FROM Postres WHERE Estado = 1 ORDER BY Precio DESC", cn))
                using (SqlDataReader dr = cmdTop.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string nombre = dr["Nombre"]?.ToString() ?? "";
                        decimal precio = dr["Precio"] != DBNull.Value ? Convert.ToDecimal(dr["Precio"]) : 0m;
                        var row = dtTopExp.NewRow();
                        row["Nombre"] = nombre;
                        row["Precio"] = precio;
                        dtTopExp.Rows.Add(row);
                    }
                }
            }

            // bind only the expensive repeater
            rptTopExpensive.DataSource = dtTopExp;
            rptTopExpensive.DataBind();
        }
    }
}