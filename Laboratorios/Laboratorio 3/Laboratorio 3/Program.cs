internal class Program
{
    private static void Main(string[] args)
    {
        // Declarando variables necesarias

        int primer_numero, segundo_numero, resultado_suma;

        //Pidiendo los numeros al usuario
        Console.WriteLine("Digita un numero porfavor: ");
        primer_numero = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Digite el otro numero a sumar: ");
        segundo_numero = Convert.ToInt32(Console.ReadLine());

        //Realizando la suma
        resultado_suma = primer_numero + segundo_numero;

        // Mostrando el resultado al usuario.     PD. Veo que hay dos formas de hacer esto, con $ y sin $ pero colocando un orden con las laves {#}
        Console.WriteLine($"La suma de estos numeros {primer_numero} y {segundo_numero} es: {resultado_suma} ");
    }
}