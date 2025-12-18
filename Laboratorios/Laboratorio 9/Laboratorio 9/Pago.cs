using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_9
{
    public class Pago
{
    public decimal Precio { get; private set; }
    public string FormaPago { get; private set; }
    public string NumeroCuenta { get; private set; }

    public void SolicitarDatos()
    {
        Precio = Validador.SolicitarPrecio();
        FormaPago = Validador.SolicitarFormaPago();

        if (FormaPago == "tarjeta")
        {
            NumeroCuenta = Validador.SolicitarNumeroCuenta();
        }
    }

    public void MostrarResumen()
    {
        Console.WriteLine("\n--- Resumen de Pago ---");
        Console.WriteLine($"Precio del producto: ${Precio}");

        if (FormaPago == "tarjeta")
        {
            Console.WriteLine($"Forma de pago: Tarjeta");
            Console.WriteLine($"Número de cuenta: {NumeroCuenta}");
        }
        else
        {
            Console.WriteLine("Forma de pago: Efectivo");
        }
    }
}
}

