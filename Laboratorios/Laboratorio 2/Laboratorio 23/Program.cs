using System;

namespace Laboratorio2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //  CREANDO NUEVA INSTANCIA
            MyClass object1 = new MyClass(); 
            object1.Nombre = "Yeison";       
            object1.Edad = 28;               

            //  ASIGNANDO UNA VARIABLE A OTRA
            MyClass object2 = object1; 

            object2.Nombre = "Jose";

            Console.WriteLine(object2.Nombre);
            Console.WriteLine(object1.Nombre);

            // Mostrando todas las variables en consola
            Console.WriteLine(object1.Nombre);
            Console.WriteLine(object1.Edad);
            Console.WriteLine(object1.Salario);
            Console.WriteLine(object1.Genero);
            Console.WriteLine(object1.Descuento);
            Console.WriteLine(object1.Activo);
        }
    }

    public class MyClass
    {
        public string Nombre; 
        public int Edad;      
        public bool Activo;   
        public char Genero;   
        public float Salario;
        public double Descuento;

    }
}
