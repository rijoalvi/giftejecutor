namespace GiftEjecutor
{
    partial class FormFlujosConstruidos
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridFlujos = new System.Windows.Forms.DataGridView();
            this.botonCrearExpediente = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFlujos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flujo de trabajo al que pertenecerá el expediente a crear";
            // 
            // dataGridFlujos
            // 
            this.dataGridFlujos.AllowUserToAddRows = false;
            this.dataGridFlujos.AllowUserToDeleteRows = false;
            this.dataGridFlujos.AllowUserToOrderColumns = true;
            this.dataGridFlujos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridFlujos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridFlujos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFlujos.Location = new System.Drawing.Point(27, 80);
            this.dataGridFlujos.Name = "dataGridFlujos";
            this.dataGridFlujos.ReadOnly = true;
            this.dataGridFlujos.Size = new System.Drawing.Size(371, 43);
            this.dataGridFlujos.TabIndex = 1;
            // 
            // botonCrearExpediente
            // 
            this.botonCrearExpediente.Location = new System.Drawing.Point(233, 234);
            this.botonCrearExpediente.Name = "botonCrearExpediente";
            this.botonCrearExpediente.Size = new System.Drawing.Size(75, 23);
            this.botonCrearExpediente.TabIndex = 2;
            this.botonCrearExpediente.Text = "Aceptar";
            this.botonCrearExpediente.UseVisualStyleBackColor = true;
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(323, 234);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(75, 23);
            this.botonCancelar.TabIndex = 3;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(25, 193);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(269, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Digite el nombre del nuevo expediente";
            // 
            // FormFlujosConstruidos
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "FormFlujosConstruidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFlujos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridFlujos;
        private System.Windows.Forms.Button botonCrearExpediente;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
    }
}