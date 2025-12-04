using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Parcial_3
{
    public partial class Agregar : System.Web.UI.Page
    {
        string conexion = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO AH_Articulos 
                    (Titulo, Autores, Resumen, Revista, AnioPublicacion) 
                    VALUES 
                    (@Titulo, @Autores, @Resumen, @Revista, @Anio)", cn);

                cmd.Parameters.AddWithValue("@Titulo", txtTitulo.Text);
                cmd.Parameters.AddWithValue("@Autores", txtAutores.Text);
                cmd.Parameters.AddWithValue("@Resumen", txtResumen.Text);
                cmd.Parameters.AddWithValue("@Revista", txtRevista.Text);
                cmd.Parameters.AddWithValue("@Anio", txtAnio.Text);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("Default.aspx");
        }
    }
}
