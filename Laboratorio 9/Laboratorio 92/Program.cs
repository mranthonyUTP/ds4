using System;

namespace ProyectoNumeros
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Números del 1 al 100 que son pares o divisibles entre 3:");

            for (int i = 1; i <= 100; i++)
            {
                if (EsPar(i) || EsDivisibleEntreTres(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool EsPar(int numero)
        {
            return numero % 2 == 0;
        }

        static bool EsDivisibleEntreTres(int numero)
        {
            return numero % 3 == 0;
        }
    }
}