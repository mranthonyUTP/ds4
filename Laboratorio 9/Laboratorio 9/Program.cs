using Laboratorio_9;
using System;

namespace ProyectoPago
{
    class Program
    {
        static void Main(string[] args)
        {
            Pago pago = new Pago();
            pago.SolicitarDatos();
            pago.MostrarResumen();
        }
    }
}