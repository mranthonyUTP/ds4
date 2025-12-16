using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROD_REPOSTERIA_WEB
{
    public partial class About : Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            string cs = ConfigurationManager
                .ConnectionStrings["ConexionReposteria"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = @"SELECT IdUsuario, Rol 
                               FROM Usuarios 
                               WHERE Email = @Email AND Password = @Password AND Estado = 1";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Guardar sesión
                    Session["IdUsuario"] = reader["IdUsuario"].ToString();
                    Session["Rol"] = reader["Rol"].ToString();

                    // Redirección por rol
                    if (Session["Rol"].ToString() == "Admin")
                        Response.Redirect("~/Admin/Reportes.aspx");
                    else
                        Response.Redirect("~/Catalogo.aspx");
                }
                else
                {
                    lblMensaje.Text = "Credenciales incorrectas";
                }
            }
        }
    }
}