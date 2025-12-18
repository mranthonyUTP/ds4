using System;

class Matriz
{
    private int[,] mat;

    public void Ingresar()
    {
        mat = new int[3, 4]; // Matriz de 3 filas x 4 columnas

        for (int f = 0; f < 3; f++)
        {
            for (int c = 0; c < 4; c++)
            {
                Console.Write("Ingrese posicion [" + (f + 1) + "," + (c + 1) + "]: ");
                string linea = Console.ReadLine();
                mat[f, c] = int.Parse(linea); // Guardamos el número en la matriz
            }
        }
    }

    public void Imprimir()
    {
        Console.WriteLine("\nContenido de la matriz:");

        for (int f = 0; f < 3; f++)
        {
            for (int c = 0; c < 4; c++)
            {
                Console.Write(mat[f, c] + " ");
            }
            Console.WriteLine(); // salto de línea al terminar cada fila
        }
    }

    static void Main(string[] args)
    {
        Matriz ma = new Matriz();
        ma.Ingresar();
        ma.Imprimir();

        Console.ReadKey();
    }
}
