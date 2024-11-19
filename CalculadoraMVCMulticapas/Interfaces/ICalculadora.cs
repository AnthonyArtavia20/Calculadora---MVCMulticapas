namespace CalculadoraMVCMulticapas.interfaces
{
    public interface ICalculadora
    {
        double Sumar(double a, double b);
        double Restar(double a, double b);
        double Multiplicar(double a, double b);
        double Dividir(double a, double b);
        bool EsPrimo(int numero);
        string ConvertirABinario(int numero);
        double CalcularPromedio(List<double> numeros);
        double Operador1 { get; set; }
        double Operador2 { get; set; }
    }
}