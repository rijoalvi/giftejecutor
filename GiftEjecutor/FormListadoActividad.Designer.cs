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
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridEjecutados = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridPorEjecutar = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridActividad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEjecutados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPorEjecutar)).BeginInit();
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
            this.dataGridActividad.Location = new System.Drawing.Point(12, 215);
            this.dataGridActividad.Name = "dataGridActividad";
            this.dataGridActividad.Size = new System.Drawing.Size(518, 110);
            this.dataGridActividad.TabIndex = 1;
            this.dataGridActividad.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridActividad_CellClick_1);
            // 
            // buttonEjecutarActividad
            // 
            this.buttonEjecutarActividad.Enabled = false;
            this.buttonEjecutarActividad.Location = new System.Drawing.Point(12, 331);
            this.buttonEjecutarActividad.Name = "buttonEjecutarActividad";
            this.buttonEjecutarActividad.Size = new System.Drawing.Size(119, 23);
            this.buttonEjecutarActividad.TabIndex = 2;
            this.buttonEjecutarActividad.Text = "EjecutarActividad";
            this.buttonEjecutarActividad.UseVisualStyleBackColor = true;
            this.buttonEjecutarActividad.Click += new System.EventHandler(this.buttonEjecutarActividad_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Actividades ejecutadas";
            // 
            // dataGridEjecutados
            // 
            this.dataGridEjecutados.AllowUserToAddRows = false;
            this.dataGridEjecutados.AllowUserToDeleteRows = false;
            this.dataGridEjecutados.AllowUserToOrderColumns = true;
            this.dataGridEjecutados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEjecutados.Location = new System.Drawing.Point(12, 72);
            this.dataGridEjecutados.Name = "dataGridEjecutados";
            this.dataGridEjecutados.ReadOnly = true;
            this.dataGridEjecutados.Size = new System.Drawing.Size(515, 110);
            this.dataGridEjecutados.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Actividades listas para ejecutar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 382);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Actividades por ejecutar, que le faltan requisitos";
            // 
            // dataGridPorEjecutar
            // 
            this.dataGridPorEjecutar.AllowUserToAddRows = false;
            this.dataGridPorEjecutar.AllowUserToDeleteRows = false;
            this.dataGridPorEjecutar.AllowUserToOrderColumns = true;
            this.dataGridPorEjecutar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPorEjecutar.Location = new System.Drawing.Point(12, 398);
            this.dataGridPorEjecutar.Name = "dataGridPorEjecutar";
            this.dataGridPorEjecutar.ReadOnly = true;
            this.dataGridPorEjecutar.Size = new System.Drawing.Size(515, 110);
            this.dataGridPorEjecutar.TabIndex = 12;
            // 
            // FormListadoActividad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 530);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridPorEjecutar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridEjecutados);
            this.Controls.Add(this.buttonEjecutarActividad);
            this.Controls.Add(this.dataGridActividad);
            this.Controls.Add(this.label1);
            this.Name = "FormListadoActividad";
            this.Text = "Actividad";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridActividad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEjecutados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPorEjecutar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridActividad;
        private System.Windows.Forms.Button buttonEjecutarActividad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridEjecutados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridPorEjecutar;
    }
}