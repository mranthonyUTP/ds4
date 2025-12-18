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

        Console.WriteLine($"El resultado de la operacion es: {p.calcular_perimetro(primer_numero, segundo_numero)}");

    }

    int calcular_perimetro(int ancho, int altura)
    {
        return (ancho + altura) * 2;
    }
}