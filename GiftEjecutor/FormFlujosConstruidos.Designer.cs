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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(4, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flujo de trabajo al que pertenecerá el expediente a crear:";
            // 
            // dataGridFlujos
            // 
            this.dataGridFlujos.AllowUserToAddRows = false;
            this.dataGridFlujos.AllowUserToDeleteRows = false;
            this.dataGridFlujos.AllowUserToOrderColumns = true;
            this.dataGridFlujos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridFlujos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridFlujos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridFlujos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridFlujos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFlujos.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridFlujos.Location = new System.Drawing.Point(27, 80);
            this.dataGridFlujos.Name = "dataGridFlujos";
            this.dataGridFlujos.ReadOnly = true;
            this.dataGridFlujos.Size = new System.Drawing.Size(371, 80);
            this.dataGridFlujos.TabIndex = 1;
            this.dataGridFlujos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridFlujos_CellContentClick);
            // 
            // botonCrearExpediente
            // 
            this.botonCrearExpediente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonCrearExpediente.ForeColor = System.Drawing.Color.DarkGreen;
            this.botonCrearExpediente.Location = new System.Drawing.Point(235, 254);
            this.botonCrearExpediente.Name = "botonCrearExpediente";
            this.botonCrearExpediente.Size = new System.Drawing.Size(75, 23);
            this.botonCrearExpediente.TabIndex = 2;
            this.botonCrearExpediente.Text = "Aceptar";
            this.botonCrearExpediente.UseVisualStyleBackColor = true;
            this.botonCrearExpediente.Click += new System.EventHandler(this.botonCrearExpediente_Click);
            // 
            // botonCancelar
            // 
            this.botonCancelar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonCancelar.ForeColor = System.Drawing.Color.Firebrick;
            this.botonCancelar.Location = new System.Drawing.Point(325, 254);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(75, 23);
            this.botonCancelar.TabIndex = 3;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(27, 213);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(269, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(24, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Digite el nombre del nuevo expediente";
            // 
            // FormFlujosConstruidos
            // 
            this.AcceptButton = this.botonCrearExpediente;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 295);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonCrearExpediente);
            this.Controls.Add(this.dataGridFlujos);
            this.Controls.Add(this.label1);
            this.Name = "FormFlujosConstruidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
    }
}