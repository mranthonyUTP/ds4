using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_12
{
    public partial class Software : Form
    {
        int distanciaInicio, distanciaFinal, Resultado;
        double tiempo, velocidad;
        public Software()
        {
            InitializeComponent();
        }

        private void Software_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            distanciaInicio = Convert.ToInt32(textBox1.Text);
            Console.WriteLine(distanciaInicio + " Desde la consola");

        }
    }
}
