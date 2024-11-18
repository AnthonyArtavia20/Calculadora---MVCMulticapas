using CalculadoraMVCMulticapas.Models;
using CalculadoraMVCMulticapas.interfaces;
using CalculadoraMVCMulticapas.Data;


namespace CalculadoraMVCMulticapas.Services
{
    public class CalculadoraService : ICalculadora
    {
        private readonly CalculadoraModelClass _model;
        private readonly BitacoraRepository _bitacora;

        public double Operador1 { get => _model.Operador1; set => _model.Operador1 = value; }
        public double Operador2 { get => _model.Operador2; set => _model.Operador2 = value; }

        public CalculadoraService(CalculadoraModelClass model, BitacoraRepository bitacora)
        {
            _model = model;
            _bitacora = bitacora;
        }

        public double Sumar(double a, double b)
        {
            _model.Operador1 = a;
            _model.Operador2 = b;
            return _model.Sumar();
        }

        public double Restar(double a, double b)
        {
            _model.Operador1 = a;
            _model.Operador2 = b;
            return _model.Restar();
        }

        public double Multiplicar(double a, double b)
        {
            _model.Operador1 = a;
            _model.Operador2 = b;
            return _model.Multiplicar();
        }

        public double Dividir(double a, double b)
        {
            _model.Operador1 = a;
            _model.Operador2 = b;
            return _model.Dividir();
        }

        public bool EsPrimo(int numero) => CalculadoraModelClass.EsPrimoONo(numero);

        public string ConvertirABinario(int numero) => _model.ConvertirABinario(numero);

        public double CalcularPromedio(List<double> numeros)
        {
            if (!numeros.Any()) return 0;
            return numeros.Average();
        }
    }
}
