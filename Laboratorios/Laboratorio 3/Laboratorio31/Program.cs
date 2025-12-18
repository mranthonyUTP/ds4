internal class Program
{
    private static void Main(string[] args)
    {
        Program p = new Program();

        // Declarando variables necesarias

        int primer_numero, segundo_numero, resultado;

        //Pidiendo los numeros al usuario
        Console.WriteLine("Digita un numero porfavor: ");
        primer_numero = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Digite el otro numero a sumar: ");
        segundo_numero = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"El resultado de la operacion es: { p.calcular_suma(primer_numero, segundo_numero) }");

    }

    int calcular_suma(int primer_numero, int segundo_numero)
    {
        return (primer_numero + segundo_numero) * (primer_numero - segundo_numero);
    }

    public float calcular_area(int radio)
    {
        return 3.1416f * (radio * radio);
    }

}