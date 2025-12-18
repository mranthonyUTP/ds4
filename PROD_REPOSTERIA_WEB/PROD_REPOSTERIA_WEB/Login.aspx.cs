using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace PROD_REPOSTERIA_WEB
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            string userOrEmail = txtUser.Text.Trim();
            string password = txtPassword.Text;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionReposteria"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT Nombre, Password, Rol FROM Usuarios WHERE (Nombre = @u OR Email = @u) AND Estado = 1", cn))
                {
                    cmd.Parameters.AddWithValue("@u", userOrEmail);
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (!dr.Read())
                        {
                            ShowAlert("Usuario o contraseña incorrectos.", "Error");
                            return;
                        }

                        string nombre = dr["Nombre"]?.ToString() ?? "";
                        string stored = dr["Password"]?.ToString() ?? "";
                        string rol = dr["Rol"]?.ToString() ?? "Usuario";

                        // Se hacen comparaciones en texto y utilizando parametros para evitar los SQL inyections
                        if (string.Equals(password, stored, StringComparison.Ordinal))
                        {
                            // Asignacion de roles y variables de sesión
                            Session["User"] = nombre;
                            Session["UserRole"] = rol;

                            string redirectVirtual = rol.Equals("Admin", StringComparison.OrdinalIgnoreCase)
                                ? "~/Admin/Reportes.aspx"
                                : "~/LandingPage.aspx";

                            string redirectUrl = ResolveUrl(redirectVirtual);

                            Response.Redirect(redirectUrl, false);
                            HttpContext.Current.ApplicationInstance.CompleteRequest();
                            return;

                        }
                        else
                        {
                            ShowAlert("Usuario o contraseña incorrectos.", "Error");
                        }
                    }
                }
            }
            catch (Exception)
            {
                ShowAlert("Error en el inicio de sesión. Intenta más tarde.", "Error");
                // log exception in production
            }
        }

        private void ShowAlert(string message, string title = "Información")
        {
            string safeMsg = HttpUtility.JavaScriptStringEncode(message);
            string safeTitle = HttpUtility.JavaScriptStringEncode(title);
            string script = $@"
(function waitAlert(){{
    if (typeof showAppAlert === 'function') {{
        showAppAlert('{safeMsg}', '{safeTitle}');
    }} else {{
        setTimeout(waitAlert, 50);
    }}
}})();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script, true);
        }
    }
}