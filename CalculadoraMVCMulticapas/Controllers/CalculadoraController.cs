using CalculadoraMVCMulticapas.Data;
using CalculadoraMVCMulticapas.Models;


namespace CalculadoraMVCMulticapas.Controllers
{
    public class CalculadoraControllerClass
    {
        private readonly CalculadoraModelClass _Model;
        private CalculadoraModelClass calculadoraModel = new CalculadoraModelClass();
        private BitacoraRepository Bitacora = new BitacoraRepository();
        private Form1 _form1;


        public CalculadoraControllerClass(Form1 form1)
        {
            _Model = new CalculadoraModelClass(); //Creamos una instancia de la clase del modelo, para poder ejecutar las operaciones de ese objeto en cuestion
            _form1 = form1; //Se guarda la referencia de la parte gráfica para poder acceder a las variables.
        }

        public void ProcesarOperacionPendiente() //Se usa en caso de que anteriormente hubiera una operación realizada anteriormente y su resultado esté guardado en Operador1
        {
            double numeroActual = Convert.ToDouble(_form1.PantallaDeResultado.Text);

            if (!string.IsNullOrEmpty(_form1.operacionActual))
            {
                _Model.Operador2 = numeroActual;

                switch (_form1.operacionActual)
                {
                    case "+":
                        _Model.Sumar();
                        break;
                    case "-":
                        _Model.Restar();
                        break;
                    case "*":
                        _Model.Multiplicar();
                        break;
                    case "/":
                        try
                        {
                            _Model.Dividir();
                        }
                        catch (DivideByZeroException ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            _form1.PantallaDeResultado.Text = "0";
                            return;
                        }
                        break;
                }
                // Guardar operación básica
                Bitacora.GuardarOperacionBasica(_Model.Operador1, _form1.operacionActual, _Model.Operador2, _Model.resultado);

                // Actualizamos la pantalla y el operador 1
                _form1.ActualizarPantalla(_Model.resultado.ToString());
                _Model.Operador1 = _Model.resultado;
                _form1.operacionActual = ""; // Limpiar operación actual después de ejecutarla
            }
            else
            {
                // Si no hay operación previa, simplemente guardamos el número actual como Operador1
                _Model.Operador1 = numeroActual;
            }
        }

        public void VerificarYGuardarPrimo(int numero)
        {
            bool esPrimo = CalculadoraModelClass.EsPrimoONo(numero);
            string resultado = esPrimo ? "true" : "false"; // Formateo consistente
            _form1.ActualizarPantalla($"Primo: {resultado}");
            Bitacora.GuardarOperacionPrimo(numero, esPrimo);
        }

        public void ConvertirYGuardarBinario(int numero)
        {
            string binario = _Model.ConvertirABinario(numero);
            _form1.ActualizarPantalla($"Binario: {binario}");
            Bitacora.GuardarOperacionBinario(numero, binario);
        }


        //Se crea un método espécifico para reforzar la separación de identidades
        //logrando comunicar Form1 con Controllers.
        public void ReiniciarCalcu()
        {
            _Model.Operador1 = 0;
            _Model.Operador2 = 0;
            _form1.ActualizarPantalla("0"); //La vista se actualiza a través del controlador.
        }

        public List<string> ObtenerRegistrosBitacora()
        {
            return Bitacora.ObtenerRegistros();
        }

    }
}