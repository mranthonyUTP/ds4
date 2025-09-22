internal class Program
{
    private static void Main(string[] args)
    {
        // -----------------------------------------------------------------------------------------------------------------
        // De cualquier forma, aqui esta el codigo del ejercicio 2 en un solo archivo, sin herencias ni nada por el estilo.
        // -----------------------------------------------------------------------------------------------------------------

        Program p = new Program();

        Console.WriteLine("Programa para calcular el area de un circulo");
        // Declarando variables necesarias
        int primer_numero;

        //Pidiendo los numeros al usuario
        Console.WriteLine("Digita un numero porfavor: ");
        primer_numero = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"El area del circulo es { p.calcular_area(primer_numero) }");
    }


    float calcular_area(int radio)
    {
        return 3.1416f * (radio * radio);
    }

}