using System.Data;
using System.Data.SqlClient;



namespace Laboratorio_14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {

        }

        private void search_bar_TextChanged(object sender, EventArgs e)
        {

        }

        private void id_TBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void productName_TBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void price_TBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void stock_TBox_TextChanged(object sender, EventArgs e)
        {

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
    }
}
