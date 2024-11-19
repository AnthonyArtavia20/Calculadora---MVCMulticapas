using CalculadoraMVCMulticapas.Controllers;
using CalculadoraMVCMulticapas.Services;
using CalculadoraMVCMulticapas.Models;
using CalculadoraMVCMulticapas.Data;
using CalculadoraMVCMulticapas.interfaces;

namespace CalculadoraMVCMulticapas
{
    public partial class Form1 : Form
    {
        private readonly CalculadoraControllerClass calculadoraController;
        private readonly ICalculadora _calculadoraService;

        /// <summary>
        /// /*
        ///     -> PantallaListaParaNuevoNumero:
        ///     Controla si la pantalla de la calculadora debe ser limpiada antes de escribir un nuevo 
        ///     numero. Esto ocurre despues de que se haya seleccionado una operacion (+, -, etc.) o 
        ///     despues de presionar el boton =.
        ///             * Si esta en true, se limpia la pantalla para que el usuario pueda escribir un 
        ///                 nuevo numero sin concatenar con el existente.
        ///             *Cambia a false despues de que el usuario comienza a ingresar un numero, 
        ///                 permitiendo concatenar numeros en lugar de limpiar repetidamente la pantalla.
        ///                 
        ///    -> ReiniciarCalculadora:
        ///    Indica si se puede iniciar una nueva operacion desde cero, como cuando se presiona el 
        ///    boton C (limpiar). Su funcion principal es reiniciar el flujo de la calculadora.
        ///             * Se asegura de que los operadores (Operador1 y Operador2) y la pantalla se reinicien,
        ///                 dejando la calculadora lista para un nuevo calculo.
        /// */ 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            var model = new CalculadoraModelClass();
            var bitacora = new BitacoraRepository();
            _calculadoraService = new CalculadoraService(model, bitacora);
            calculadoraController = new CalculadoraControllerClass(this, _calculadoraService, bitacora);
            
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.AcceptButton = null;
            
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.TabStop = false;
                }
            }
        }

        public string operacionActual = ""; // Operacion seleccionada
        private bool PantallaListaParaNuevoNumero = true; //En caso de una nueva operacion limpiar la pantalla.
        private bool ReiniciarCalculadora = true; //En caso de que se este realizando una nueva operacion

        public bool sePresionoIgual { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void buttonSuma_Click(object sender, EventArgs e)
        {
            _calculadoraService.Operador1 = Convert.ToDouble(PantallaDeResultado.Text);
            calculadoraController.ProcesarOperacionPendiente();
            operacionActual = "+";
            PantallaListaParaNuevoNumero = true;
        }

        private void botonResta_Click(object sender, EventArgs e)
        {
            _calculadoraService.Operador1 = Convert.ToDouble(PantallaDeResultado.Text);
            calculadoraController.ProcesarOperacionPendiente();
            operacionActual = "-";
            PantallaListaParaNuevoNumero = true;
        }

        private void BotonMulti_Click(object sender, EventArgs e)
        {
            _calculadoraService.Operador1 = Convert.ToDouble(PantallaDeResultado.Text);
            calculadoraController.ProcesarOperacionPendiente();
            operacionActual = "*";
            PantallaListaParaNuevoNumero = true;
        }

        private void buttonDividir_Click(object sender, EventArgs e)
        {
            _calculadoraService.Operador1 = Convert.ToDouble(PantallaDeResultado.Text);
            calculadoraController.ProcesarOperacionPendiente();
            operacionActual = "/";
            PantallaListaParaNuevoNumero = true;
        }
        private void BotonLimpiar_Click(object sender, EventArgs e)
        {
            calculadoraController.ReiniciarCalcu();
            ReiniciarCalculadora = true; //Reiniciar el estado de operacion
        }
        private void botonDecimal_Click(object sender, EventArgs e)
        {
            PantallaDeResultado.Text = PantallaDeResultado.Text + ".";
        }

        private void BotonIgual_Click(object sender, EventArgs e)
        {
            sePresionoIgual = true;
            calculadoraController.ProcesarOperacionPendiente();
            operacionActual = ""; // Limpiamos la operacion actual
            PantallaListaParaNuevoNumero = true;
            sePresionoIgual = false;
        }
        private void EsprimoONo(object sender, EventArgs e)
        {
            try
            {
                if (PantallaDeResultado.Text.Contains("Binario"))
                {
                    MessageBox.Show("No se puede convertir a primo desde binario",
                                        "Error de Conversión",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    return;
                } else if (PantallaDeResultado.Text.Contains(",") || PantallaDeResultado.Text.Contains("."))
                {
                    MessageBox.Show("No se puede verificar primo si tiene decimales",
                    "Error de Conversión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    return;
                } else if (PantallaDeResultado.Text.Contains("Primo"))
                {
                    MessageBox.Show("Ya fue verficiado si es primo",
                    "Error de Conversión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    return;
                }
                int Resultado = Convert.ToInt32(PantallaDeResultado.Text);
                calculadoraController.VerificarYGuardarPrimo(Resultado);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al verificar primo: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }
        private void MostrarEnBinario(object sender, EventArgs e)
        {
            try
            {
                if (PantallaDeResultado.Text.Contains(",") || PantallaDeResultado.Text.Contains("."))
                {
                    MessageBox.Show("No se puede convertir directamente un número con decimales a binario.",
                    "Error de Conversión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    return;
                } else if (PantallaDeResultado.Text.Contains("Primo"))
                {
                    MessageBox.Show("No se puede convertir a binario desde Primo",
                                        "Error de Conversión",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    return;
                } else if (PantallaDeResultado.Text.Contains("Binario"))
                {
                    MessageBox.Show("Ya fue convertido a binario",
                    "Error de Conversión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    return;
                }
                int Resultado = Convert.ToInt32(PantallaDeResultado.Text);
                calculadoraController.ConvertirYGuardarBinario(Resultado);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al convertir a binario: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }
        private void botonPromedio(object sender, EventArgs e)
        {
            double PromedioAMostrar = calculadoraController.SacarPromedioYMostrarlo();
            PantallaDeResultado.Text = PromedioAMostrar.ToString();
        }

        private void botonNumero_Click(object sender, EventArgs e) //Para no tener que hacer un metodo por boton, en FormsDisigner en los botones se llama este metodo.
        {
            Button boton = (Button)sender;

            if (PantallaListaParaNuevoNumero)
            {
                PantallaDeResultado.Text = ""; // Limpia la pantalla si es una nueva operacion
                PantallaListaParaNuevoNumero = false;
            }
            PantallaDeResultado.Text += boton.Text; // Agrega el numero presionado a la pantalla
        }


        public void ActualizarPantalla(string texto) //Metodo simple para que el controlador pueda actualizar la interfaz.
        {
            PantallaDeResultado.Text = texto;
            PantallaListaParaNuevoNumero = true; //Todo listo para recibir otra entrada nueva.
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Detectar numeros (teclas del 0 al 9)
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                // Convertir la tecla presionada en un numero.
                string numero = (e.KeyCode - Keys.D0).ToString();
                AgregarNumeroPantalla(numero);
            }
            else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
            {
                _calculadoraService.Operador1 = Convert.ToDouble(PantallaDeResultado.Text);
                calculadoraController.ProcesarOperacionPendiente();
                operacionActual = "+";
                PantallaListaParaNuevoNumero = true;
            }
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
                _calculadoraService.Operador1 = Convert.ToDouble(PantallaDeResultado.Text);
                calculadoraController.ProcesarOperacionPendiente();
                operacionActual = "-";
                PantallaListaParaNuevoNumero = true;
            }
            else if (e.KeyCode == Keys.Multiply)
            {
                _calculadoraService.Operador1 = Convert.ToDouble(PantallaDeResultado.Text);
                calculadoraController.ProcesarOperacionPendiente();
                operacionActual = "*";
                PantallaListaParaNuevoNumero = true;
            }
            else if (e.KeyCode == Keys.Divide || e.KeyCode == Keys.OemQuestion)
            {
                _calculadoraService.Operador1 = Convert.ToDouble(PantallaDeResultado.Text);
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
                // Retroceder un digito
                if (PantallaDeResultado.Text.Length > 0)
                {
                    PantallaDeResultado.Text = PantallaDeResultado.Text.Substring(0, PantallaDeResultado.Text.Length - 1);
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                sePresionoIgual = true;
                calculadoraController.ProcesarOperacionPendiente();
                operacionActual = "";
                PantallaListaParaNuevoNumero = true;
                sePresionoIgual = false;
                e.Handled = true;
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
                PantallaDeResultado.Text = "";
                PantallaListaParaNuevoNumero = false;
            }

            // Si es decimal, verificar que no exista ya un punto
            if (numero == "." && PantallaDeResultado.Text.Contains("."))
                return;

            // Si es el primer carácter y es un punto, agregar 0 antes
            if (PantallaDeResultado.Text.Length == 0 && numero == ".")
            {
                PantallaDeResultado.Text = "0";
            }

            // Si hay solo un 0 y no es punto decimal, reemplazar el 0
            if (PantallaDeResultado.Text == "0" && numero != ".")
            {
                PantallaDeResultado.Text = numero;
                return;
            }

            PantallaDeResultado.Text += numero;
        }

        private void ActualizarPanelBitacora()
        {
            try
            {
                PanelDeBitacora.Controls.Clear();
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
                    PanelDeBitacora.Controls.Add(label);
                    yPosition += 25;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la bitacora: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Alternar la visibilidad del panel
            PanelDeBitacora.Visible = !PanelDeBitacora.Visible;

            if (PanelDeBitacora.Visible)
            {
                ActualizarPanelBitacora();
            }
        }

        private void AnadirAMemoria_Click(object sender, EventArgs e)
        {
            //Se podria acceder directamente a Data, pero incumple los principios de MVC y la separacion de responsabilidades.
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
