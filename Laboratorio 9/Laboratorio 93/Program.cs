using Laboratorio_93;
using System;

namespace ProyectoTriangulo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese los tres lados del triángulo:");

            double lado1 = Validador.SolicitarLado("Lado 1");
            double lado2 = Validador.SolicitarLado("Lado 2");
            double lado3 = Validador.SolicitarLado("Lado 3");

            Triangulo triangulo = new Triangulo(lado1, lado2, lado3);

            if (triangulo.EsValido())
            {
                Console.WriteLine($"Es un triángulo válido de tipo: {triangulo.Tipo()}");
            }
            else
            {
                Console.WriteLine("Los lados ingresados no forman un triángulo válido.");
            }
        }
    }
}