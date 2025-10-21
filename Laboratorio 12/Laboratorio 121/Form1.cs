namespace Laboratorio_121
{
    public partial class Form1 : Form
    {
        double grade1, grade2, grade3, finalGrade;

        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Final_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Grade1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Grade1_text.Text != "")
                {
                    grade1 = Convert.ToDouble(Grade1_text.Text);
                    if (grade1 < 0 || grade1 > 100)
                    {
                        MessageBox.Show("El valor debe estar entre 0 y 100.");
                        Grade1_text.ResetText();
                        grade1 = 0;
                    }
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Inserta un valor valido. (ej. 50.5, 100 o 92.32)");
                Grade1_text.ResetText();
            }

        }

        private void Grade1_text_Click(object sender, EventArgs e)
        {

        }

        private void Grade2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Grade1_text.Text != "")
                {
                    double grade2 = Convert.ToDouble(Grade1_text.Text);
                    if (grade2 < 0 || grade2 > 100)
                    {
                        MessageBox.Show("El valor debe estar entre 0 y 100.");
                        Grade1_text.ResetText();
                        grade2 = 0;
                    }
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Inserta un valor valido. (ej. 50.5, 100 o 92.32)");
                Grade1_text.ResetText();
            }

        }

        private void Grade3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Grade1_text.Text != "")
                {
                    double grade3 = Convert.ToDouble(Grade1_text.Text);
                    if (grade3 < 0 || grade3 > 100)
                    {
                        MessageBox.Show("El valor debe estar entre 0 y 100.");
                        Grade1_text.ResetText();
                        grade3 = 0;
                    }
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Inserta un valor valido. (ej. 50.5, 100 o 92.32)");
                Grade1_text.ResetText();
            }

        }

        private void Solve_btn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
