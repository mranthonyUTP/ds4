using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace parcial2._1
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=DESKTOP-O5ASI20\\SQLEXPRESS;Initial Catalog=Parcial;Integrated Security=True";

        private const double KG = 0.453592;
        private const double METRO = 0.3048;

        public Form1()
        {
            InitializeComponent();
            CargarRegistros();
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            double peso = 0;
            double altura = 0;

            try
            {

                if (!double.TryParse(txtPeso.Text, out peso) || !double.TryParse(txtAltura.Text, out altura))
                {
                    MessageBox.Show("Por favor, ingrese valores numéricos válidos para Peso y Altura.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (peso <= 0 || altura <= 0)
                {
                    MessageBox.Show("El Peso y la Altura deben ser valores positivos.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double peso_kg = peso;
                double altura_m = altura;

                if (chkLibras.Checked)
                {
                    peso_kg *= KG;
                }

                if (chkPies.Checked)
                {
                    altura_m *= METRO;
                }

                double imc = peso_kg / (altura_m * altura_m);
                string clasificacion = ObtenerClasificacionIMC(imc);
                string resultadoFormateado = imc.ToString("F2");

                lblIMC.Text = $"IMC: {resultadoFormateado} ({clasificacion})";

                GuardarRegistroIMC(peso_kg, altura_m, imc);

                CargarRegistros();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string ObtenerClasificacionIMC(double imc)
        {
            if (imc < 18.5) return "Bajo Peso";
            if (imc < 25.0) return "Peso Normal";
            if (imc < 30.0) return "Sobrepeso";
            return "Obesidad";
        }
        private void GuardarRegistroIMC(double peso_kg, double altura_m, double imc)
        {
            string query = "INSERT INTO RegistrosIMC (FechaHora, Peso, Altura, IMC) " +
                           "VALUES (@FechaHora, @Peso, @Altura, @IMC)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@FechaHora", DateTime.Now);
                        command.Parameters.AddWithValue("@Peso", peso_kg);
                        command.Parameters.AddWithValue("@Altura", altura_m);
                        command.Parameters.AddWithValue("@IMC", imc);

                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Error al guardar en la base de datos: {ex.Message}\nVerifique que la tabla 'RegistrosIMC' tenga las columnas 'Peso', 'Altura', y 'IMC'.", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CargarRegistros()
        {
            List<string> registros = new List<string>();

            string query = "SELECT FechaHora, Peso, Altura, IMC FROM RegistrosIMC ORDER BY FechaHora DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {

                            double peso_kg = Convert.ToDouble(reader["Peso"]);
                            double altura_m = Convert.ToDouble(reader["Altura"]);
                            double imc = Convert.ToDouble(reader["IMC"]);
                            DateTime fechaHora = Convert.ToDateTime(reader["FechaHora"]);

                            string clasificacion = ObtenerClasificacionIMC(imc);

                            string registro = $"{fechaHora:HH:mm} | IMC: {imc:F2} ({clasificacion}) | ({peso_kg:F2}kg/{altura_m:F2}m)";
                            registros.Add(registro);
                        }
                        reader.Close();
                    }
                    catch (SqlException ex)
                    {
                        registros.Add($"Error al cargar la BD. Verifique que la conexión y las columnas (Peso, Altura, IMC) sean correctas:\n{ex.Message}");
                    }
                }
            }
            lstRegistros.DataSource = null;
            lstRegistros.DataSource = registros;
        }
    }
}