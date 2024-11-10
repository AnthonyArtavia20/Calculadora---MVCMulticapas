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
            _form1 = form1; //Se guarda la referencia de la parte gr�fica para poder acceder a las variables.
        }

        public void ProcesarOperacionPendiente() //Se usa en caso de que anteriormente hubiera una operaci�n realizada anteriormente y su resultado est� guardado en Operador1
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
                _form1.ActualizarPantalla(_Model.resultado.ToString());
                _Model.Operador1 = _Model.resultado;
                _form1.operacionActual = ""; // Limpiar operaci�n actual despu�s de ejecutarla
            }
            else
            {
                // Si no hay operaci�n previa, simplemente guardamos el n�mero actual como Operador1
                _Model.Operador1 = numeroActual;
            }
        }

        public bool VerificarPrimo(int numero) => CalculadoraModelClass.EsPrimoONo(numero);
        public string ObtenerBinario(int numero) => _Model.ConvertirABinario(numero);

        //Se crea un m�todo esp�cifico para reforzar la separaci�n de identidades
        //logrando comunicar Form1 con Controllers.

        public void ReiniciarCalcu()
        {
            _Model.Operador1 = 0;
            _Model.Operador2 = 0;
            _form1.ActualizarPantalla("0"); //La vista se actualiza a trav�s del controlador.
        }
    }
}