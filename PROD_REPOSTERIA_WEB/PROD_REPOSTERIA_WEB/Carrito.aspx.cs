using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;

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
            // Hide container by default
            cardCart.Visible = false;
            pnlEmpty.Visible = false;

            var carritoRaw = Session["Carrito"] as List<int>;
            if (carritoRaw == null || carritoRaw.Count == 0)
            {
                pnlEmpty.Visible = true;
                return;
            }

            // Contar cantidades por IdPostre
            var quantities = carritoRaw
                .GroupBy(id => id)
                .ToDictionary(g => g.Key, g => g.Count());

            var ids = quantities.Keys.ToList();
            if (ids.Count == 0)
            {
                pnlEmpty.Visible = true;
                return;
            }

            // Query DB una sola vez con WHERE IN (...)
            DataTable dt = new DataTable();
            dt.Columns.Add("IdPostre", typeof(int));
            dt.Columns.Add("Imagen", typeof(string));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("Precio", typeof(decimal));
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("Subtotal", typeof(decimal));

            decimal total = 0m;

            // Construir IN parameters
            var paramNames = new List<string>();
            for (int i = 0; i < ids.Count; i++)
                paramNames.Add("@id" + i);

            string sql = $"SELECT IdPostre, Nombre, Descripcion, Precio, Imagen FROM Postres WHERE IdPostre IN ({string.Join(", ", paramNames)})";

            using (SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["ConexionReposteria"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                for (int i = 0; i < ids.Count; i++)
                {
                    cmd.Parameters.AddWithValue(paramNames[i], ids[i]);
                }

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int id = Convert.ToInt32(dr["IdPostre"]);
                        string nombre = dr["Nombre"]?.ToString() ?? "";
                        string descripcion = dr["Descripcion"]?.ToString() ?? "";
                        string imagen = dr["Imagen"]?.ToString() ?? "";
                        decimal precio = dr["Precio"] != DBNull.Value ? Convert.ToDecimal(dr["Precio"]) : 0m;
                        int qty = quantities.ContainsKey(id) ? quantities[id] : 1;
                        decimal subtotal = precio * qty;

                        DataRow row = dt.NewRow();
                        row["IdPostre"] = id;
                        row["Imagen"] = imagen;
                        row["Nombre"] = nombre;
                        row["Descripcion"] = descripcion;
                        row["Precio"] = precio;
                        row["Cantidad"] = qty;
                        row["Subtotal"] = subtotal;
                        dt.Rows.Add(row);

                        total += subtotal;
                    }
                }
            }

            // Bind
            rptCart.DataSource = dt;
            rptCart.DataBind();

            lblTotal.Text = total.ToString("F2");

            // Mostrar sección de carrito
            cardCart.Visible = true;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Compra simulada: limpiar Session y notificar con modal (Site.Master)
            Session["Carrito"] = null;

            // Registrar script para mostrar modal y redirigir cuando la modal se cierre
            string script = @"
                (function(){
                    showAppAlert('Compra realizada con éxito (simulada)', 'Éxito');
                    var modal = document.getElementById('appModal');
                    if(modal){
                        modal.addEventListener('hidden.bs.modal', function(){ window.location = 'Catalogo.aspx'; }, { once: true });
                    } else {
                        window.location = 'Catalogo.aspx';
                    }
                })();";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "purchaseDone", script, true);
        }
    }
}