internal class Program
{
    //DESARROLLANDO LAS VARIABLES DE CLASE

    private static void Main(string[] args)
    {
        // ------------------------
        //  CREACION DE VARIABLES
        // ------------------------

        int numeroEntero = 100; // Variable de tipo entero

        Console.WriteLine("Variable");

        // provocando un error de compilacion al llamar a una variable de un metodo

        // Console.WriteLine(respuesta); // Error de compilacion


        // VARIABLES DE INSTANCIA
        Cliente client = new Cliente();
        client.nombre = "Juan Perez";
        client.edad = 30;
        client.apellido = "Perez";

        Console.WriteLine("Nombre: " + client.getNombreCompleto());

    }

    public void sumarDosNumeros(int A, int B)
    {
        //  CREACION DE VARIABLES LOCALES AL METODO

        int respuesta = A + B; // Variable de tipo entero local

        Console.WriteLine(respuesta);
    }
}

// --------------------------------------------------------
// DEFINICION DE UNA CLASE PARA LAS VARIABLES DE INSTANCIA
// --------------------------------------------------------
public class Cliente
{
    // VARIABLES DE INSTANCIA
    public string nombre { get; set; } // Variable de tipo cadena
    public int edad { get; set; } // Variable de tipo entero
    public string apellido { get; set; } // Variable de tipo cadena

    public String getNombreCompleto()
    {
        return this.nombre + this.apellido;
    }

}

// --------------------------------------------------------
// DEFINICION OTRA CLASE PARA LAS VARIABLES ESTATICAS
// --------------------------------------------------------
public class OtraClase
{
    // Declaracion de variable estatica
    public static string variableEstatica = "Variable estatica";
}