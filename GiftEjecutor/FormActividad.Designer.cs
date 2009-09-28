namespace GiftEjecutor
{
    partial class FormActividad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridComandos = new System.Windows.Forms.DataGridView();
            this.buttonEjecutarComando = new System.Windows.Forms.Button();
            this.dataGridEjecutados = new System.Windows.Forms.DataGridView();
            this.dataGridNoPosibles = new System.Windows.Forms.DataGridView();
            this.labelComandosNoEjecutados = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelComandosSinEjecutar = new System.Windows.Forms.Label();
            this.labelEncabezadoComando = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridComandos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEjecutados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNoPosibles)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridComandos
            // 
            this.dataGridComandos.AllowUserToAddRows = false;
            this.dataGridComandos.AllowUserToDeleteRows = false;
            this.dataGridComandos.AllowUserToOrderColumns = true;
            this.dataGridComandos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridComandos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridComandos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridComandos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridComandos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridComandos.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridComandos.Location = new System.Drawing.Point(90, 133);
            this.dataGridComandos.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridComandos.Name = "dataGridComandos";
            this.dataGridComandos.ReadOnly = true;
            this.dataGridComandos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridComandos.Size = new System.Drawing.Size(469, 110);
            this.dataGridComandos.TabIndex = 1;
            this.dataGridComandos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridComandos_CellClick);
            this.dataGridComandos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridComandos_CellContentClick);
            // 
            // buttonEjecutarComando
            // 
            this.buttonEjecutarComando.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonEjecutarComando.Enabled = false;
            this.buttonEjecutarComando.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonEjecutarComando.FlatAppearance.BorderSize = 3;
            this.buttonEjecutarComando.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LawnGreen;
            this.buttonEjecutarComando.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.buttonEjecutarComando.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonEjecutarComando.Location = new System.Drawing.Point(222, 261);
            this.buttonEjecutarComando.Name = "buttonEjecutarComando";
            this.buttonEjecutarComando.Size = new System.Drawing.Size(195, 70);
            this.buttonEjecutarComando.TabIndex = 2;
            this.buttonEjecutarComando.Text = "Ejecutar Comando!";
            this.buttonEjecutarComando.UseVisualStyleBackColor = false;
            this.buttonEjecutarComando.MouseLeave += new System.EventHandler(this.cambiarColorBotonOut);
            this.buttonEjecutarComando.Click += new System.EventHandler(this.buttonEjecutarComando_Click);
            this.buttonEjecutarComando.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cambiarColorBotonClick);
            this.buttonEjecutarComando.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CambiarColorBotonOut);
            this.buttonEjecutarComando.EnabledChanged += new System.EventHandler(this.buttonEjecutarComando_EnabledChanged);
            this.buttonEjecutarComando.MouseEnter += new System.EventHandler(this.cambiarColorBotonOver);
            // 
            // dataGridEjecutados
            // 
            this.dataGridEjecutados.AllowUserToAddRows = false;
            this.dataGridEjecutados.AllowUserToDeleteRows = false;
            this.dataGridEjecutados.AllowUserToOrderColumns = true;
            this.dataGridEjecutados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridEjecutados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridEjecutados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridEjecutados.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridEjecutados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEjecutados.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridEjecutados.Location = new System.Drawing.Point(12, 442);
            this.dataGridEjecutados.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridEjecutados.Name = "dataGridEjecutados";
            this.dataGridEjecutados.ReadOnly = true;
            this.dataGridEjecutados.Size = new System.Drawing.Size(287, 110);
            this.dataGridEjecutados.TabIndex = 3;
            // 
            // dataGridNoPosibles
            // 
            this.dataGridNoPosibles.AllowUserToAddRows = false;
            this.dataGridNoPosibles.AllowUserToDeleteRows = false;
            this.dataGridNoPosibles.AllowUserToOrderColumns = true;
            this.dataGridNoPosibles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridNoPosibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridNoPosibles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridNoPosibles.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridNoPosibles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridNoPosibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridNoPosibles.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridNoPosibles.Location = new System.Drawing.Point(342, 442);
            this.dataGridNoPosibles.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridNoPosibles.Name = "dataGridNoPosibles";
            this.dataGridNoPosibles.ReadOnly = true;
            this.dataGridNoPosibles.Size = new System.Drawing.Size(287, 110);
            this.dataGridNoPosibles.TabIndex = 4;
            // 
            // labelComandosNoEjecutados
            // 
            this.labelComandosNoEjecutados.AutoSize = true;
            this.labelComandosNoEjecutados.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComandosNoEjecutados.Location = new System.Drawing.Point(34, 425);
            this.labelComandosNoEjecutados.Name = "labelComandosNoEjecutados";
            this.labelComandosNoEjecutados.Size = new System.Drawing.Size(251, 14);
            this.labelComandosNoEjecutados.TabIndex = 0;
            this.labelComandosNoEjecutados.Text = "Comandos que ya fueron ejecutados:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Firebrick;
            this.label2.Location = new System.Drawing.Point(47, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(556, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Estos son los comandos que se pueden ejecutar en este momento:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelComandosSinEjecutar
            // 
            this.labelComandosSinEjecutar.AutoSize = true;
            this.labelComandosSinEjecutar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComandosSinEjecutar.Location = new System.Drawing.Point(328, 425);
            this.labelComandosSinEjecutar.Name = "labelComandosSinEjecutar";
            this.labelComandosSinEjecutar.Size = new System.Drawing.Size(311, 14);
            this.labelComandosSinEjecutar.TabIndex = 0;
            this.labelComandosSinEjecutar.Text = "Comandos que todavía no se pueden ejecutar:";
            this.labelComandosSinEjecutar.Click += new System.EventHandler(this.label3_Click);
            // 
            // labelEncabezadoComando
            // 
            this.labelEncabezadoComando.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEncabezadoComando.AutoSize = true;
            this.labelEncabezadoComando.Font = new System.Drawing.Font("Verdana", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEncabezadoComando.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelEncabezadoComando.Location = new System.Drawing.Point(12, 9);
            this.labelEncabezadoComando.Name = "labelEncabezadoComando";
            this.labelEncabezadoComando.Size = new System.Drawing.Size(332, 26);
            this.labelEncabezadoComando.TabIndex = 0;
            this.labelEncabezadoComando.Text = "Comandos de la Actividad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(80, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(492, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "(Para ejecutar uno de ellos, selecciónelo y haga click en el botón \"ejecutar coma" +
                "ndo\")";
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonCerrar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCerrar.Location = new System.Drawing.Point(282, 365);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(75, 23);
            this.buttonCerrar.TabIndex = 13;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = false;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            this.buttonCerrar.Leave += new System.EventHandler(this.buttonCerrarColorOscuro);
            this.buttonCerrar.Enter += new System.EventHandler(this.buttonCerrarColorClaro);
            // 
            // FormActividad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 564);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelEncabezadoComando);
            this.Controls.Add(this.labelComandosSinEjecutar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelComandosNoEjecutados);
            this.Controls.Add(this.dataGridNoPosibles);
            this.Controls.Add(this.dataGridEjecutados);
            this.Controls.Add(this.buttonEjecutarComando);
            this.Controls.Add(this.dataGridComandos);
            this.Name = "FormActividad";
            this.Text = "Comandos";
            this.Load += new System.EventHandler(this.FormActividad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridComandos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEjecutados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNoPosibles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridComandos;
        private System.Windows.Forms.Button buttonEjecutarComando;
        private System.Windows.Forms.DataGridView dataGridEjecutados;
        private System.Windows.Forms.DataGridView dataGridNoPosibles;
        private System.Windows.Forms.Label labelComandosNoEjecutados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelComandosSinEjecutar;
        private System.Windows.Forms.Label labelEncabezadoComando;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCerrar;
    }
}