using System.Data.SqlClient;

namespace Laboratorio_13
{
    public partial class Form1 : Form
    {

        //conector base de datos

        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;";


        private static bool Connection(string connectionString1)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString1))
                {
                    connection.Open();

                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        return true;
                    }
                    else
                    {                        
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
        public Form1()
        {
            InitializeComponent();
            button2.BackColor = Color.Red;
            button3.BackColor = Color.Yellow;
            button4.BackColor = Color.LightGray;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)      // Conect to DB
        {
            if (Connection(connectionString))
            {
                button4.BackColor = Color.Green;
                button2.BackColor = Color.LightGray;
                //listBox1_SelectedIndexChanged(sender, e, new SqlConnection(connectionString));
            }
            else
            {
                button2.BackColor = Color.Red;
                button4.BackColor = Color.LightGray;
                return;
            }

            // show a products list fron northwind database
            string query = "SELECT ProductName FROM Products";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    listBox1.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader["ProductName"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)      // Query relaesed
        {
            
        }

        private void button4_Click(object sender, EventArgs e)      // Server On
        {

        }

        private void button2_Click(object sender, EventArgs e)      // Server Off
        {

        }

        private void button3_Click(object sender, EventArgs e)      // Disconnect from DB
        {

        }
    }
}
