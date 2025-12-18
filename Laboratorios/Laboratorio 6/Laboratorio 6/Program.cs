using System;

class Program
{
    static void Main(string[] args)
    {
        int num;

        Console.WriteLine("Digite el número deseado:");

        try
        {
            num = Int16.Parse(Console.ReadLine()); 
        }
        catch (FormatException ex)
        {
            Console.WriteLine("No ha introducido un dígito válido");
            num = -1; // valor por defecto si hay error
        }

        Console.WriteLine("Número ingresado: " + num);
        Console.ReadKey();
    }
}
