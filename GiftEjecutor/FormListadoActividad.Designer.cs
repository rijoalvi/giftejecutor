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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridActividad = new System.Windows.Forms.DataGridView();
            this.buttonEjecutarActividad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridActividad)).BeginInit();
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
            // dataGridActividad
            // 
            this.dataGridActividad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridActividad.Location = new System.Drawing.Point(12, 85);
            this.dataGridActividad.Name = "dataGridActividad";
            this.dataGridActividad.Size = new System.Drawing.Size(617, 150);
            this.dataGridActividad.TabIndex = 1;
            this.dataGridActividad.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridActividad_CellClick_1);
            // 
            // buttonEjecutarActividad
            // 
            this.buttonEjecutarActividad.Enabled = false;
            this.buttonEjecutarActividad.Location = new System.Drawing.Point(121, 254);
            this.buttonEjecutarActividad.Name = "buttonEjecutarActividad";
            this.buttonEjecutarActividad.Size = new System.Drawing.Size(119, 23);
            this.buttonEjecutarActividad.TabIndex = 2;
            this.buttonEjecutarActividad.Text = "EjecutarActividad";
            this.buttonEjecutarActividad.UseVisualStyleBackColor = true;
            this.buttonEjecutarActividad.Click += new System.EventHandler(this.buttonEjecutarActividad_Click_1);
            // 
            // FormListadoActividad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 298);
            this.Controls.Add(this.buttonEjecutarActividad);
            this.Controls.Add(this.dataGridActividad);
            this.Controls.Add(this.label1);
            this.Name = "FormListadoActividad";
            this.Text = "Actividad";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridActividad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridActividad;
        private System.Windows.Forms.Button buttonEjecutarActividad;
    }
}