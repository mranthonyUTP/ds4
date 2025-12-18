using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROD_REPOSTERIA_WEB.Admin
{
    public partial class Postres : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // ensure only admins access (defense in depth)
            var role = Session["UserRole"] as string;
            if (string.IsNullOrEmpty(role) || !role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/LandingPage.aspx");
                return;
            }

            if (!IsPostBack)
                CargarPostres();
        }

        // ===============================
        // LISTAR POSTRES
        // ===============================
        private void CargarPostres()
        {
            using (SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["ConexionReposteria"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_postres_listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                gvPostres.DataSource = cmd.ExecuteReader();
                gvPostres.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // image URL can be taken from txtImagen or obtained from API as fallback
            string imagenUrl = string.IsNullOrWhiteSpace(txtImagen.Text) ? ObtenerImagenDesdeAPI() : txtImagen.Text.Trim();

            using (SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["ConexionReposteria"].ConnectionString))
            {
                SqlCommand cmd;

                if (string.IsNullOrEmpty(hfIdPostre.Value))
                {
                    cmd = new SqlCommand("sp_postres_insertar", cn);
                }
                else
                {
                    cmd = new SqlCommand("sp_postres_actualizar", cn);
                    cmd.Parameters.AddWithValue("@IdPostre", hfIdPostre.Value);
                }

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text.Trim());
                decimal precio = 0m;
                decimal.TryParse(txtPrecio.Text.Trim(), out precio);
                cmd.Parameters.AddWithValue("@Precio", precio);
                cmd.Parameters.AddWithValue("@Imagen", imagenUrl);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

            LimpiarFormulario();
            CargarPostres();

            // Inform user
            ShowAlert("Postre guardado correctamente.", "Éxito");
        }

        // ===============================
        // EDITAR - RowCommand
        // ===============================
        protected void gvPostres_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                hfIdPostre.Value = id.ToString();
                CargarPostrePorId(id);
            }
        }

        // ===============================
        // RowDataBound
        // ===============================
        protected void gvPostres_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row == null) return;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // colocar data-id con el IdPostre (DataKey debe estar definido en el GridView)
                try
                {
                    var key = gvPostres.DataKeys[e.Row.RowIndex];
                    if (key != null && key.Value != null)
                    {
                        e.Row.Attributes["data-id"] = key.Value.ToString();
                    }
                }
                catch
                {
                    // no hacemos nada si falla, sólo prevención
                }

                // opcional: usar el campo Nombre como tooltip si existe en DataItem
                try
                {
                    var drv = e.Row.DataItem as System.Data.IDataRecord;
                    if (drv != null)
                    {
                        var nombre = drv["Nombre"]?.ToString();
                        if (!string.IsNullOrEmpty(nombre))
                        {
                            e.Row.ToolTip = nombre;
                        }
                    }
                }
                catch
                {
                    // ignore
                }
            }
        }

        // ===============================
        // CARGAR POSTRE POR ID
        // ===============================
        private void CargarPostrePorId(int id)
        {
            using (SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["ConexionReposteria"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM Postres WHERE IdPostre = @id", cn);
                cmd.Parameters.AddWithValue("@id", id);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtNombre.Text = dr["Nombre"].ToString();
                    txtDescripcion.Text = dr["Descripcion"].ToString();
                    txtPrecio.Text = dr["Precio"].ToString();
                    txtImagen.Text = dr["Imagen"]?.ToString() ?? "";
                }
                dr.Close();
            }
        }

        // ===============================
        // LIMPIAR FORMULARIO
        // ===============================
        private void LimpiarFormulario()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtImagen.Text = "";
            hfIdPostre.Value = "";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private string ObtenerImagenDesdeAPI()
        {
            // API externa de imágenes (permitida en red corporativa)
            return "https://picsum.photos/id/1080/300/200";
        }

        // ===============================
        // Eliminación confirmada desde modal (eliminación completa con limpieza de referencias)
        // ===============================
        protected void btnDeleteConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hfDeleteId.Value))
                return;

            if (!int.TryParse(hfDeleteId.Value, out int id))
                return;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionReposteria"].ConnectionString))
                {
                    cn.Open();
                    using (SqlTransaction tran = cn.BeginTransaction())
                    {
                        try
                        {
                            // 1) Ajustar totales en Compras que contienen este postre
                            using (SqlCommand cmdAdjust = new SqlCommand(
                                "SELECT IdCompra, SUM(Cantidad * PrecioUnitario) AS Deduct FROM DetalleCompra WHERE IdPostre = @IdPostre GROUP BY IdCompra",
                                cn, tran))
                            {
                                cmdAdjust.Parameters.AddWithValue("@IdPostre", id);
                                using (SqlDataReader rd = cmdAdjust.ExecuteReader())
                                {
                                    var adjustments = new List<(int IdCompra, decimal Deduct)>();
                                    while (rd.Read())
                                    {
                                        int idCompra = rd["IdCompra"] != DBNull.Value ? Convert.ToInt32(rd["IdCompra"]) : 0;
                                        decimal deduct = rd["Deduct"] != DBNull.Value ? Convert.ToDecimal(rd["Deduct"]) : 0m;
                                        adjustments.Add((idCompra, deduct));
                                    }
                                    rd.Close();

                                    foreach (var adj in adjustments)
                                    {
                                        using (SqlCommand cmdUpd = new SqlCommand(
                                            "UPDATE Compras SET Total = ISNULL(Total,0) - @Deduct WHERE IdCompra = @IdCompra",
                                            cn, tran))
                                        {
                                            cmdUpd.Parameters.AddWithValue("@Deduct", adj.Deduct);
                                            cmdUpd.Parameters.AddWithValue("@IdCompra", adj.IdCompra);
                                            cmdUpd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }

                            // 2) Eliminar detalles de pedidos/ventas que referencien el postre
                            using (SqlCommand cmdDelDetalle = new SqlCommand("DELETE FROM DetalleCompra WHERE IdPostre = @IdPostre", cn, tran))
                            {
                                cmdDelDetalle.Parameters.AddWithValue("@IdPostre", id);
                                cmdDelDetalle.ExecuteNonQuery();
                            }

                            using (SqlCommand cmdDelPedidoDet = new SqlCommand("DELETE FROM PedidoDetalle WHERE IdPostre = @IdPostre", cn, tran))
                            {
                                cmdDelPedidoDet.Parameters.AddWithValue("@IdPostre", id);
                                cmdDelPedidoDet.ExecuteNonQuery();
                            }

                            // 3) Eliminar Compras que quedaron sin detalles
                            using (SqlCommand cmdDelEmptyCompras = new SqlCommand(
                                "DELETE FROM Compras WHERE IdCompra NOT IN (SELECT DISTINCT IdCompra FROM DetalleCompra)",
                                cn, tran))
                            {
                                cmdDelEmptyCompras.ExecuteNonQuery();
                            }

                            // 4) Eliminar Pedidos que quedaron sin detalles
                            using (SqlCommand cmdDelEmptyPedidos = new SqlCommand(
                                "DELETE FROM Pedidos WHERE IdPedido NOT IN (SELECT DISTINCT IdPedido FROM PedidoDetalle)",
                                cn, tran))
                            {
                                cmdDelEmptyPedidos.ExecuteNonQuery();
                            }

                            // 5) Finalmente eliminar el postre
                            using (SqlCommand cmdDelPostre = new SqlCommand("DELETE FROM Postres WHERE IdPostre = @IdPostre", cn, tran))
                            {
                                cmdDelPostre.Parameters.AddWithValue("@IdPostre", id);
                                int affected = cmdDelPostre.ExecuteNonQuery();
                                if (affected == 0)
                                {
                                    // si no se eliminó (por ejemplo sp_postres_eliminar usado antes), intentar con stored procedure
                                    using (SqlCommand cmdProc = new SqlCommand("sp_postres_eliminar", cn, tran))
                                    {
                                        cmdProc.CommandType = CommandType.StoredProcedure;
                                        cmdProc.Parameters.AddWithValue("@IdPostre", id);
                                        cmdProc.ExecuteNonQuery();
                                    }
                                }
                            }

                            tran.Commit();

                            hfDeleteId.Value = "";
                            CargarPostres();
                            ShowAlert("Postre y sus referencias eliminadas correctamente.", "Eliminado");
                            return;
                        }
                        catch (Exception)
                        {
                            try { tran.Rollback(); } catch { /* ignore */ }
                            // fallback: si algo falla, intentar marcar inactivo para preservar integridad
                            using (SqlCommand cmdSoft = new SqlCommand("UPDATE Postres SET Estado = 0 WHERE IdPostre = @IdPostre", cn))
                            {
                                cmdSoft.Parameters.AddWithValue("@IdPostre", id);
                                cmdSoft.ExecuteNonQuery();
                            }
                            hfDeleteId.Value = "";
                            CargarPostres();
                            ShowAlert("No fue posible eliminar completamente el postre. Se marcó como inactivo.", "Atención");
                            return;
                        }
                    }
                }
            }
            catch (Exception)
            {
                ShowAlert("Ocurrió un error al procesar la eliminación. Intenta más tarde.", "Error");
            }
        }

        // ===============================
        // UTIL: mostrar modal desde server
        // ===============================
        private void ShowAlert(string message, string title = "Información")
        {
            string safeMsg = System.Web.HttpUtility.JavaScriptStringEncode(message);
            string safeTitle = System.Web.HttpUtility.JavaScriptStringEncode(title);
            string script = $@"
(function waitForAppAlert(){{
    if (typeof showAppAlert === 'function') {{
        showAppAlert('{safeMsg}', '{safeTitle}');
    }} else {{
        setTimeout(waitForAppAlert, 50);
    }}
}})();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script, true);
        }
    }
}