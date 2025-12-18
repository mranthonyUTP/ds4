using System;
using System.Collections.Generic;

class Estudiante
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Creamos la lista de estudiantes
        List<Estudiante> estudiantes = new List<Estudiante>
        {
            new Estudiante { Nombre = "Ana", Edad = 12 },
            new Estudiante { Nombre = "Juan", Edad = 10 },
            new Estudiante { Nombre = "Sofía", Edad = 11 }
        };

        // Recorremos la lista e imprimimos
        foreach (Estudiante estudiante in estudiantes)
        {
            Console.WriteLine("Nombre: " + estudiante.Nombre + ", Edad: " + estudiante.Edad);
        }

        Console.ReadKey();
    }
}
