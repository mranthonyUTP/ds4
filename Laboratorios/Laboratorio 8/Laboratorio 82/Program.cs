
using Laboratorio_82;

internal class Program
{
    private static void Main(string[] args)
    {
        const string CUENTA = "100";

        Cuenta cuenta = new Cuenta(CUENTA);
        CuentaCorriente cuantaCorriente =
            new CuentaCorriente(CUENTA);
        CuentaAhorro cuantaAhorro =
            new CuentaAhorro(CUENTA);

        cuenta.CalcularIntereses();
        cuantaCorriente.CalcularIntereses();
        cuantaAhorro.CalcularIntereses(); 
    }
}
