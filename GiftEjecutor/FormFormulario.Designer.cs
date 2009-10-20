namespace GiftEjecutor
{
    partial class FormFormulario
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
            this.botonAceptar = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.buttonNuevoDetalle = new System.Windows.Forms.Button();
            this.buttonVerDetalle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonAceptar
            // 
            this.botonAceptar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAceptar.ForeColor = System.Drawing.Color.DarkGreen;
            this.botonAceptar.Location = new System.Drawing.Point(377, 602);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(75, 23);
            this.botonAceptar.TabIndex = 0;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
            // 
            // botonCancelar
            // 
            this.botonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonCancelar.ForeColor = System.Drawing.Color.Firebrick;
            this.botonCancelar.Location = new System.Drawing.Point(470, 602);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(75, 23);
            this.botonCancelar.TabIndex = 1;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // buttonNuevoDetalle
            // 
            this.buttonNuevoDetalle.Enabled = false;
            this.buttonNuevoDetalle.Location = new System.Drawing.Point(74, 576);
            this.buttonNuevoDetalle.Name = "buttonNuevoDetalle";
            this.buttonNuevoDetalle.Size = new System.Drawing.Size(225, 23);
            this.buttonNuevoDetalle.TabIndex = 2;
            this.buttonNuevoDetalle.Text = "Nuevo detalle";
            this.buttonNuevoDetalle.UseVisualStyleBackColor = true;
            this.buttonNuevoDetalle.Click += new System.EventHandler(this.buttonNuevoDetalle_Click);
            // 
            // buttonVerDetalle
            // 
            this.buttonVerDetalle.Enabled = false;
            this.buttonVerDetalle.Location = new System.Drawing.Point(74, 602);
            this.buttonVerDetalle.Name = "buttonVerDetalle";
            this.buttonVerDetalle.Size = new System.Drawing.Size(225, 23);
            this.buttonVerDetalle.TabIndex = 3;
            this.buttonVerDetalle.Text = "Ver Detalle";
            this.buttonVerDetalle.UseVisualStyleBackColor = true;
            this.buttonVerDetalle.Click += new System.EventHandler(this.buttonVerDetalle_Click);
            // 
            // FormFormulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 647);
            this.Controls.Add(this.buttonVerDetalle);
            this.Controls.Add(this.buttonNuevoDetalle);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonAceptar);
            this.Name = "FormFormulario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormFormulario";
            this.Load += new System.EventHandler(this.FormFormulario_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Button buttonNuevoDetalle;
        private System.Windows.Forms.Button buttonVerDetalle;

    }
}