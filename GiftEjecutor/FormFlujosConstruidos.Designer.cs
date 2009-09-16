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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFlujos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flujos Construidos:";
            // 
            // dataGridFlujos
            // 
            this.dataGridFlujos.AllowUserToAddRows = false;
            this.dataGridFlujos.AllowUserToDeleteRows = false;
            this.dataGridFlujos.AllowUserToOrderColumns = true;
            this.dataGridFlujos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFlujos.Location = new System.Drawing.Point(15, 48);
            this.dataGridFlujos.Name = "dataGridFlujos";
            this.dataGridFlujos.ReadOnly = true;
            this.dataGridFlujos.Size = new System.Drawing.Size(449, 150);
            this.dataGridFlujos.TabIndex = 1;
            this.dataGridFlujos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridFlujos_CellContentClick);
            // 
            // botonCrearExpediente
            // 
            this.botonCrearExpediente.Location = new System.Drawing.Point(299, 220);
            this.botonCrearExpediente.Name = "botonCrearExpediente";
            this.botonCrearExpediente.Size = new System.Drawing.Size(75, 23);
            this.botonCrearExpediente.TabIndex = 2;
            this.botonCrearExpediente.Text = "Crear";
            this.botonCrearExpediente.UseVisualStyleBackColor = true;
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(389, 220);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(75, 23);
            this.botonCancelar.TabIndex = 3;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // FormFlujosConstruidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 264);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonCrearExpediente);
            this.Controls.Add(this.dataGridFlujos);
            this.Controls.Add(this.label1);
            this.Name = "FormFlujosConstruidos";
            this.Text = "Crear Nuevo Expediente";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFlujos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridFlujos;
        private System.Windows.Forms.Button botonCrearExpediente;
        private System.Windows.Forms.Button botonCancelar;
    }
}