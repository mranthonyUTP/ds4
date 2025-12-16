using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROD_REPOSTERIA_WEB
{
    public partial class Catalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarCatalogo();
        }

        private void CargarCatalogo()
        {
            using (SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["ConexionReposteria"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT IdPostre, Nombre, Descripcion, Precio, Imagen FROM Postres", cn);

                cn.Open();
                rptPostres.DataSource = cmd.ExecuteReader();
                rptPostres.DataBind();
            }
        }

        // Ya no se usa para "Agregar" porque abrirá modal en cliente.
        protected void rptPostres_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            // dejar vacío o usar para otras acciones si conviene
        }

        // Handler invocado cuando el usuario confirma en la modal (postback desde btnConfirmPurchase)
        protected void btnConfirmPurchase_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hfPurchaseId.Value))
                return;

            int id;
            int qty;
            if (!int.TryParse(hfPurchaseId.Value, out id))
                return;
            if (!int.TryParse(hfPurchaseQty.Value, out qty) || qty < 1) qty = 1;

            List<int> carrito = Session["Carrito"] as List<int>;
            if (carrito == null) carrito = new List<int>();

            for (int i = 0; i < qty; i++)
            {
                carrito.Add(id);
            }

            Session["Carrito"] = carrito;

            // obtener nombre del postre para mensaje (seguro, por si se desea mostrar)
            string nombre = "";
            using (SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["ConexionReposteria"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT Nombre FROM Postres WHERE IdPostre = @id", cn);
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null) nombre = result.ToString();
            }

            // Limpiar campos
            hfPurchaseId.Value = "";
            hfPurchaseQty.Value = "";

            // Mostrar modal informativo (usa la función global definida en Site.Master)
            string safeName = HttpUtility.JavaScriptStringEncode(nombre);
            string script = $"showAppAlert('Se agregaron {qty} unidad(es) de {safeName} al carrito.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showAppAlert", script, true);
        }
    }
}