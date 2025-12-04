using Parcial_1;
internal class Program
{

    /*
     Patron: FILAS PARES    0   0   0   0
                           101 200 189 122
        Matriz  N x N       0   0   0   0
                           150 130 186 142

    N debe ser PAR

    calcular multiplicacion de los numeros aleatorios

     */

    private static void Main(string[] args)
    {
        // Instancio la clase para mantener una buena estructura
        Patron patron = new Patron();
        int[,] matriz;      // declaracion de la matriz

        Console.WriteLine("Digite un valor PAR en funcion al patron: ");
        int n = int.Parse(Console.ReadLine());

        if (n % 2 != 0)
        {
            Console.WriteLine("debe de ser par el numero");
            return;
        }
        else
        {
            matriz = patron.generarMatriz(n);
        }

        //aqui procedemos a imprimir la matriz
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matriz[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine("La multiplicacion de las filas pares es: " + patron.getMultiplicacion());
    }
}