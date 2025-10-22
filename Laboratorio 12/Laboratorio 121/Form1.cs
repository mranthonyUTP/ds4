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
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // reset all text boxes and final grade label
            Grade1_box.ResetText();
            Grade2_box.ResetText();
            Grade3_box.ResetText();
            Final.ResetText();
            // reset all grade variables
            grade1 = 0;
            grade2 = 0;
            grade3 = 0;
            finalGrade = 0;
            // set focus to first grade text box
            Grade1_box.Focus();
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
                if (Grade1_box.Text != "")
                {
                    grade1 = Convert.ToDouble(Grade1_box.Text);

                    if (grade1 < 0 || grade1 > 100)
                    {
                        MessageBox.Show("El valor debe estar entre 0 y 100.");
                        Grade1_box.ResetText();
                        grade1 = 0;
                    }
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Inserta un valor valido. (ej. 50.5, 100 o 92.32)");
                Grade1_box.ResetText();
            }

        }

        private void Grade1_text_Click(object sender, EventArgs e)
        {

        }

        private void Grade2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Grade2_box.Text != "")
                {
                    grade2 = Convert.ToDouble(Grade2_box.Text);
                    if (grade2 < 0 || grade2 > 100)
                    {
                        MessageBox.Show("El valor debe estar entre 0 y 100.");
                        Grade2_box.ResetText();
                        grade2 = 0;
                    }
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Inserta un valor valido. (ej. 50.5, 100 o 92.32)");
                Grade2_box.ResetText();
            }

        }

        private void Grade3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Grade3_box.Text != "")
                {
                     grade3 = Convert.ToDouble(Grade3_box.Text);

                    if (grade3 < 0 || grade3 > 100)
                    {
                        MessageBox.Show("El valor debe estar entre 0 y 100.");
                        Grade2_box.ResetText();
                        grade3 = 0;
                    }
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Inserta un valor valido. (ej. 50.5, 100 o 92.32)");
                Grade3_box.ResetText();
            }

        }

        private void Solve_btn_Click(object sender, EventArgs e)
        {
            finalGrade = (grade1 + grade2 + grade3);
            finalGrade /= 3;

            MessageBox.Show(grade1 + " " + grade2 + " " + grade3 + " final " + finalGrade);

            Final.Text = Convert.ToString(finalGrade);

        }
    }
}
