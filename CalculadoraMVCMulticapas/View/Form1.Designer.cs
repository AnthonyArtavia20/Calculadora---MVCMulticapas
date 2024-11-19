namespace CalculadoraMVCMulticapas
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            botonBinario = new Button();
            PantallaDeResultado = new TextBox();
            BotonEsPrimoONo = new Button();
            button3 = new Button();
            boton7 = new Button();
            botonNumero8 = new Button();
            botonNumero9 = new Button();
            BotonParaPromedio = new Button();
            BotonAnadirAMemoria = new Button();
            BotonIgual = new Button();
            botonNumero6 = new Button();
            botonNumero5 = new Button();
            botonNumero4 = new Button();
            botonNumero3 = new Button();
            botonNumero2 = new Button();
            botonNumero1 = new Button();
            botonDecimal = new Button();
            BotonLimpiar = new Button();
            botonNumero0 = new Button();
            botonDividir = new Button();
            BotonMultiplicar = new Button();
            botonResta = new Button();
            botonSuma = new Button();
            PanelDeBitacora = new Panel();
            SuspendLayout();
            // 
            // botonBinario
            // 
            botonBinario.Location = new Point(31, 78);
            botonBinario.Name = "botonBinario";
            botonBinario.Size = new Size(163, 23);
            botonBinario.TabIndex = 0;
            botonBinario.Text = "Binario";
            botonBinario.UseVisualStyleBackColor = true;
            botonBinario.Click += MostrarEnBinario;
            // 
            // PantallaDeResultado
            // 
            PantallaDeResultado.Location = new Point(31, 26);
            PantallaDeResultado.Name = "PantallaDeResultado";
            PantallaDeResultado.Size = new Size(314, 23);
            PantallaDeResultado.TabIndex = 2;
            PantallaDeResultado.Text = "0";
            PantallaDeResultado.TextChanged += PantallaDeResultado_TextChanged;
            // 
            // BotonEsPrimoONo
            // 
            BotonEsPrimoONo.Location = new Point(31, 107);
            BotonEsPrimoONo.Name = "BotonEsPrimoONo";
            BotonEsPrimoONo.Size = new Size(163, 23);
            BotonEsPrimoONo.TabIndex = 3;
            BotonEsPrimoONo.Text = "Primo";
            BotonEsPrimoONo.UseVisualStyleBackColor = true;
            BotonEsPrimoONo.Click += EsprimoONo;
            // 
            // button3
            // 
            button3.Location = new Point(220, 78);
            button3.Name = "button3";
            button3.Size = new Size(125, 52);
            button3.TabIndex = 4;
            button3.Text = "Data";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // boton7
            // 
            boton7.Location = new Point(31, 163);
            boton7.Name = "boton7";
            boton7.Size = new Size(53, 49);
            boton7.TabIndex = 5;
            boton7.Text = "7";
            boton7.UseVisualStyleBackColor = true;
            boton7.Click += botonNumero_Click;
            // 
            // botonNumero8
            // 
            botonNumero8.Location = new Point(90, 163);
            botonNumero8.Name = "botonNumero8";
            botonNumero8.Size = new Size(53, 49);
            botonNumero8.TabIndex = 6;
            botonNumero8.Text = "8";
            botonNumero8.UseVisualStyleBackColor = true;
            botonNumero8.Click += botonNumero_Click;
            // 
            // botonNumero9
            // 
            botonNumero9.Location = new Point(149, 163);
            botonNumero9.Name = "botonNumero9";
            botonNumero9.Size = new Size(53, 49);
            botonNumero9.TabIndex = 7;
            botonNumero9.Text = "9";
            botonNumero9.UseVisualStyleBackColor = true;
            botonNumero9.Click += botonNumero_Click;
            // 
            // BotonParaPromedio
            // 
            BotonParaPromedio.Location = new Point(278, 163);
            BotonParaPromedio.Name = "BotonParaPromedio";
            BotonParaPromedio.Size = new Size(67, 49);
            BotonParaPromedio.TabIndex = 17;
            BotonParaPromedio.Text = "Avg";
            BotonParaPromedio.UseVisualStyleBackColor = true;
            BotonParaPromedio.Click += botonPromedio;
            // 
            // BotonAnadirAMemoria
            // 
            BotonAnadirAMemoria.Location = new Point(278, 218);
            BotonAnadirAMemoria.Name = "BotonAnadirAMemoria";
            BotonAnadirAMemoria.Size = new Size(67, 49);
            BotonAnadirAMemoria.TabIndex = 18;
            BotonAnadirAMemoria.Text = "M+";
            BotonAnadirAMemoria.UseVisualStyleBackColor = true;
            BotonAnadirAMemoria.Click += AnadirAMemoria_Click;
            // 
            // BotonIgual
            // 
            BotonIgual.Location = new Point(278, 273);
            BotonIgual.Name = "BotonIgual";
            BotonIgual.Size = new Size(67, 104);
            BotonIgual.TabIndex = 19;
            BotonIgual.Text = "=";
            BotonIgual.UseVisualStyleBackColor = true;
            BotonIgual.Click += BotonIgual_Click;
            // 
            // botonNumero6
            // 
            botonNumero6.Location = new Point(149, 218);
            botonNumero6.Name = "botonNumero6";
            botonNumero6.Size = new Size(53, 49);
            botonNumero6.TabIndex = 22;
            botonNumero6.Text = "6";
            botonNumero6.UseVisualStyleBackColor = true;
            botonNumero6.Click += botonNumero_Click;
            // 
            // botonNumero5
            // 
            botonNumero5.Location = new Point(90, 218);
            botonNumero5.Name = "botonNumero5";
            botonNumero5.Size = new Size(53, 49);
            botonNumero5.TabIndex = 21;
            botonNumero5.Text = "5";
            botonNumero5.UseVisualStyleBackColor = true;
            botonNumero5.Click += botonNumero_Click;
            // 
            // botonNumero4
            // 
            botonNumero4.Location = new Point(31, 218);
            botonNumero4.Name = "botonNumero4";
            botonNumero4.Size = new Size(53, 49);
            botonNumero4.TabIndex = 20;
            botonNumero4.Text = "4";
            botonNumero4.UseVisualStyleBackColor = true;
            botonNumero4.Click += botonNumero_Click;
            // 
            // botonNumero3
            // 
            botonNumero3.Location = new Point(149, 273);
            botonNumero3.Name = "botonNumero3";
            botonNumero3.Size = new Size(53, 49);
            botonNumero3.TabIndex = 25;
            botonNumero3.Text = "3";
            botonNumero3.UseVisualStyleBackColor = true;
            botonNumero3.Click += botonNumero_Click;
            // 
            // botonNumero2
            // 
            botonNumero2.Location = new Point(90, 273);
            botonNumero2.Name = "botonNumero2";
            botonNumero2.Size = new Size(53, 49);
            botonNumero2.TabIndex = 24;
            botonNumero2.Text = "2";
            botonNumero2.UseVisualStyleBackColor = true;
            botonNumero2.Click += botonNumero_Click;
            // 
            // botonNumero1
            // 
            botonNumero1.Location = new Point(31, 273);
            botonNumero1.Name = "botonNumero1";
            botonNumero1.Size = new Size(53, 49);
            botonNumero1.TabIndex = 23;
            botonNumero1.Text = "1";
            botonNumero1.UseVisualStyleBackColor = true;
            botonNumero1.Click += botonNumero_Click;
            // 
            // botonDecimal
            // 
            botonDecimal.Location = new Point(149, 328);
            botonDecimal.Name = "botonDecimal";
            botonDecimal.Size = new Size(53, 49);
            botonDecimal.TabIndex = 28;
            botonDecimal.Text = ",";
            botonDecimal.UseVisualStyleBackColor = true;
            botonDecimal.Click += botonDecimal_Click;
            // 
            // BotonLimpiar
            // 
            BotonLimpiar.Location = new Point(90, 328);
            BotonLimpiar.Name = "BotonLimpiar";
            BotonLimpiar.Size = new Size(53, 49);
            BotonLimpiar.TabIndex = 27;
            BotonLimpiar.Text = "c";
            BotonLimpiar.UseVisualStyleBackColor = true;
            BotonLimpiar.Click += BotonLimpiar_Click;
            // 
            // botonNumero0
            // 
            botonNumero0.Location = new Point(31, 328);
            botonNumero0.Name = "botonNumero0";
            botonNumero0.Size = new Size(53, 49);
            botonNumero0.TabIndex = 26;
            botonNumero0.Text = "0";
            botonNumero0.UseVisualStyleBackColor = true;
            botonNumero0.Click += botonNumero_Click;
            // 
            // botonDividir
            // 
            botonDividir.Location = new Point(219, 163);
            botonDividir.Name = "botonDividir";
            botonDividir.Size = new Size(53, 49);
            botonDividir.TabIndex = 29;
            botonDividir.Text = "/";
            botonDividir.UseVisualStyleBackColor = true;
            botonDividir.Click += buttonDividir_Click;
            // 
            // BotonMultiplicar
            // 
            BotonMultiplicar.Location = new Point(219, 218);
            BotonMultiplicar.Name = "BotonMultiplicar";
            BotonMultiplicar.Size = new Size(53, 49);
            BotonMultiplicar.TabIndex = 30;
            BotonMultiplicar.Text = "*";
            BotonMultiplicar.UseVisualStyleBackColor = true;
            BotonMultiplicar.Click += BotonMulti_Click;
            // 
            // botonResta
            // 
            botonResta.Location = new Point(219, 273);
            botonResta.Name = "botonResta";
            botonResta.Size = new Size(53, 49);
            botonResta.TabIndex = 31;
            botonResta.Text = "-";
            botonResta.UseVisualStyleBackColor = true;
            botonResta.Click += botonResta_Click;
            // 
            // botonSuma
            // 
            botonSuma.Location = new Point(219, 328);
            botonSuma.Name = "botonSuma";
            botonSuma.Size = new Size(53, 49);
            botonSuma.TabIndex = 32;
            botonSuma.Text = "+";
            botonSuma.UseVisualStyleBackColor = true;
            botonSuma.Click += buttonSuma_Click;
            // 
            // PanelDeBitacora
            // 
            PanelDeBitacora.AutoScroll = true;
            PanelDeBitacora.BorderStyle = BorderStyle.FixedSingle;
            PanelDeBitacora.Cursor = Cursors.Cross;
            PanelDeBitacora.Location = new Point(13, 150);
            PanelDeBitacora.Name = "PanelDeBitacora";
            PanelDeBitacora.Size = new Size(200, 288);
            PanelDeBitacora.TabIndex = 33;
            PanelDeBitacora.Visible = false;
            PanelDeBitacora.Paint += BitacoraPanel;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 450);
            Controls.Add(PanelDeBitacora);
            Controls.Add(botonSuma);
            Controls.Add(botonResta);
            Controls.Add(BotonMultiplicar);
            Controls.Add(botonDividir);
            Controls.Add(botonDecimal);
            Controls.Add(BotonLimpiar);
            Controls.Add(botonNumero0);
            Controls.Add(botonNumero3);
            Controls.Add(botonNumero2);
            Controls.Add(botonNumero1);
            Controls.Add(botonNumero6);
            Controls.Add(botonNumero5);
            Controls.Add(botonNumero4);
            Controls.Add(BotonIgual);
            Controls.Add(BotonAnadirAMemoria);
            Controls.Add(BotonParaPromedio);
            Controls.Add(botonNumero9);
            Controls.Add(botonNumero8);
            Controls.Add(boton7);
            Controls.Add(button3);
            Controls.Add(BotonEsPrimoONo);
            Controls.Add(PantallaDeResultado);
            Controls.Add(botonBinario);
            Name = "Form1";
            Text = "Calculadora - MVCMulticapas";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button botonBinario;
        public TextBox PantallaDeResultado;
        private Button BotonEsPrimoONo;
        private Button button3;
        private Button boton7;
        private Button botonNumero8;
        private Button botonNumero9;
        private Button BotonParaPromedio;
        private Button BotonAnadirAMemoria;
        private Button BotonIgual;
        private Button botonNumero6;
        private Button botonNumero5;
        private Button botonNumero4;
        private Button botonNumero3;
        private Button botonNumero2;
        private Button botonNumero1;
        private Button botonDecimal;
        private Button BotonLimpiar;
        private Button botonNumero0;
        private Button botonDividir;
        private Button BotonMultiplicar;
        private Button botonResta;
        private Button botonSuma;
        private Panel PanelDeBitacora;
    }
}
