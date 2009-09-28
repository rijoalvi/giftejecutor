namespace GiftEjecutor
{
    partial class FormListadoActividad
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
            this.labelEncabezadoActividades = new System.Windows.Forms.Label();
            this.dataGridActividad = new System.Windows.Forms.DataGridView();
            this.buttonEjecutarActividad = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridEjecutados = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridPorEjecutar = new System.Windows.Forms.DataGridView();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridActividad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEjecutados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPorEjecutar)).BeginInit();
            this.SuspendLayout();
            // 
            // labelEncabezadoActividades
            // 
            this.labelEncabezadoActividades.AutoSize = true;
            this.labelEncabezadoActividades.Font = new System.Drawing.Font("Verdana", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEncabezadoActividades.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelEncabezadoActividades.Location = new System.Drawing.Point(12, 9);
            this.labelEncabezadoActividades.Name = "labelEncabezadoActividades";
            this.labelEncabezadoActividades.Size = new System.Drawing.Size(266, 26);
            this.labelEncabezadoActividades.TabIndex = 0;
            this.labelEncabezadoActividades.Text = "Actividades del flujo";
            // 
            // dataGridActividad
            // 
            this.dataGridActividad.AllowUserToAddRows = false;
            this.dataGridActividad.AllowUserToDeleteRows = false;
            this.dataGridActividad.AllowUserToOrderColumns = true;
            this.dataGridActividad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridActividad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridActividad.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridActividad.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridActividad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridActividad.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridActividad.Location = new System.Drawing.Point(90, 133);
            this.dataGridActividad.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridActividad.Name = "dataGridActividad";
            this.dataGridActividad.ReadOnly = true;
            this.dataGridActividad.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridActividad.Size = new System.Drawing.Size(469, 110);
            this.dataGridActividad.TabIndex = 1;
            this.dataGridActividad.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridActividad_CellClick_1);
            // 
            // buttonEjecutarActividad
            // 
            this.buttonEjecutarActividad.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonEjecutarActividad.Enabled = false;
            this.buttonEjecutarActividad.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonEjecutarActividad.Location = new System.Drawing.Point(222, 261);
            this.buttonEjecutarActividad.Name = "buttonEjecutarActividad";
            this.buttonEjecutarActividad.Size = new System.Drawing.Size(195, 70);
            this.buttonEjecutarActividad.TabIndex = 2;
            this.buttonEjecutarActividad.Text = "Ejecutar Actividad!";
            this.buttonEjecutarActividad.UseVisualStyleBackColor = false;
            this.buttonEjecutarActividad.MouseLeave += new System.EventHandler(this.buttonEjecutarActividad_MouseLeave);
            this.buttonEjecutarActividad.Click += new System.EventHandler(this.buttonEjecutarActividad_Click_1);
            this.buttonEjecutarActividad.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonEjecutarActividad_MouseDown);
            this.buttonEjecutarActividad.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonEjecutarActividad_MouseUp);
            this.buttonEjecutarActividad.EnabledChanged += new System.EventHandler(this.buttonEjecutarActividad_EnabledChanged);
            this.buttonEjecutarActividad.MouseEnter += new System.EventHandler(this.buttonEjecutarActividad_MouseEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 414);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Actividades ejecutadas";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Firebrick;
            this.label3.Location = new System.Drawing.Point(47, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(565, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Estos son las actividades que se pueden ejecutar en este momento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(375, 414);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Actividades por ejecutar, que le faltan requisitos";
            // 
            // dataGridPorEjecutar
            // 
            this.dataGridPorEjecutar.AllowUserToAddRows = false;
            this.dataGridPorEjecutar.AllowUserToDeleteRows = false;
            this.dataGridPorEjecutar.AllowUserToOrderColumns = true;
            this.dataGridPorEjecutar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridPorEjecutar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridPorEjecutar.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridPorEjecutar.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridPorEjecutar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPorEjecutar.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridPorEjecutar.Location = new System.Drawing.Point(342, 442);
            this.dataGridPorEjecutar.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridPorEjecutar.Name = "dataGridPorEjecutar";
            this.dataGridPorEjecutar.ReadOnly = true;
            this.dataGridPorEjecutar.Size = new System.Drawing.Size(287, 110);
            this.dataGridPorEjecutar.TabIndex = 4;
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonCerrar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCerrar.Location = new System.Drawing.Point(282, 365);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(75, 23);
            this.buttonCerrar.TabIndex = 5;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = false;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(80, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(492, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "(Para ejecutar una de ellas, selecciónela y haga click en el botón \"ejecutar acti" +
                "vidad\")";
            // 
            // FormListadoActividad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 564);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridPorEjecutar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridEjecutados);
            this.Controls.Add(this.buttonEjecutarActividad);
            this.Controls.Add(this.dataGridActividad);
            this.Controls.Add(this.labelEncabezadoActividades);
            this.Name = "FormListadoActividad";
            this.Text = "Actividad";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridActividad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEjecutados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPorEjecutar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEncabezadoActividades;
        private System.Windows.Forms.DataGridView dataGridActividad;
        private System.Windows.Forms.Button buttonEjecutarActividad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridEjecutados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridPorEjecutar;
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.Label label5;
    }
}