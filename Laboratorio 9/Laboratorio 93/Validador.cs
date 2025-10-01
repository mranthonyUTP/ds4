using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_93
{
    public static class Validador
    {
        public static double SolicitarLado(string nombre)
        {
            double lado;
            do
            {
                Console.Write($"{nombre}: ");
            } while (!double.TryParse(Console.ReadLine(), out lado) || lado <= 0);

            return lado;
        }
    }
}
