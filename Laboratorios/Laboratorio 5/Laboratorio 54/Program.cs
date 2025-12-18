using System.Collections.Generic;

using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        // Declaramos lista de enteros con calificaciones
        List<int> calificaciones = new List<int> { 85, 90, 78, 92, 88 };

        int suma = 0;

        // Recorremos la lista sumando las calificaciones
        foreach (int calificacion in calificaciones)
        {
            suma += calificacion; 
        }

        double promedio = (double)suma / calificaciones.Count;

        Console.WriteLine($"El promedio de las calificaciones es: {promedio}");
    }
}
