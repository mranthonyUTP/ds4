using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Diccionario con países y sus capitales
        Dictionary<string, string> paisesYCapitales = new Dictionary<string, string>
        {
            { "Francia", "París" },
            { "España", "Madrid" },
            { "Italia", "Roma" }
        };

        // Recorremos el diccionario
        foreach (KeyValuePair<string, string> par in paisesYCapitales)
        {
            Console.WriteLine("La capital de " + par.Key + " es " + par.Value + ".");
        }

        Console.ReadKey();
    }
}
