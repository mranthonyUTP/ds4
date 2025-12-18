using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_9

{
    public static class Validador
    {
        public static decimal SolicitarPrecio()
        {
            decimal precio;
            do
            {
                Console.Write("Ingrese el precio del producto (valor positivo): ");
            } while (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0);

            return precio;
        }

        public static string SolicitarFormaPago()
        {
            string formaPago;
            do
            {
                Console.Write("Forma de pago (efectivo/tarjeta): ");
                formaPago = Console.ReadLine()?.ToLower();
            } while (formaPago != "efectivo" && formaPago != "tarjeta");

            return formaPago;
        }

        public static string SolicitarNumeroCuenta()
        {
            string cuenta;
            do
            {
                Console.Write("Ingrese el número de cuenta (16 dígitos): ");
                cuenta = Console.ReadLine();
            } while (cuenta == null || cuenta.Length != 16 || !EsNumerico(cuenta));

            return cuenta;
        }

        private static bool EsNumerico(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsDigit(c)) return false;
            }
            return true;
        }
    }
}

