internal class Program
{
    private static void Main(string[] args)
    {
        // creando arreglo vectorial
        int[] vector;
        // instanciando el arreglo vectorial
        int[] valores = new int[5];



        //Arreglos unidimensionales o de dimensión simple
        int[] valores1;
        int[] valores2 = new int[50];

        //Arreglos multidimensionales
        int[,] valores3;
        int[,] valores4 = new int[3, 7];
        //sin inicializar

        int[,,] valores5 = new int[3, 4, 2]; //Arreglo de tres dimensiones

        //Arreglo de arreglos
        int[][] matriz;

        //Los arreglos de arreglos se inicializan de manera diferente
        int[][] matriz2 = new int[3][];
        for (int i = 0; i < matriz2.Length; i++)
        {
            matriz2[i] = new int[4];
        }
    }
}