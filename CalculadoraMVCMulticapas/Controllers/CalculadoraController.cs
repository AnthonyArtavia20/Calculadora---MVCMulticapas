using CalculadoraMVCMulticapas.Models;

namespace CalculadoraMVCMulticapas.Controllers
{
    public class CalculadoraControllerClass
    {
        private readonly CalculadoraModelClass _Model;

        public CalculadoraControllerClass()
        {
            _Model = new CalculadoraModelClass(); //Creamos una instancia de la clase del modelo, para poder ejecutar las operaciones de ese objeto en cuestion
        }

        public int RealizacionOperaciones(int operando1, int operando2, string operacion)
        {
            _Model.Operador1 = operando1;
            _Model.Operador2 = operando2;

            return operacion switch
            {
                "+" => _Model.Sumar(),
                "-" => _Model.Restar(),
                "*" => _Model.Multiplicar(),
                "/" => _Model.Dividir(),
                _ => throw new InvalidOperationException("Tipo de operación no sorportada...")
            };

        }

        public bool VerificarPrimo(int numero) => _Model.EsPrimoONo(numero);
        public string ObtenerBinario(int numero) => _Model.ConvertirABinario(numero);
    }
}