namespace AnalizadorCarpetas.UI
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.grpModo = new System.Windows.Forms.GroupBox();
            this.rbSecuencial = new System.Windows.Forms.RadioButton();
            this.rbThread = new System.Windows.Forms.RadioButton();
            this.rbTask = new System.Windows.Forms.RadioButton();
            this.rbAsync = new System.Windows.Forms.RadioButton();
            this.txtArchivoActual = new System.Windows.Forms.TextBox();
            this.lblCantidadArchivos = new System.Windows.Forms.Label();
            this.lblCantidadCarpetas = new System.Windows.Forms.Label();
            this.lblTamañoTotal = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtAnalisisIA = new System.Windows.Forms.TextBox();
            this.btnAnalizarIA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(39, 13);
            this.txtRuta.Multiline = true;
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(691, 42);
            this.txtRuta.TabIndex = 0;
            this.txtRuta.TextChanged += new System.EventHandler(this.txtRuta_TextChanged);
            // 
            // btnExaminar
            // 
            this.btnExaminar.Location = new System.Drawing.Point(39, 95);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(103, 53);
            this.btnExaminar.TabIndex = 1;
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // grpModo
            // 
            this.grpModo.Location = new System.Drawing.Point(39, 173);
            this.grpModo.Name = "grpModo";
            this.grpModo.Size = new System.Drawing.Size(249, 154);
            this.grpModo.TabIndex = 2;
            this.grpModo.TabStop = false;
            this.grpModo.Text = "groupBox1";
            // 
            // rbSecuencial
            // 
            this.rbSecuencial.AutoSize = true;
            this.rbSecuencial.Location = new System.Drawing.Point(196, 382);
            this.rbSecuencial.Name = "rbSecuencial";
            this.rbSecuencial.Size = new System.Drawing.Size(98, 20);
            this.rbSecuencial.TabIndex = 3;
            this.rbSecuencial.TabStop = true;
            this.rbSecuencial.Text = "Secuencial ";
            this.rbSecuencial.UseVisualStyleBackColor = true;
            // 
            // rbThread
            // 
            this.rbThread.AutoSize = true;
            this.rbThread.Location = new System.Drawing.Point(196, 418);
            this.rbThread.Name = "rbThread";
            this.rbThread.Size = new System.Drawing.Size(72, 20);
            this.rbThread.TabIndex = 4;
            this.rbThread.TabStop = true;
            this.rbThread.Text = "Thread";
            this.rbThread.UseVisualStyleBackColor = true;
            this.rbThread.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbTask
            // 
            this.rbTask.AutoSize = true;
            this.rbTask.Location = new System.Drawing.Point(196, 445);
            this.rbTask.Name = "rbTask";
            this.rbTask.Size = new System.Drawing.Size(59, 20);
            this.rbTask.TabIndex = 5;
            this.rbTask.TabStop = true;
            this.rbTask.Text = "Task";
            this.rbTask.UseVisualStyleBackColor = true;
            this.rbTask.CheckedChanged += new System.EventHandler(this.rbTask_CheckedChanged);
            // 
            // rbAsync
            // 
            this.rbAsync.AutoSize = true;
            this.rbAsync.Location = new System.Drawing.Point(196, 481);
            this.rbAsync.Name = "rbAsync";
            this.rbAsync.Size = new System.Drawing.Size(65, 20);
            this.rbAsync.TabIndex = 6;
            this.rbAsync.TabStop = true;
            this.rbAsync.Text = "Async";
            this.rbAsync.UseVisualStyleBackColor = true;
            // 
            // txtArchivoActual
            // 
            this.txtArchivoActual.Location = new System.Drawing.Point(196, 535);
            this.txtArchivoActual.Name = "txtArchivoActual";
            this.txtArchivoActual.Size = new System.Drawing.Size(100, 22);
            this.txtArchivoActual.TabIndex = 7;
            // 
            // lblCantidadArchivos
            // 
            this.lblCantidadArchivos.AutoSize = true;
            this.lblCantidadArchivos.Location = new System.Drawing.Point(359, 65);
            this.lblCantidadArchivos.Name = "lblCantidadArchivos";
            this.lblCantidadArchivos.Size = new System.Drawing.Size(137, 16);
            this.lblCantidadArchivos.TabIndex = 8;
            this.lblCantidadArchivos.Text = "Cantidad de archivos ";
            // 
            // lblCantidadCarpetas
            // 
            this.lblCantidadCarpetas.AutoSize = true;
            this.lblCantidadCarpetas.Location = new System.Drawing.Point(359, 95);
            this.lblCantidadCarpetas.Name = "lblCantidadCarpetas";
            this.lblCantidadCarpetas.Size = new System.Drawing.Size(136, 16);
            this.lblCantidadCarpetas.TabIndex = 9;
            this.lblCantidadCarpetas.Text = "Cantidad de carpetas";
            // 
            // lblTamañoTotal
            // 
            this.lblTamañoTotal.AutoSize = true;
            this.lblTamañoTotal.Location = new System.Drawing.Point(359, 126);
            this.lblTamañoTotal.Name = "lblTamañoTotal";
            this.lblTamañoTotal.Size = new System.Drawing.Size(86, 16);
            this.lblTamañoTotal.TabIndex = 10;
            this.lblTamañoTotal.Text = "Tamaño total";
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(359, 152);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(54, 16);
            this.lblTiempo.TabIndex = 11;
            this.lblTiempo.Text = "Tiempo";
            this.lblTiempo.Click += new System.EventHandler(this.lblTiempo_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(362, 186);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(380, 21);
            this.progressBar1.TabIndex = 12;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(421, 282);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 13;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(421, 339);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtAnalisisIA
            // 
            this.txtAnalisisIA.Location = new System.Drawing.Point(573, 444);
            this.txtAnalisisIA.Multiline = true;
            this.txtAnalisisIA.Name = "txtAnalisisIA";
            this.txtAnalisisIA.ReadOnly = true;
            this.txtAnalisisIA.Size = new System.Drawing.Size(290, 182);
            this.txtAnalisisIA.TabIndex = 15;
            // 
            // btnAnalizarIA
            // 
            this.btnAnalizarIA.Location = new System.Drawing.Point(643, 405);
            this.btnAnalizarIA.Name = "btnAnalizarIA";
            this.btnAnalizarIA.Size = new System.Drawing.Size(150, 23);
            this.btnAnalizarIA.TabIndex = 16;
            this.btnAnalizarIA.Text = "Analizar con IA";
            this.btnAnalizarIA.UseVisualStyleBackColor = true;
            this.btnAnalizarIA.Click += new System.EventHandler(this.btnAnalizarIA_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 667);
            this.Controls.Add(this.btnAnalizarIA);
            this.Controls.Add(this.txtAnalisisIA);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.lblTamañoTotal);
            this.Controls.Add(this.lblCantidadCarpetas);
            this.Controls.Add(this.lblCantidadArchivos);
            this.Controls.Add(this.txtArchivoActual);
            this.Controls.Add(this.rbAsync);
            this.Controls.Add(this.rbTask);
            this.Controls.Add(this.rbThread);
            this.Controls.Add(this.rbSecuencial);
            this.Controls.Add(this.grpModo);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.txtRuta);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.GroupBox grpModo;
        private System.Windows.Forms.RadioButton rbSecuencial;
        private System.Windows.Forms.RadioButton rbThread;
        private System.Windows.Forms.RadioButton rbTask;
        private System.Windows.Forms.RadioButton rbAsync;
        private System.Windows.Forms.TextBox txtArchivoActual;
        private System.Windows.Forms.Label lblCantidadArchivos;
        private System.Windows.Forms.Label lblCantidadCarpetas;
        private System.Windows.Forms.Label lblTamañoTotal;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtAnalisisIA;
        private System.Windows.Forms.Button btnAnalizarIA;
    }
}

