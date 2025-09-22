using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio31
{
    internal class Laboratorio32 : Program
    {

        /* Bueno profesor, le dejo este mensaje para evitar confusiones, ya que no tuve claro el enunciado del ejecricio 2
         * El enunciado comenta sobre agregar un metodo que calcule el area de un circulo, a la clase creada en el "anterior ejecicio".
         * aqui viene mi confucion ya que me da a entender que debo de usar la clase del ejercicio anterior (Program) y agregarle el metodo.
         * Sin embargo, al inicio del enucniado del ejecicio 2, menciona "Cree una nueva aplicacion de consola llamada laboratorio 32", por lo que no estoy seguro si
         * debo crear un nuevo proyecto o no. Por lo que decidi crear una nueva clase llamada Laboratorio32 que hereda de Program, y en el Main de esta nueva clase
         * 
         * PD. desde mi punto de vista, no tiene mucho sentido que una clase llamada Laboratorio32 que tenga un metodo para calcular el area de un circulo y su estructura sea exactamente igual que el anterior ejercicio...
         * es por esa razon que decidi heredar de Program, ya que creo que estamos haciendo un repaso rapido de la sintaxis y conceptos basicos para C#.
         */

        private static void Main(string[] args)
        {
            Program p = new Program();

            Console.WriteLine("Programa para calcular el area de un circulo");
            // Declarando variables necesarias
            int primer_numero, segundo_numero, resultado;

            //Pidiendo los numeros al usuario
            Console.WriteLine("Digita un numero porfavor: ");
            primer_numero = Convert.ToInt32(Console.ReadLine());

            // Imprimiendo el resultado al usuario
            Console.WriteLine($"El area del circulo es { p.calcular_area(primer_numero) }");
        }
    }
}
