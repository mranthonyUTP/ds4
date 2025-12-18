using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_1
{
    internal class Patron
    {
        private BigInteger multiplicacion = 1;
        public Patron()
        {
        }

        public int[,] generarMatriz(int n)
        {
            // declaracion de la matriz y del objeto random
            int[,] matriz = new int[n, n];
            Random random = new Random();

            //aqui procedemos a llenar la matriz
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i % 2 == 0)
                    {
                        matriz[i, j] = 0;
                    }
                    else
                    {
                        matriz[i, j] = random.Next(101, 201);
                        multiplicacion *= matriz[i, j];
                    }
                }
            }
            return matriz;
        }
        
        public BigInteger getMultiplicacion()      // metodo para obtener la multiplicacion total de los elementos aleatorios
        {
            return multiplicacion;
        }
    }
}
