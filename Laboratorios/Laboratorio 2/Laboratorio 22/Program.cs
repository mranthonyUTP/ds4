using System;

namespace Laboratorio21
{
    public class Program
    {
        public static void Main()
        {
            // Asignando valor a variable estática
            MyClass.Valor = 1;

            // Mostrando valor en consola
            Console.WriteLine(MyClass.Valor);
        }
    }

    public class MyClass
    {
        // Declarando variable estática
        public static int Valor;
    }
}
