using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Utilidades
{
    public class Aleatorios
    {
        private readonly Random _random;

        public Aleatorios()
        {
            _random = new Random();
        }

        public int GenerarEntre(int min, int max)
        {
            if (min > max)
                throw new ArgumentException("El valor mínimo no puede ser mayor que el máximo.");

            return _random.Next(min, max + 1);
        }

        public int[] GenerarArreglo(int cantidad, int min, int max)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero.");

            int[] arreglo = new int[cantidad];

            for (int i = 0; i < cantidad; i++)
            {
                arreglo[i] = GenerarEntre(min, max);
            }

            return arreglo;
        }
    }
}

