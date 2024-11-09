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

        public double RealizacionOperaciones(double operando1, double operando2, string operacion)
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

        public void ProcesarOperacionPendiente()
        {
            double numeroActual = Convert.ToDouble(_form1.PantallaDeResultado.Text);

            if (!string.IsNullOrEmpty(_form1.operacionActual))
            {
                _Model.Operador2 = numeroActual;

                switch (_form1.operacionActual)
                {
                    case "+":
                        calculadoraModel.Sumar();
                        break;
                    case "-":
                        calculadoraModel.Restar();
                        break;
                    case "*":
                        calculadoraModel.Multiplicar();
                        break;
                    case "/":
                        try
                        {
                            calculadoraModel.Dividir();
                        }
                        catch (DivideByZeroException ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            _form1.PantallaDeResultado.Text = "0";
                            return;
                        }
                        break;
                }

                _form1.PantallaDeResultado.Text = calculadoraModel.resultado.ToString();
                _Model.Operador1 = _Model.resultado;
            }
            else
            {
                _Model.Operador1 = numeroActual;
            }
        }

        public bool VerificarPrimo(int numero) => _Model.EsPrimoONo(numero);
        public string ObtenerBinario(int numero) => _Model.ConvertirABinario(numero);
    }
}