using CalculadoraMVCMulticapas.Controllers;
using CalculadoraMVCMulticapas.Models;

namespace CalculadoraMVCMulticapas
{
    public partial class Form1 : Form
    {
        private CalculadoraModelClass calculadoraModel = new CalculadoraModelClass();
        private CalculadoraControllerClass calculadoraController;

        public Form1()
        {
            InitializeComponent();
            calculadoraController = new CalculadoraControllerClass(this); //Pasar la instancia al forms
    }

        public string operacionActual = ""; // Operación seleccionada
        private bool nuevaOperacion = true; //En caso de una nueva operación limpiar la pantalla.

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Botón número 7

            if (PantallaDeResultado.Text == "0")
            {
                PantallaDeResultado.Text = "";
            }

            PantallaDeResultado.Text = PantallaDeResultado.Text + "7";

        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Botón número 2
            if (PantallaDeResultado.Text == "0") PantallaDeResultado.Text = "";
            PantallaDeResultado.Text = PantallaDeResultado.Text + "2";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Botón número 5
            if (PantallaDeResultado.Text == "0") PantallaDeResultado.Text = "";
            PantallaDeResultado.Text = PantallaDeResultado.Text + "5";
        }

        private void BotonLimpiar_Click(object sender, EventArgs e)
        {
            PantallaDeResultado.Text = "0";
            calculadoraModel.Operador1 = 0;
            calculadoraModel.Operador2 = 0;
            NuevaOperadcionARealizar = true; //Reiniciar el estado de operación
        }

        private void PantallaDeResultado_TextChanged(object sender, EventArgs e)
        {

        }

        private void botonNumero8_Click(object sender, EventArgs e)
        {
            //Botón número 8
            if (PantallaDeResultado.Text == "0") PantallaDeResultado.Text = "";
            PantallaDeResultado.Text = PantallaDeResultado.Text + "8";
        }

        private void botonNumero9_Click(object sender, EventArgs e)
        {
            //Botón número 9
            if (PantallaDeResultado.Text == "0") PantallaDeResultado.Text = "";
            PantallaDeResultado.Text = PantallaDeResultado.Text + "9";
        }

        private void botonNumero4_Click(object sender, EventArgs e)
        {
            //Botón número 4
            if (PantallaDeResultado.Text == "0") PantallaDeResultado.Text = "";
            PantallaDeResultado.Text = PantallaDeResultado.Text + "4";
        }

        private void botonNumero6_Click(object sender, EventArgs e)
        {
            //Botón número 6
            if (PantallaDeResultado.Text == "0") PantallaDeResultado.Text = "";
            PantallaDeResultado.Text = PantallaDeResultado.Text + "6";
        }

        private void botonNumero1_Click(object sender, EventArgs e)
        {
            //Botón número 1
            if (PantallaDeResultado.Text == "0") PantallaDeResultado.Text = "";
            PantallaDeResultado.Text = PantallaDeResultado.Text + "1";
        }

        private void botonNumero3_Click(object sender, EventArgs e)
        {
            //Botón número 3
            if (PantallaDeResultado.Text == "0") PantallaDeResultado.Text = "";
            PantallaDeResultado.Text = PantallaDeResultado.Text + "3";
        }

        private void botonNumero0_Click(object sender, EventArgs e)
        {
            PantallaDeResultado.Text = PantallaDeResultado.Text + "0";
        }

        private void botonDecimal_Click(object sender, EventArgs e)
        {
            PantallaDeResultado.Text = PantallaDeResultado.Text + ".";
        }

        private bool NuevaOperadcionARealizar = true; //En caso de que se esté realizando una nueva operación

        private void buttonSuma_Click(object sender, EventArgs e)
        {
            calculadoraController.ProcesarOperacionPendiente();
            operacionActual = "+";
            nuevaOperacion = true;

        }

        private void BotonMulti_Click(object sender, EventArgs e)
        {
            calculadoraController.ProcesarOperacionPendiente();
            operacionActual = "*";
            nuevaOperacion = true;
        }

        private void buttonDividir_Click(object sender, EventArgs e)
        {
            calculadoraController.ProcesarOperacionPendiente();
            operacionActual = "/";
            nuevaOperacion = true;
        }

        private void botonResta_Click(object sender, EventArgs e)
        {
            calculadoraController.ProcesarOperacionPendiente();
            operacionActual = "-";
            nuevaOperacion = true;
        }

        private void BotonIgual_Click(object sender, EventArgs e)
        {
            calculadoraController.ProcesarOperacionPendiente(); //Para procesar lo que ya esté en memoria
            operacionActual = ""; //Limpiar la operación actual
            nuevaOperacion = true; //Permite iniciar un nuevo cálculo
        }

        private void botonNumero_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;

            if (nuevaOperacion)
            {
                PantallaDeResultado.Text = "";
                nuevaOperacion = false;
            }

            PantallaDeResultado.Text += boton.Text;
        }
    }
}
