namespace GiftEjecutor
{
    partial class FormDetallesPerfil
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
            this.labelTipo = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxTipo = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColleccionesAsignadas = new System.Windows.Forms.GroupBox();
            this.buttonEliminarPerfil = new System.Windows.Forms.Button();
            this.buttonAgregarPerfil = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.ColleccionesAsignadas.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(48, 49);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 0;
            this.labelNombre.Text = "Nombre";
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Location = new System.Drawing.Point(48, 85);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(28, 13);
            this.labelTipo.TabIndex = 1;
            this.labelTipo.Text = "Tipo";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(120, 49);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.ReadOnly = true;
            this.textBoxNombre.Size = new System.Drawing.Size(100, 20);
            this.textBoxNombre.TabIndex = 2;
            // 
            // textBoxTipo
            // 
            this.textBoxTipo.Location = new System.Drawing.Point(120, 85);
            this.textBoxTipo.Name = "textBoxTipo";
            this.textBoxTipo.ReadOnly = true;
            this.textBoxTipo.Size = new System.Drawing.Size(100, 20);
            this.textBoxTipo.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(465, 150);
            this.dataGridView1.TabIndex = 4;
            // 
            // ColleccionesAsignadas
            // 
            this.ColleccionesAsignadas.Controls.Add(this.buttonEliminarPerfil);
            this.ColleccionesAsignadas.Controls.Add(this.dataGridView1);
            this.ColleccionesAsignadas.Controls.Add(this.buttonAgregarPerfil);
            this.ColleccionesAsignadas.Location = new System.Drawing.Point(41, 123);
            this.ColleccionesAsignadas.Name = "ColleccionesAsignadas";
            this.ColleccionesAsignadas.Size = new System.Drawing.Size(529, 185);
            this.ColleccionesAsignadas.TabIndex = 5;
            this.ColleccionesAsignadas.TabStop = false;
            this.ColleccionesAsignadas.Text = "Collecciones Asignadas";
            // 
            // buttonEliminarPerfil
            // 
            this.buttonEliminarPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminarPerfil.Location = new System.Drawing.Point(488, 56);
            this.buttonEliminarPerfil.Name = "buttonEliminarPerfil";
            this.buttonEliminarPerfil.Size = new System.Drawing.Size(31, 31);
            this.buttonEliminarPerfil.TabIndex = 7;
            this.buttonEliminarPerfil.Text = "-";
            this.buttonEliminarPerfil.UseVisualStyleBackColor = true;
            // 
            // buttonAgregarPerfil
            // 
            this.buttonAgregarPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregarPerfil.Location = new System.Drawing.Point(488, 19);
            this.buttonAgregarPerfil.Name = "buttonAgregarPerfil";
            this.buttonAgregarPerfil.Size = new System.Drawing.Size(31, 31);
            this.buttonAgregarPerfil.TabIndex = 6;
            this.buttonAgregarPerfil.Text = "+";
            this.buttonAgregarPerfil.UseVisualStyleBackColor = true;
            this.buttonAgregarPerfil.Click += new System.EventHandler(this.buttonAgregarPerfil_Click);
            // 
            // FormDetallesPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 332);
            this.Controls.Add(this.ColleccionesAsignadas);
            this.Controls.Add(this.textBoxTipo);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.labelTipo);
            this.Controls.Add(this.labelNombre);
            this.Name = "FormDetallesPerfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalles Perfil";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ColleccionesAsignadas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelTipo;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxTipo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox ColleccionesAsignadas;
        private System.Windows.Forms.Button buttonEliminarPerfil;
        private System.Windows.Forms.Button buttonAgregarPerfil;
    }
}