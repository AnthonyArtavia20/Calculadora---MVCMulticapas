using CalculadoraMVCMulticapas.Models;
using System.Xml.XPath;
using CalculadoraMVCMulticapas;
using System.Configuration;


namespace CalculadoraMVCMulticapas.Controllers
{
    public class CalculadoraControllerClass
    {
        private readonly CalculadoraModelClass _Model;
        private CalculadoraModelClass calculadoraModel = new CalculadoraModelClass();
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

                // Actualizamos la pantalla y el operador 1
                _form1.PantallaDeResultado.Text = _Model.resultado.ToString();
                _Model.Operador1 = _Model.resultado;
            }
            else
            {
                // Si no hay operación previa, simplemente guardamos el número actual como Operador1
                _Model.Operador1 = numeroActual;
            }
        }

        public bool VerificarPrimo(int numero) => CalculadoraModelClass.EsPrimoONo(numero);
        public string ObtenerBinario(int numero) => _Model.ConvertirABinario(numero);
    }
}