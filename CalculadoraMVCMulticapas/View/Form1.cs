using CalculadoraMVCMulticapas.Controllers;

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
            this.AcceptButton = null; //Deshabilita el comportamiento del Enter de contornear en azul un bot�n, evitando as� poder hacer enter a la operaci�n deseada.
            calculadoraController = new CalculadoraControllerClass(this); //Pasar la instancia al forms
            this.KeyPreview = true; //Permite que el forms capture eventos de teclado
            this.KeyDown += new KeyEventHandler(Form1_KeyDown); //Asocia el evento KeyDown al controlador de eventos.
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
            int Resultado = Convert.ToInt32(PantallaDeResultado.Text);
            calculadoraController.VerificarYGuardarPrimo(Resultado);
        }
        private void MostrarEnBinario(object sender, EventArgs e)
        {
            int Resultado = Convert.ToInt32(PantallaDeResultado.Text);
            calculadoraController.ConvertirYGuardarBinario(Resultado);
        }
        private void botonPromedio(object sender, EventArgs e)
        {
            double PromedioAMostrar = calculadoraController.SacarPromedioYMostrarlo();
            PantallaDeResultado.Text = PromedioAMostrar.ToString();
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


        public void ActualizarPantalla(string texto) //M�todo simple para que el controlador pueda actualizar la interfaz.
        {
            PantallaDeResultado.Text = texto;
            PantallaListaParaNuevoNumero = true; //Todo listo para recibir otra entrada nueva.
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Detectar n�meros (teclas del 0 al 9)
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                // Convertir la tecla presionada en un n�mero.
                string numero = (e.KeyCode - Keys.D0).ToString();
                AgregarNumeroPantalla(numero);
            }
            else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
            {
                calculadoraController.ProcesarOperacionPendiente();
                operacionActual = "+";
                PantallaListaParaNuevoNumero = true;
            }
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
                calculadoraController.ProcesarOperacionPendiente();
                operacionActual = "-";
                PantallaListaParaNuevoNumero = true;
            }
            else if (e.KeyCode == Keys.Multiply)
            {
                calculadoraController.ProcesarOperacionPendiente();
                operacionActual = "*";
                PantallaListaParaNuevoNumero = true;
            }
            else if (e.KeyCode == Keys.Divide || e.KeyCode == Keys.OemQuestion)
            {
                calculadoraController.ProcesarOperacionPendiente();
                operacionActual = "/";
                PantallaListaParaNuevoNumero = true;
            }
            else if (e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod)
            {
                AgregarNumeroPantalla(".");
            }
            else if (e.KeyCode == Keys.Back)
            {
                // Retroceder un d�gito
                if (PantallaDeResultado.Text.Length > 0)
                {
                    PantallaDeResultado.Text = PantallaDeResultado.Text.Substring(0, PantallaDeResultado.Text.Length - 1);
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                calculadoraController.ProcesarOperacionPendiente(); // Procesar la operaci�n igual.
                operacionActual = ""; // Limpiar la operaci�n actual.
                PantallaListaParaNuevoNumero = true; // Preparar la pantalla para un nuevo n�mero.
                e.Handled = true; // Prevenir que el evento se propague al bot�n enfocado.
            }
            else if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.C)
            {
                calculadoraController.ReiniciarCalcu();
            }

            // Prevenir que el evento se propague a otros controles si es necesario.
            e.Handled = true;
        }

        private void AgregarNumeroPantalla(string numero)
        {
            if (PantallaListaParaNuevoNumero)
            {
                PantallaDeResultado.Text = ""; // Limpia la pantalla si es una nueva operaci�n
                PantallaListaParaNuevoNumero = false;
            }

            // Validar punto decimal
            if (numero == "." && PantallaDeResultado.Text.Contains("."))
                return; // No permitir m�s de un punto decimal

            // Validar ceros iniciales
            if (PantallaDeResultado.Text == "0" && numero != ".")
                PantallaDeResultado.Text = ""; // Reemplazar el "0" inicial si no es un decimal

            // Concatenar n�mero
            PantallaDeResultado.Text += numero;
        }

        private void ActualizarPanelBitacora()
        {
            try
            {
                PanelDeBit�cora.Controls.Clear();
                List<string> registros = calculadoraController.ObtenerRegistrosBitacora();
                int yPosition = 10;
                foreach (string registro in registros)
                {
                    Label label = new Label
                    {
                        Text = registro,
                        AutoSize = true,
                        Location = new Point(10, yPosition)
                    };
                    PanelDeBit�cora.Controls.Add(label);
                    yPosition += 25;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la bit�cora: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Alternar la visibilidad del panel
            PanelDeBit�cora.Visible = !PanelDeBit�cora.Visible;

            if (PanelDeBit�cora.Visible)
            {
                ActualizarPanelBitacora();
            }
        }

        private void A�adirAMemoria_Click(object sender, EventArgs e)
        {
            //Se podr�a acceder directamente a Data, pero incumple los principios de MVC y la separaci�n de responsabilidades.
            double numero = Convert.ToDouble(PantallaDeResultado.Text);
            calculadoraController.GuardarEnMemoria(numero);
        }

        private void BitacoraPanel(object sender, PaintEventArgs e)
        {
        }
        private void PantallaDeResultado_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
