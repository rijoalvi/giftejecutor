namespace GiftEjecutor
{
    partial class FormVistaBitacora
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
            this.dataGridElementosBitacora = new System.Windows.Forms.DataGridView();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.labelEncabezadoBitacora = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridElementosBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridElementosBitacora
            // 
            this.dataGridElementosBitacora.AllowUserToOrderColumns = true;
            this.dataGridElementosBitacora.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridElementosBitacora.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridElementosBitacora.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridElementosBitacora.BackgroundColor = System.Drawing.Color.White;
            this.dataGridElementosBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridElementosBitacora.Location = new System.Drawing.Point(12, 52);
            this.dataGridElementosBitacora.Name = "dataGridElementosBitacora";
            this.dataGridElementosBitacora.Size = new System.Drawing.Size(843, 528);
            this.dataGridElementosBitacora.TabIndex = 0;
            // 
            // botonAceptar
            // 
            this.botonAceptar.Location = new System.Drawing.Point(779, 593);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(75, 23);
            this.botonAceptar.TabIndex = 1;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
            // 
            // labelEncabezadoBitacora
            // 
            this.labelEncabezadoBitacora.AutoSize = true;
            this.labelEncabezadoBitacora.Font = new System.Drawing.Font("Verdana", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEncabezadoBitacora.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelEncabezadoBitacora.Location = new System.Drawing.Point(12, 9);
            this.labelEncabezadoBitacora.Name = "labelEncabezadoBitacora";
            this.labelEncabezadoBitacora.Size = new System.Drawing.Size(309, 26);
            this.labelEncabezadoBitacora.TabIndex = 2;
            this.labelEncabezadoBitacora.Text = "Bitácora del Expediente";
            // 
            // FormVistaBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 628);
            this.Controls.Add(this.labelEncabezadoBitacora);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.dataGridElementosBitacora);
            this.Name = "FormVistaBitacora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bitácora";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridElementosBitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridElementosBitacora;
        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Label labelEncabezadoBitacora;
    }
}