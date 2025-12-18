using System.Data;
using System.Data.SqlClient;




namespace Laboratorio_14
{
    public partial class Form1 : Form
    {
        int id_counter = 0;
        Boolean create_New_Item, update_Item;
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=PROD_TIENDA_DB;Trusted_Connection=True;TrustServerCertificate=True;";

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
            id_counter = getLastID();
            InitializeComponent();
            Connection(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_Add.Enabled = true;
            btn_Save.Enabled = false;
            btn_Cancel.Enabled = false;
            btn_Delete.Enabled = false;

            search_bar.Enabled = true;

            id_TBox.Enabled = false;
            productName_TBox.Enabled = false;
            price_TBox.Enabled = false;
            stock_TBox.Enabled = false;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            btn_Add.Enabled = true;
            btn_Save.Enabled = true;
            btn_Cancel.Enabled = true;
            btn_Delete.Enabled = false;
            btn_Delete.Visible = false;

            search_bar.Enabled = true;

            id_TBox.Enabled = false;
            productName_TBox.Enabled = true;
            price_TBox.Enabled = true;
            stock_TBox.Enabled = true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(id_TBox.Text))
            {
                update_Item = false;
                addNewItem(update_Item);
            }
            else
            {
            create_New_Item = true;
            addNewItem(create_New_Item);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            // Reset the form to its initial state
            btn_Add.Enabled = true;
            btn_Save.Enabled = false;
            btn_Cancel.Enabled = false;
            btn_Delete.Enabled = false;

            btn_Delete.Visible = true;

            search_bar.Enabled = true;
            search_bar.Text = "";

            id_TBox.Enabled = false;
            id_TBox.Text = "";

            productName_TBox.Enabled = false;
            productName_TBox.Text = "";

            price_TBox.Enabled = false;
            price_TBox.Text = "";

            stock_TBox.Enabled = false;
            stock_TBox.Text = "";

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM Productos WHERE ID='" + this.id_TBox.Text + "';";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Registro eliminado correctamente!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }

            btn_Add.Enabled = true;
            btn_Save.Enabled = false;
            btn_Cancel.Enabled = false;
            btn_Delete.Enabled = false;

            search_bar.Enabled = true;

            id_TBox.Enabled = false;
            productName_TBox.Enabled = false;
            price_TBox.Enabled = false;
            stock_TBox.Enabled = false;

            id_TBox.Text = "";
            productName_TBox.Text = "";
            price_TBox.Text = "";
            stock_TBox.Text = "";
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            //int.TryParse(search_bar.Text, out int searchId);
            if (!string.IsNullOrWhiteSpace(search_bar.Text))
            {
                string searchId = search_bar.Text;
                getProduct(searchId);
            }

        }

        private void search_bar_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(search_bar.Text) &&
                int.TryParse(search_bar.Text, out int id) &&
                id > 0)
            {
                btn_Search.Enabled = true;
            }
            else
            {
                search_bar.Text = "";
            }

        }

        private void id_TBox_TextChanged(object sender, EventArgs e)
        {
            // Evita validaciones cuando está vacío
            if (string.IsNullOrWhiteSpace(id_TBox.Text))
                return;

            // Validar que sea entero
            if (!int.TryParse(id_TBox.Text, out _))
            {
                MessageBox.Show("El ID solo puede contener números enteros.");
                id_TBox.Text = "";
            }
        }

        private void productName_TBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void price_TBox_TextChanged(object sender, EventArgs e)
        {
            string text = price_TBox.Text;

            if (string.IsNullOrWhiteSpace(text))
                return;

            // Validación: solo dígitos y un punto
            if (!System.Text.RegularExpressions.Regex.IsMatch(text, @"^\d*\.?\d*$"))
            {
                MessageBox.Show("El precio debe ser un número válido (ejemplo: 10.50).");
                price_TBox.Text = "";
                return;
            }

            // Validación adicional: evitar más de un punto decimal
            if (text.Count(c => c == '.') > 1)
            {
                MessageBox.Show("Solo se permite un punto decimal.");
                price_TBox.Text = "";
            }
        }

        private void stock_TBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(stock_TBox.Text))
                return;

            // validar que sea número entero
            if (!int.TryParse(stock_TBox.Text, out _))
            {
                MessageBox.Show("El stock debe ser un número entero.");
                stock_TBox.Text = "";
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("estas seguro que quieres salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == DialogResult.Yes)
            {
                Application.Exit();
                //Close();
            }
        }
        private void getProduct(string searchText)
        {
            string sql = "SELECT * FROM Productos WHERE ID=" + searchText;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    btn_Add.Enabled = false;
                    btn_Save.Enabled = true;
                    btn_Cancel.Enabled = true;
                    btn_Delete.Enabled = true;

                    search_bar.Enabled = false;

                    //id_TBox.Enabled = true;
                    productName_TBox.Enabled = true;
                    price_TBox.Enabled = true;
                    stock_TBox.Enabled = true;

                    productName_TBox.Focus();

                    id_TBox.Text = reader[0].ToString();
                    productName_TBox.Text = reader[1].ToString();
                    price_TBox.Text = reader[2].ToString();
                    stock_TBox.Text = reader[3].ToString();

                    create_New_Item = false;
                }
                else
                {
                    MessageBox.Show("Ningún registro encontrado con el ID ingresado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                con.Close();

            }


        }

        private void addNewItem(Boolean Current_Item)
        {
            if (create_New_Item)
            {
                id_counter++;

                string sql = "INSERT INTO Productos (ID, NOMBRE, PRECIO, STOCK) " +
                             "VALUES ('" + id_counter + "', '" + productName_TBox.Text + "', '" + price_TBox.Text + "', '" + stock_TBox.Text + "')";

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Registrado correctamente!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                string sql = "UPDATE Productos SET NOMBRE='" + productName_TBox.Text +
                                               "', PRECIO='" + price_TBox.Text       +
                                               "', STOCK='"  + stock_TBox.Text       +
                                               "' WHERE id=" + id_TBox.Text;

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Registro actualizado correctamente!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error general: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }

            // Deshabilitar y limpiar controles
            btn_Add.Enabled = true;
            btn_Save.Enabled = false;
            btn_Cancel.Enabled = false;
            btn_Delete.Enabled = false;

            search_bar.Enabled = true;

            id_TBox.Enabled = false;
            productName_TBox.Enabled = false;
            price_TBox.Enabled = false;
            stock_TBox.Enabled = false;

            id_TBox.Text = "";
            productName_TBox.Text = "";
            price_TBox.Text = "";
            stock_TBox.Text = "";

        }

        private int getLastID()
        {
            int lastId = 0;  // Default value

            string sql = "SELECT MAX(ID) FROM Productos";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();

                object result = cmd.ExecuteScalar(); // obtain the last cell

                if (result != DBNull.Value && result != null)
                {
                    lastId = Convert.ToInt32(result);
                }
            }

            return lastId;
        }
    }
}