class Program
{
    static void Main(string[] args)
    {
        try
        {
            int[] myNumbers = { 1, 2, 3 };
            Console.WriteLine(myNumbers[10]);
        }
        catch (Exception e)
        {
            Console.WriteLine("Algo salió mal, valide el índice del arreglo");
        }
        finally
        {
            Console.WriteLine("Continuación de la aplicación, luego del bloque try/catch");
        }
    }
}