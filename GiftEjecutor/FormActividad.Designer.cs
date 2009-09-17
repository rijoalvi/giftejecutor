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
            this.labelNombre = new System.Windows.Forms.Label();
            this.dataGridComandos = new System.Windows.Forms.DataGridView();
            this.buttonEjecutarComando = new System.Windows.Forms.Button();
            this.labelDescripción = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.dataGridEjecutados = new System.Windows.Forms.DataGridView();
            this.dataGridNoPosibles = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridComandos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEjecutados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNoPosibles)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(49, 9);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 0;
            this.labelNombre.Text = "Nombre";
            // 
            // dataGridComandos
            // 
            this.dataGridComandos.AllowUserToAddRows = false;
            this.dataGridComandos.AllowUserToDeleteRows = false;
            this.dataGridComandos.AllowUserToOrderColumns = true;
            this.dataGridComandos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridComandos.Location = new System.Drawing.Point(12, 243);
            this.dataGridComandos.Name = "dataGridComandos";
            this.dataGridComandos.ReadOnly = true;
            this.dataGridComandos.Size = new System.Drawing.Size(617, 110);
            this.dataGridComandos.TabIndex = 1;
            this.dataGridComandos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridComandos_CellClick);
            // 
            // buttonEjecutarComando
            // 
            this.buttonEjecutarComando.Enabled = false;
            this.buttonEjecutarComando.Location = new System.Drawing.Point(35, 359);
            this.buttonEjecutarComando.Name = "buttonEjecutarComando";
            this.buttonEjecutarComando.Size = new System.Drawing.Size(119, 23);
            this.buttonEjecutarComando.TabIndex = 2;
            this.buttonEjecutarComando.Text = "EjecutarComando";
            this.buttonEjecutarComando.UseVisualStyleBackColor = true;
            this.buttonEjecutarComando.Click += new System.EventHandler(this.buttonEjecutarComando_Click);
            // 
            // labelDescripción
            // 
            this.labelDescripción.AutoSize = true;
            this.labelDescripción.Location = new System.Drawing.Point(49, 44);
            this.labelDescripción.Name = "labelDescripción";
            this.labelDescripción.Size = new System.Drawing.Size(63, 13);
            this.labelDescripción.TabIndex = 3;
            this.labelDescripción.Text = "Descripción";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(138, 13);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.ReadOnly = true;
            this.textBoxNombre.Size = new System.Drawing.Size(162, 20);
            this.textBoxNombre.TabIndex = 4;
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(138, 44);
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.ReadOnly = true;
            this.textBoxDescripcion.Size = new System.Drawing.Size(162, 20);
            this.textBoxDescripcion.TabIndex = 5;
            // 
            // dataGridEjecutados
            // 
            this.dataGridEjecutados.AllowUserToAddRows = false;
            this.dataGridEjecutados.AllowUserToDeleteRows = false;
            this.dataGridEjecutados.AllowUserToOrderColumns = true;
            this.dataGridEjecutados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEjecutados.Location = new System.Drawing.Point(12, 98);
            this.dataGridEjecutados.Name = "dataGridEjecutados";
            this.dataGridEjecutados.ReadOnly = true;
            this.dataGridEjecutados.Size = new System.Drawing.Size(617, 110);
            this.dataGridEjecutados.TabIndex = 6;
            // 
            // dataGridNoPosibles
            // 
            this.dataGridNoPosibles.AllowUserToAddRows = false;
            this.dataGridNoPosibles.AllowUserToDeleteRows = false;
            this.dataGridNoPosibles.AllowUserToOrderColumns = true;
            this.dataGridNoPosibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridNoPosibles.Location = new System.Drawing.Point(12, 413);
            this.dataGridNoPosibles.Name = "dataGridNoPosibles";
            this.dataGridNoPosibles.ReadOnly = true;
            this.dataGridNoPosibles.Size = new System.Drawing.Size(617, 110);
            this.dataGridNoPosibles.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Comandos ejecutados";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Comandos listos para ejecutar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Comandos por ejecutar, que le faltan requisitos";
            // 
            // FormActividad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 564);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridNoPosibles);
            this.Controls.Add(this.dataGridEjecutados);
            this.Controls.Add(this.textBoxDescripcion);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.labelDescripción);
            this.Controls.Add(this.buttonEjecutarComando);
            this.Controls.Add(this.dataGridComandos);
            this.Controls.Add(this.labelNombre);
            this.Name = "FormActividad";
            this.Text = "Actividad";
            this.Load += new System.EventHandler(this.FormActividad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridComandos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEjecutados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNoPosibles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.DataGridView dataGridComandos;
        private System.Windows.Forms.Button buttonEjecutarComando;
        private System.Windows.Forms.Label labelDescripción;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.DataGridView dataGridEjecutados;
        private System.Windows.Forms.DataGridView dataGridNoPosibles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}