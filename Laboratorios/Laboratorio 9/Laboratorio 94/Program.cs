using System;
using Utilidades;

class Program
{
    static void Main(string[] args)
    {
        Aleatorios aleatorios = new Aleatorios();

        Console.WriteLine("Número aleatorio entre 10 y 50:");
        Console.WriteLine(aleatorios.GenerarEntre(10, 50));

        Console.WriteLine("\nArreglo de 5 números aleatorios entre 1 y 100:");
        int[] arreglo = aleatorios.GenerarArreglo(5, 1, 100);
        Console.WriteLine(string.Join(", ", arreglo));
    }
}