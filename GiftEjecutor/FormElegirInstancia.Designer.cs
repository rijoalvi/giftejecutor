namespace GiftEjecutor
{
    partial class FormElegirInstancia
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
            this.dataGridInstancias = new System.Windows.Forms.DataGridView();
            this.botonEjecutar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInstancias)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridInstancias
            // 
            this.dataGridInstancias.AllowUserToAddRows = false;
            this.dataGridInstancias.AllowUserToDeleteRows = false;
            this.dataGridInstancias.AllowUserToOrderColumns = true;
            this.dataGridInstancias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInstancias.Location = new System.Drawing.Point(12, 63);
            this.dataGridInstancias.Name = "dataGridInstancias";
            this.dataGridInstancias.ReadOnly = true;
            this.dataGridInstancias.Size = new System.Drawing.Size(282, 135);
            this.dataGridInstancias.TabIndex = 0;
            // 
            // botonEjecutar
            // 
            this.botonEjecutar.Location = new System.Drawing.Point(129, 219);
            this.botonEjecutar.Name = "botonEjecutar";
            this.botonEjecutar.Size = new System.Drawing.Size(75, 23);
            this.botonEjecutar.TabIndex = 1;
            this.botonEjecutar.Text = "Ejecutar";
            this.botonEjecutar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Favor elegir la instancia del formulario a la cual desea";
            // 
            // botonCancelar
            // 
            this.botonCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.botonCancelar.Location = new System.Drawing.Point(219, 219);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(75, 23);
            this.botonCancelar.TabIndex = 3;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "ejecutarle el comando";
            // 
            // FormElegirInstancia
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "FormElegirInstancia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInstancias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridInstancias;
        private System.Windows.Forms.Button botonEjecutar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Label label2;
    }
}