using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
namespace Parcial
{
    public partial class Form1 : Form
    {

        //conector base de datos

        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Parcial2;Trusted_Connection=True;TrustServerCertificate=True;";


        private static bool TestConnection(string connectionString1)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString1))
                {
                    connection.Open();

                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        MessageBox.Show("Conectado correctamente a la base de datos.");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo abrir la conexión.");
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error SQL: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error general: {ex.Message}");
                return false;
            }
        }



        int contador = 0;
        double fileSize;
        private bool isUpdatingTextBox3 = false; // evita reentrada al reponer texto inválido

        public Form1()
        {
            InitializeComponent();
            TestConnection(connectionString);
            radioButton1.Checked = true;

            textBox3.KeyPress += textBox3_KeyPress;

            // Cargar historial al iniciar
            CargarHistorial();
        }



        private void textBox3_TextChanged(object sender, EventArgs e)           // MB
        {
            if (isUpdatingTextBox3) return;

            isUpdatingTextBox3 = true;
            // Acepta enteros y decimales según la cultura actual
            if (double.TryParse(textBox3.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out double parsed) && parsed >= 0)
            {
                fileSize = parsed;
                // Si desea, puede actualizar UI aquí (ej. label) con el valor validado
            }
            else
            {
                // Valor inválido -> avisar y revertir al último valor válido
                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("Ingrese un número válido positivo (enteros o decimales).");
                    // Reponer el ultimo valor válido (fileSize). Si fileSize es 0 y desea campo vacío, adapte según preferencia.
                    textBox3.Text = fileSize == 0 ? string.Empty : fileSize.ToString(CultureInfo.CurrentCulture);
                    textBox3.SelectionStart = textBox3.Text.Length;
                }
            }
            isUpdatingTextBox3 = false;
        }

        // Evita que se escriban caracteres no numéricos en tiempo de tipeo.
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite teclas de control (backspace, etc.)
            if (char.IsControl(e.KeyChar)) return;

            var textBox = (TextBox)sender;
            char decimalSep = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            // Permitir un único separador decimal y dígitos
            if (e.KeyChar == decimalSep)
            {
                if (textBox.Text.Contains(decimalSep)) e.Handled = true;
                return;
            }

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)           // USB
        {
            if (double.TryParse(textBox2.Text, out double usbSize))
            {
                if (!ValidateUsbSize(usbSize))
                {

                    return;
                }

                double gbValue = ConvertirGB(usbSize);

            }
        }


        private double ConvertirGB(double valor)
        {
            // Returns value in GB
            if (radioButton1.Checked)
            {
                if (valor < 2048)
                {
                    return valor;
                }
            }
            else if (radioButton2.Checked)
            {
                if (valor <= 2)
                {
                    return valor * 1024;
                }
            }

            MessageBox.Show("Solo se permiten USB de hasta 2 TB.");
            textBox2.Clear();
            return 0;
        }


        private bool ValidateUsbSize(double usbSize)
        {
            if (radioButton1.Checked)
            {

                if (usbSize >= 2048)
                {
                    MessageBox.Show("En modo GB, el tamaño debe ser menor a 2048 GB (2 TB).");
                    textBox2.Clear();
                    return false;
                }
            }
            else if (radioButton2.Checked)
            {
                if (usbSize > 2)
                {
                    MessageBox.Show("En modo TB, el tamaño máximo permitido es 2 TB.");
                    textBox2.Clear();
                    return false;
                }
            }

            return true;
        }

        // labels
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validar que ambos campos tengan datos
            if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Debe ingresar el tamaño del USB y el tamaño del archivo.");
                return;
            }

            // Obtener tamaño del archivo (MB)
            if (!double.TryParse(textBox3.Text, out double fileSizeMB) || fileSizeMB <= 0)
            {
                MessageBox.Show("Ingrese un tamaño de archivo válido (en MB).");
                return;
            }

            // Obtener tamaño USB
            if (!double.TryParse(textBox2.Text, out double usbValue))
            {
                MessageBox.Show("Ingrese un tamaño válido para la USB.");
                return;
            }

            // Convertir a GB
            double usbSizeGB = ConvertirGB(usbValue);

            if (usbSizeGB <= 0)
            {
                MessageBox.Show("El tamaño de la USB no es válido.");
                return;
            }

            // Convertir USB a MB
            double usbSizeMB = usbSizeGB * 1024;

            // Calcular cantidad de archivos
            int totalFiles = (int)(usbSizeMB / fileSizeMB);

            // Mostrar resultado
            MessageBox.Show($"La USB puede almacenar aproximadamente {totalFiles} archivos de {fileSizeMB} MB.");

            // ========================================
            // INSERTAR EN BASE DE DATOS
            // ========================================

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO HistorialCalculos (UsbSizeGB, FileSizeMB, TotalFiles) VALUES (@usb, @file, @total)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@usb", usbSizeGB);
                cmd.Parameters.AddWithValue("@file", fileSizeMB);
                cmd.Parameters.AddWithValue("@total", totalFiles);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            // Refrescar lista
            CargarHistorial();
        }



        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)      // TB
        {
            // Only respond when this radio becomes checked. Do not set other.Checked manually.
            if (!radioButton2.Checked) return;

            // Optionally validate current textbox value when switching unit
            if (double.TryParse(textBox2.Text, out double usbSize))
            {
                ValidateUsbSize(usbSize);
            }
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)      // GB
        {
            // Only respond when this radio becomes checked. Do not set other.Checked manually.
            if (!radioButton1.Checked) return;

            // Optionally validate current textbox value when switching unit
            if (double.TryParse(textBox2.Text, out double usbSize))
            {
                ValidateUsbSize(usbSize);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void CargarHistorial()
        {
            listBox1.Items.Clear();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT UsbSizeGB, FileSizeMB, TotalFiles, Fecha FROM HistorialCalculos ORDER BY ID DESC";

                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string linea =
                        $"USB: {reader["UsbSizeGB"]} GB | Archivo: {reader["FileSizeMB"]} MB | Cant: {reader["TotalFiles"]} | Fecha: {reader["Fecha"]}";

                    listBox1.Items.Add(linea);
                }
            }
        }

    }
}
