using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//<asp:Image
//                runat="server"
//                ImageUrl='<%# Eval("Imagen") %>'
//                CssClass="card-img-top"
//                Height="200px"
//                Style="object-fit: cover;" />
//<img src='<%# Eval("Imagen") %>' class="card-img-top" style="height:200px; object-fit:cover;" />
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

        protected void rptPostres_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Comprar")
            {
                int idPostre = Convert.ToInt32(e.CommandArgument);

                List<int> carrito;

                if (Session["Carrito"] == null)
                    carrito = new List<int>();
                else
                    carrito = (List<int>)Session["Carrito"];

                carrito.Add(idPostre);
                Session["Carrito"] = carrito;

                ClientScript.RegisterStartupScript(this.GetType(),
                    "alert",
                    "alert('Postre agregado al carrito');",
                    true);
            }
        }
    }
}