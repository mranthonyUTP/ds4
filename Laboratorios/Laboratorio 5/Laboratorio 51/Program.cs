using System;

class PruebaVector1
{
    private int[] sueldos; // Declaramos un vector

    public void Cargar()
    {
        sueldos = new int[5]; // Inicializamos el vector en 5 posiciones

        for (int f = 0; f < 5; f++) // Los arreglos en C# empiezan en índice 0
        {
            Console.Write("Ingrese sueldo del operario " + (f + 1) + ": ");
            string linea = Console.ReadLine();
            sueldos[f] = int.Parse(linea); // Asignamos los 5 sueldos al vector
        }
    }

    public void Imprimir()
    {
        Console.WriteLine("\nLos 5 sueldos de los operarios:");
        for (int f = 0; f < 5; f++)
        {
            Console.Write("[" + sueldos[f] + "] ");
        }
        Console.WriteLine();
    }

    // Main principal
    static void Main(string[] args)
    {
        PruebaVector1 pv = new PruebaVector1();
        pv.Cargar();
        pv.Imprimir();

        Console.ReadKey();
    }
}
