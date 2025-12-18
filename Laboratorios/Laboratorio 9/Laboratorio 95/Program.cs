using System;
using Utilidades;

class Program
{
    static void Main(string[] args)
    {
        Aleatorios aleatorios = new Aleatorios();

        Console.WriteLine("Arreglo de 5 números únicos entre 1 y 10:");
        int[] arregloUnico = aleatorios.GenerarArregloUnico(5, 1, 10);
        Console.WriteLine(string.Join(", ", arregloUnico));
    }
}