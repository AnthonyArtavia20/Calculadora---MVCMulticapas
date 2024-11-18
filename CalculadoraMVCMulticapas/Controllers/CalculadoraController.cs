using CalculadoraMVCMulticapas.Data;
using CalculadoraMVCMulticapas.Models;
using CalculadoraMVCMulticapas.Services;
using CalculadoraMVCMulticapas.DTOs;
using CalculadoraMVCMulticapas.interfaces;

namespace CalculadoraMVCMulticapas.Controllers
{
    public class CalculadoraControllerClass
    {
        private readonly ICalculadora _calculadoraService;
        private readonly BitacoraRepository _bitacora;
        private readonly Form1 _view;
        public static List<double> ListaParaPromedio { get; private set; } = new List<double>();

        public CalculadoraControllerClass(Form1 view, ICalculadora calculadoraService, BitacoraRepository bitacora)
        {
            _view = view;
            _calculadoraService = calculadoraService;
            _bitacora = bitacora;
        }

        public void ProcesarOperacionPendiente()
        {
            double numeroActual = Convert.ToDouble(_view.PantallaDeResultado.Text);

            if (string.IsNullOrEmpty(_view.operacionActual))
            {
                _view.ActualizarPantalla(numeroActual.ToString());
                if (_view.sePresionoIgual)
                {
                    _bitacora.GuardarOperacionIgual(numeroActual);
                }
                return;
            }

            var operacionDTO = new OperacionDTO
            {
                Operador1 = _calculadoraService.Operador1,
                Operador2 = Convert.ToDouble(_view.PantallaDeResultado.Text),
                Operacion = _view.operacionActual
            };

            try
            {
                operacionDTO.Resultado = _view.operacionActual switch
                {
                    "+" => _calculadoraService.Sumar(operacionDTO.Operador1, operacionDTO.Operador2),
                    "-" => _calculadoraService.Restar(operacionDTO.Operador1, operacionDTO.Operador2),
                    "*" => _calculadoraService.Multiplicar(operacionDTO.Operador1, operacionDTO.Operador2),
                    "/" => _calculadoraService.Dividir(operacionDTO.Operador1, operacionDTO.Operador2),
                    _ => throw new InvalidOperationException("Operación no válida")
                };

                _bitacora.GuardarOperacionBasica(operacionDTO.Operador1, operacionDTO.Operacion, 
                                               operacionDTO.Operador2, operacionDTO.Resultado);
                ListaParaPromedio.Add(operacionDTO.Resultado);
                _view.ActualizarPantalla(operacionDTO.Resultado.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _view.ActualizarPantalla("0");
            }
        }

        public void VerificarYGuardarPrimo(int numero)
        {
            bool esPrimo = CalculadoraModelClass.EsPrimoONo(numero);
            string resultado = esPrimo ? "true" : "false"; // Formateo consistente
            _view.ActualizarPantalla($"Primo: {resultado}");
            _bitacora.GuardarOperacionPrimo(numero, esPrimo);
        }

        public void ConvertirYGuardarBinario(int numero)
        {
            string binario = _calculadoraService.ConvertirABinario(numero);
            _view.ActualizarPantalla($"Binario: {binario}");
            _bitacora.GuardarOperacionBinario(numero, binario);
        }

        public double SacarPromedioYMostrarlo()
        {
            if (ListaParaPromedio.Count == 0)
                return 0; // Evitar division por cero.

            double sumaDeLosResultados = ListaParaPromedio.Sum();
            double promedio = sumaDeLosResultados / ListaParaPromedio.Count;

            // Convertir los numeros de la lista a un string separado por espacios.
            string numerosMemoria = string.Join(" ", ListaParaPromedio);

            // Guardar en la bitacora utilizando la instancia actual de la bitacora.
            _bitacora.GuardarOperacionPromedio(numerosMemoria, promedio);

            return promedio;
        }

        //Se crea un metodo especifico para reforzar la separacion de identidades
        //logrando comunicar Form1 con Controllers.
        public void ReiniciarCalcu()
        {
            _calculadoraService.Operador1 = 0;
            _calculadoraService.Operador2 = 0;
            _view.ActualizarPantalla("0"); //La vista se actualiza a traves del controlador.
        }

        public List<string> ObtenerRegistrosBitacora()
        {
            return _bitacora.ObtenerRegistros();
        }

        public void GuardarEnMemoria(double numero)
        {
            //Guardar en la bitacora.
            _bitacora.GuardarOperacionMemoria(numero.ToString());
        }
    }
}