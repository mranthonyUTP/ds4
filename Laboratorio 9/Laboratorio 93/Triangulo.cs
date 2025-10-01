using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_93

{
    public class Triangulo
    {
        public double Lado1 { get; }
        public double Lado2 { get; }
        public double Lado3 { get; }

        public Triangulo(double lado1, double lado2, double lado3)
        {
            Lado1 = lado1;
            Lado2 = lado2;
            Lado3 = lado3;
        }

        public bool EsValido()
        {
            return (Lado1 + Lado2 > Lado3) &&
                   (Lado1 + Lado3 > Lado2) &&
                   (Lado2 + Lado3 > Lado1);
        }

        public string Tipo()
        {
            if (Lado1 == Lado2 && Lado2 == Lado3)
                return "Equilátero";
            else if (Lado1 == Lado2 || Lado2 == Lado3 || Lado1 == Lado3)
                return "Isósceles";
            else
                return "Escaleno";
        }
    }
}

