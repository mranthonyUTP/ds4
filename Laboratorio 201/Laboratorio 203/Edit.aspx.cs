using CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio_203
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        DataAccess da = new DataAccess();
        int? idEditing = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
                idEditing = int.Parse(Request.QueryString["id"]);

            if (!IsPostBack && idEditing != null)
                LoadProduct(idEditing.Value);
        }

        private void LoadProduct(int id)
        {
            var row = da.GetById(id);
            if (row != null)
            {
                txtID.Text = row["ID"].ToString();
                txtID.Enabled = false;

                txtNombre.Text = row["NOMBRE"].ToString();
                txtPrecio.Text = row["PRECIO"].ToString();
                txtStock.Text = row["STOCK"].ToString();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            string nombre = txtNombre.Text;
            decimal precio = decimal.Parse(txtPrecio.Text);
            int stock = int.Parse(txtStock.Text);

            if (idEditing == null)
                da.Insert(id, nombre, precio, stock);
            else
                da.Update(id, nombre, precio, stock);

            Response.Redirect("Default.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}