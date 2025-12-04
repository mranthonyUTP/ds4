using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Parcial_3
{
    public partial class _Default : Page
    {
        string conexion = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarArticulos();
            }
        }

        void CargarArticulos(string filtro = "")
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                string query = "SELECT IdArticulo, Titulo, Autores, Revista, AnioPublicacion FROM AH_Articulos";

                if (!string.IsNullOrEmpty(filtro))
                    query += " WHERE Titulo LIKE @filtro";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    if (!string.IsNullOrEmpty(filtro))
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        GridViewArticulos.DataSource = dt;
                        GridViewArticulos.DataBind();
                    }
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarArticulos(txtBuscar.Text.Trim());
        }

        // Este es el manejador correcto para el botón eliminar del GridView
        protected void GridViewArticulos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(GridViewArticulos.DataKeys[e.RowIndex].Value);

                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM AH_Articulos WHERE IdArticulo=@id", cn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                // recargar la grilla
                CargarArticulos(txtBuscar.Text.Trim());
            }
            catch (Exception ex)
            {
                // opcional: mostrar mensaje o loguear
                // lblError.Text = "Error al eliminar: " + ex.Message;
                throw;
            }
        }
    }
}
