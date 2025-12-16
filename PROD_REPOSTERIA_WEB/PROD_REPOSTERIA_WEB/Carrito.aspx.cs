using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PROD_REPOSTERIA_WEB
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarCarrito();
        }

        private void CargarCarrito()
        {
            if (Session["Carrito"] == null)
                return;

            List<int> carrito = (List<int>)Session["Carrito"];
            if (carrito.Count == 0)
                return;

            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Precio", typeof(decimal));

            decimal total = 0;

            using (SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["ConexionReposteria"].ConnectionString))
            {
                cn.Open();

                foreach (int id in carrito)
                {
                    SqlCommand cmd = new SqlCommand(
                        "SELECT Nombre, Precio FROM Postres WHERE IdPostre=@id", cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dt.Rows.Add(dr["Nombre"], dr["Precio"]);
                        total += Convert.ToDecimal(dr["Precio"]);
                    }
                    dr.Close();
                }
            }

            gvCarrito.DataSource = dt;
            gvCarrito.DataBind();
            lblTotal.Text = total.ToString("F2");
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Compra simulada
            Session["Carrito"] = null;

            Response.Write("<script>alert('Compra realizada con éxito (simulada)');</script>");
            Response.Redirect("Catalogo.aspx");
        }
    }
}
