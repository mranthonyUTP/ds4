using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRUD;

namespace Laboratorio_203
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataAccess da = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindGrid();
        }

        private void BindGrid()
        {
            gvProductos.DataSource = da.GetAll();
            gvProductos.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit.aspx");
        }

        protected void gvProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(gvProductos.DataKeys[e.NewEditIndex].Value);
            Response.Redirect($"Edit.aspx?id={id}");
        }

        protected void gvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvProductos.DataKeys[e.RowIndex].Value);
            da.Delete(id);
            BindGrid();
        }
    }
}