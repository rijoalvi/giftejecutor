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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridComandos = new System.Windows.Forms.DataGridView();
            this.buttonEjecutarComando = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridComandos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // dataGridComandos
            // 
            this.dataGridComandos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridComandos.Location = new System.Drawing.Point(12, 85);
            this.dataGridComandos.Name = "dataGridComandos";
            this.dataGridComandos.Size = new System.Drawing.Size(617, 150);
            this.dataGridComandos.TabIndex = 1;
            this.dataGridComandos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridComandos_CellClick);
            // 
            // buttonEjecutarComando
            // 
            this.buttonEjecutarComando.Enabled = false;
            this.buttonEjecutarComando.Location = new System.Drawing.Point(121, 254);
            this.buttonEjecutarComando.Name = "buttonEjecutarComando";
            this.buttonEjecutarComando.Size = new System.Drawing.Size(119, 23);
            this.buttonEjecutarComando.TabIndex = 2;
            this.buttonEjecutarComando.Text = "EjecutarComando";
            this.buttonEjecutarComando.UseVisualStyleBackColor = true;
            this.buttonEjecutarComando.Click += new System.EventHandler(this.buttonEjecutarComando_Click);
            // 
            // FormActividad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 298);
            this.Controls.Add(this.buttonEjecutarComando);
            this.Controls.Add(this.dataGridComandos);
            this.Controls.Add(this.label1);
            this.Name = "FormActividad";
            this.Text = "Actividad";
            this.Load += new System.EventHandler(this.FormActividad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridComandos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridComandos;
        private System.Windows.Forms.Button buttonEjecutarComando;
    }
}