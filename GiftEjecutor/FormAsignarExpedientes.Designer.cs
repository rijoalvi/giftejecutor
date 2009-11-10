namespace GiftEjecutor
{
    partial class FormAsignarExpedientes
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
            this.comboUsuarios = new System.Windows.Forms.ComboBox();
            this.comboExpedientes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.botonAgregar = new System.Windows.Forms.Button();
            this.botonCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione el usuario al cual desea asignarle algun expediente:";
            // 
            // comboUsuarios
            // 
            this.comboUsuarios.FormattingEnabled = true;
            this.comboUsuarios.Location = new System.Drawing.Point(26, 76);
            this.comboUsuarios.Name = "comboUsuarios";
            this.comboUsuarios.Size = new System.Drawing.Size(121, 21);
            this.comboUsuarios.TabIndex = 1;
            this.comboUsuarios.SelectedIndexChanged += new System.EventHandler(this.comboUsuarios_SelectedIndexChanged);
            // 
            // comboExpedientes
            // 
            this.comboExpedientes.FormattingEnabled = true;
            this.comboExpedientes.Location = new System.Drawing.Point(26, 166);
            this.comboExpedientes.Name = "comboExpedientes";
            this.comboExpedientes.Size = new System.Drawing.Size(121, 21);
            this.comboExpedientes.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccione el expediente que desea asignarle:";
            // 
            // botonAgregar
            // 
            this.botonAgregar.Location = new System.Drawing.Point(162, 222);
            this.botonAgregar.Name = "botonAgregar";
            this.botonAgregar.Size = new System.Drawing.Size(75, 23);
            this.botonAgregar.TabIndex = 4;
            this.botonAgregar.Text = "Agregar";
            this.botonAgregar.UseVisualStyleBackColor = true;
            this.botonAgregar.Click += new System.EventHandler(this.botonAgregar_Click);
            // 
            // botonCerrar
            // 
            this.botonCerrar.Location = new System.Drawing.Point(254, 222);
            this.botonCerrar.Name = "botonCerrar";
            this.botonCerrar.Size = new System.Drawing.Size(75, 23);
            this.botonCerrar.TabIndex = 5;
            this.botonCerrar.Text = "Cerrar";
            this.botonCerrar.UseVisualStyleBackColor = true;
            this.botonCerrar.Click += new System.EventHandler(this.botonCerrar_Click);
            // 
            // FormAsignarExpedientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 283);
            this.Controls.Add(this.botonCerrar);
            this.Controls.Add(this.botonAgregar);
            this.Controls.Add(this.comboExpedientes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboUsuarios);
            this.Controls.Add(this.label1);
            this.Name = "FormAsignarExpedientes";
            this.Text = "Asignación de Expedientes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboUsuarios;
        private System.Windows.Forms.ComboBox comboExpedientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button botonAgregar;
        private System.Windows.Forms.Button botonCerrar;
    }
}