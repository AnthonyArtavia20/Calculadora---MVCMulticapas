using CalculadoraMVCMulticapas.Controllers;
using CalculadoraMVCMulticapas.Models;

namespace CalculadoraMVCMulticapas
{
    public partial class Form1 : Form
    {

        private CalculadoraControllerClass calculadoraController;
        /// <summary>
        /// /*
        ///     -> PantallaListaParaNuevoNumero:
        ///     Controla si la pantalla de la calculadora debe ser limpiada antes de escribir un nuevo 
        ///     n�mero. Esto ocurre despu�s de que se haya seleccionado una operaci�n (+, -, etc.) o 
        ///     despu�s de presionar el bot�n =.
        ///             * Si est� en true, se limpia la pantalla para que el usuario pueda escribir un 
        ///                 nuevo n�mero sin concatenar con el existente.
        ///             *Cambia a false despu�s de que el usuario comienza a ingresar un n�mero, 
        ///                 permitiendo concatenar n�meros en lugar de limpiar repetidamente la pantalla.
        ///                 
        ///    -> ReiniciarCalculadora:
        ///    Indica si se puede iniciar una nueva operaci�n desde cero, como cuando se presiona el 
        ///    bot�n C (limpiar). Su funci�n principal es reiniciar el flujo de la calculadora.
        ///             * Se asegura de que los operadores (Operador1 y Operador2) y la pantalla se reinicien,
        ///                 dejando la calculadora lista para un nuevo c�lculo.
        /// */ 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            calculadoraController = new CalculadoraControllerClass(this); //Pasar la instancia al forms
        }

        public string operacionActual = ""; // Operaci�n seleccionada
        private bool PantallaListaParaNuevoNumero = true; //En caso de una nueva operaci�n limpiar la pantalla.
        private bool ReiniciarCalculadora = true; //En caso de que se est� realizando una nueva operaci�n

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void buttonSuma_Click(object sender, EventArgs e)
        {
            calculadoraController.ProcesarOperacionPendiente();
            operacionActual = "+"; // Guardamos la operaci�n actual
            PantallaListaParaNuevoNumero = true; // Indicamos que se puede empezar una nueva entrada
        }

        private void botonResta_Click(object sender, EventArgs e)
        {
            calculadoraController.ProcesarOperacionPendiente();
            operacionActual = "-";
            PantallaListaParaNuevoNumero = true;
        }

        private void BotonMulti_Click(object sender, EventArgs e)
        {
            calculadoraController.ProcesarOperacionPendiente();
            operacionActual = "*";
            PantallaListaParaNuevoNumero = true;
        }

        private void buttonDividir_Click(object sender, EventArgs e)
        {
            calculadoraController.ProcesarOperacionPendiente();
            operacionActual = "/";
            PantallaListaParaNuevoNumero = true;
        }
        private void BotonLimpiar_Click(object sender, EventArgs e)
        {
            calculadoraController.ReiniciarCalcu();
            ReiniciarCalculadora = true; //Reiniciar el estado de operaci�n
        }
        private void botonDecimal_Click(object sender, EventArgs e)
        {
            PantallaDeResultado.Text = PantallaDeResultado.Text + ".";
        }

        private void BotonIgual_Click(object sender, EventArgs e)
        {
            calculadoraController.ProcesarOperacionPendiente();
            operacionActual = ""; // Limpiamos la operaci�n actual
            PantallaListaParaNuevoNumero = true;
        }
        private void EsprimoONo(object sender, EventArgs e)
        {
            bool Resultado = calculadoraController.VerificarPrimo(Convert.ToInt32(PantallaDeResultado.Text));
            PantallaDeResultado.Text = Convert.ToString(Resultado);

        }
        private void botonNumero_Click(object sender, EventArgs e) //Para no tener que hacer un m�todo por bot�n, en FormsDisigner en los botones se llama este m�todo.
        {
            Button boton = (Button)sender;

            if (PantallaListaParaNuevoNumero)
            {
                PantallaDeResultado.Text = ""; // Limpia la pantalla si es una nueva operaci�n
                PantallaListaParaNuevoNumero = false;
            }

            PantallaDeResultado.Text += boton.Text; // Agrega el n�mero presionado a la pantalla
        }

        private void MostrarEnBinario(object sender, EventArgs e)
        {
            string Resultado = calculadoraController.ObtenerBinario(Convert.ToInt32(PantallaDeResultado.Text));
            PantallaDeResultado.Text = Resultado;
        }


        private void PantallaDeResultado_TextChanged(object sender, EventArgs e)
        {

        }

        public void ActualizarPantalla(sting texto) //M�todo simple para que el controlador pueda actualizar la interfaz.
        {
            PantallaDeResultado.Text = texto;
        }
    }
}
