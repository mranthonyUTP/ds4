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

                        // Plain-text comparison, using parameters to avoid SQL injection
                        if (string.Equals(password, stored, StringComparison.Ordinal))
                        {
                            // Successful login: set session values
                            Session["User"] = nombre;
                            Session["UserRole"] = rol;

                            // choose server-resolved redirect target based on role
                            string redirectVirtual = rol.Equals("Admin", StringComparison.OrdinalIgnoreCase)
                                ? "~/Admin/Reportes.aspx"
                                : "~/LandingPage.aspx";

                            // Resolve virtual path to an absolute application path before sending to client
                            string redirectUrl = ResolveUrl(redirectVirtual);

                            // --- Simple server-side redirect (reliable) ---
                            // Use false to avoid ThreadAbortException and call CompleteRequest
                            Response.Redirect(redirectUrl, false);
                            HttpContext.Current.ApplicationInstance.CompleteRequest();
                            return;

                            /* 
                            // --- Alternative: client-side redirect after showing modal ---
                            // Uncomment if you need to display the app modal then redirect on close.
                            string safe = HttpUtility.JavaScriptStringEncode("Bienvenido " + nombre);
                            string safeRedirect = HttpUtility.JavaScriptStringEncode(redirectUrl);
                            string script = $@"
(function waitForAppAlert(){{
    if (typeof showAppAlert === 'function') {{
        showAppAlert('{safe}', 'Bienvenido');
        var modal = document.getElementById('appModal');
        if(modal){{
            modal.addEventListener('hidden.bs.modal', function(){{ window.location.replace('{safeRedirect}'); }}, {{ once: true }});
        }} else {{
            window.location.replace('{safeRedirect}');
        }}
    }} else {{
        setTimeout(waitForAppAlert, 50);
    }}
}})();";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "loginOk", script, true);
                            */
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