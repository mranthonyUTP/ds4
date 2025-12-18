using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Parcial_2
{
    public partial class Conversor : Form
    {
        // 🔹 Variables globales
        decimal monto = 0;
        string MonedaSeleccionada = "";


        //string connection = "Server=(localdb)\\MSSQLLocalDB;Database=Parcial2;Integrated Security=true;Trusted_Connection=True;TrustServerCertificate=True;";

        //SqlConnection conexion = new SqlConnection();

        String conexionString = @"Server=MSI\\SQLEXPRESS;Database=Parcial;Integrated Security=True;TrustServerCertificate=True;";

        SqlConnection conexion = new SqlConnection(conexionString);

        //SqlConnection conexion = new SqlConnection("server=MSI\\SQLEXPRESS; database=Parcial; Integrated Security=SSPI; TrustServerCertificate=true");

        conexion.Open();


        public Conversor()
        {
            InitializeComponent();
        }

        private void Conversor_Load(object sender, EventArgs e)
        {
            // 🔹 Cargar las monedas en el DropDown al iniciar
            Monedas_Dropdown.Items.Add("USD");
            Monedas_Dropdown.Items.Add("EUR");
            Monedas_Dropdown.Items.Add("COP");

            // 🔹 Cargar las conversiones existentes
            //CargarConversiones();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Moneda_text_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Moneda_text.Text))
                {
                    monto = Convert.ToDecimal(Moneda_text.Text);
                }
                else
                {
                    monto = 0;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingrese solo números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Moneda_text.Text = "";
                monto = 0;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Número fuera de rango.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Moneda_text.Text = "";
                monto = 0;
            }
        }

        private void Monedas_Dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Monedas_Dropdown.SelectedItem != null)
            {
                MonedaSeleccionada = Monedas_Dropdown.SelectedItem.ToString();
            }
            else
            {
                MonedaSeleccionada = "";
            }
        }

        private void Convertir_btn_Click(object sender, EventArgs e)
        {
            //// 🔹 Validaciones
            //if (monto <= 0)
            //{
            //    MessageBox.Show("Ingrese un monto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (string.IsNullOrWhiteSpace(MonedaSeleccionada))
            //{
            //    MessageBox.Show("Seleccione una moneda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //// 🔹 Calcular el monto convertido
            //decimal montoConvertido = ConvertirMonto(monto, MonedaSeleccionada);

            //// 🔹 Guardar en base de datos
            //try
            //{
            //    using (SqlConnection conn = new SqlConnection(connectionString))
            //    {
            //        conn.Open();
            //        string query = "INSERT INTO Conversiones (MontoOriginal, MonedaOriginal, MontoConvertido) VALUES (@Monto, @Moneda, @MontoConv)";
            //        using (SqlCommand cmd = new SqlCommand(query, conn))
            //        {
            //            cmd.Parameters.AddWithValue("@Monto", monto);
            //            cmd.Parameters.AddWithValue("@Moneda", MonedaSeleccionada);
            //            cmd.Parameters.AddWithValue("@MontoConv", montoConvertido);
            //            cmd.ExecuteNonQuery();
            //        }
            //    }

            //    MessageBox.Show("Conversión guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    CargarConversiones(); // refrescar el DataGridView
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al guardar en la base de datos: " + ex.Message);
            //}
        }
    }
}

        // 🔹 Método para mostrar los registros en el DataGridView
        //private void CargarConversiones()
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            string query = "SELECT MontoOriginal, MonedaOriginal, MontoConvertido FROM Conversiones";
        //            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
        //            {
        //                DataTable dt = new DataTable();
        //                da.Fill(dt);
        //                dataGridView1.DataSource = dt;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al cargar los datos: " + ex.Message);
        //    }
        //}

        // 🔹 Lógica de conversión de ejemplo (puedes  cambiarla)
        //private decimal ConvertirMonto(decimal monto, string moneda)
        //{
        //    switch (moneda)
        //    {
        //        case "USD": return monto;
        //        case "EUR": return monto * 0.92m;      // 1 USD = 0.92 EUR (ejemplo)
