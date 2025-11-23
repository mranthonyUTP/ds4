using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio_154
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SumarButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Numero1TextBox.Text) &&
                !string.IsNullOrEmpty(Numero2TextBox.Text))
            {
                sumarNumeros(Numero1TextBox.Text, Numero2TextBox.Text);
            }                
        }

        private void sumarNumeros(string Numero1, string Numero2)
        {
            int numero1 = int.Parse(Numero1TextBox.Text);
            int numero2 = int.Parse(Numero2TextBox.Text);

            int suma = numero1 + numero2;
            Results.Text = $"El resultado es: {suma}";

        }
    }
}