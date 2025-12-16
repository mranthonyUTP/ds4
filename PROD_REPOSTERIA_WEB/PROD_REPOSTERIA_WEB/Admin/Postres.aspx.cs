using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROD_REPOSTERIA_WEB.Admin
{
    public partial class Postres : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            string imagenUrl = ObtenerImagenDesdeAPI();

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
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@Precio", decimal.Parse(txtPrecio.Text));
                cmd.Parameters.AddWithValue("@Imagen", imagenUrl);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

            LimpiarFormulario();
            CargarPostres();
        }


        // ===============================
        // OBTENER IMAGEN ACTUAL AUX
        // ===============================
        private string ObtenerImagenActual(int id)
        {
            using (SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["ConexionReposteria"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Imagen FROM Postres WHERE IdPostre = @id", cn);
                cmd.Parameters.AddWithValue("@id", id);

                cn.Open();
                object resultado = cmd.ExecuteScalar();

                return resultado != null ? resultado.ToString() : "";
            }
        }



        // ===============================
        // EDITAR / ELIMINAR
        // ===============================
        protected void gvPostres_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Eliminar")
            {
                using (SqlConnection cn = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["ConexionReposteria"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_postres_eliminar", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPostre", id);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                CargarPostres();
            }

            if (e.CommandName == "Editar")
            {
                hfIdPostre.Value = id.ToString();
                CargarPostrePorId(id);
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
                }
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



    }

    public class MealResponse
    {
        public List<Meal> meals { get; set; }
    }

    public class Meal
    {
        public string strMealThumb { get; set; }
    }
}
