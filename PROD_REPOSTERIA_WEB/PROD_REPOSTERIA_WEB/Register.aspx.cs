using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace PROD_REPOSTERIA_WEB
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            string nombre = txtUsuario.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ShowAlert("Completa todos los campos.", "Error");
                return;
            }

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionReposteria"].ConnectionString))
                {
                    cn.Open();

                    using (SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(1) FROM Usuarios WHERE Nombre = @nombre OR Email = @email", cn))
                    {
                        cmdCheck.Parameters.AddWithValue("@nombre", nombre);
                        cmdCheck.Parameters.AddWithValue("@email", email);
                        var exists = Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0;
                        if (exists)
                        {
                            ShowAlert("El usuario o email ya está en uso.", "Atención");
                            return;
                        }
                    }

                    // Store plain password as requested, but parameterized to avoid SQL injection
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Usuarios (Nombre, Email, Password, Rol, FechaRegistro, Estado) VALUES (@nombre, @email, @password, @rol, GETDATE(), 1)", cn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@rol", "Usuario");
                        cmd.ExecuteNonQuery();
                    }
                }

                string msg = HttpUtility.JavaScriptStringEncode("Cuenta creada. Ahora puedes iniciar sesión.");
                string script = $@"
(function waitForAppAlert(){{
    if (typeof showAppAlert === 'function') {{
        showAppAlert('{msg}', 'Registrado');
    }} else {{
        setTimeout(waitForAppAlert, 50);
    }}
}})();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "registered", script, true);

                // clear form
                txtUsuario.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
                txtConfirm.Text = "";
            }
            catch (Exception)
            {
                ShowAlert("Error al crear la cuenta. Intenta más tarde.", "Error");
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