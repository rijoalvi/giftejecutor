namespace GiftEjecutor
{
    partial class NuevoPerfil
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.textBoxNombrePerfil = new System.Windows.Forms.TextBox();
            this.textBoxTipoPerfil = new System.Windows.Forms.TextBox();
            this.labelNombrePerfil = new System.Windows.Forms.Label();
            this.labelTipoPerfil = new System.Windows.Forms.Label();
            this.groupBoxNuevoPerfil = new System.Windows.Forms.GroupBox();
            this.groupBoxNuevoPerfil.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(307, 225);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(212, 225);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 3;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // textBoxNombrePerfil
            // 
            this.textBoxNombrePerfil.Location = new System.Drawing.Point(128, 34);
            this.textBoxNombrePerfil.Name = "textBoxNombrePerfil";
            this.textBoxNombrePerfil.Size = new System.Drawing.Size(149, 20);
            this.textBoxNombrePerfil.TabIndex = 0;
            // 
            // textBoxTipoPerfil
            // 
            this.textBoxTipoPerfil.Location = new System.Drawing.Point(128, 73);
            this.textBoxTipoPerfil.Name = "textBoxTipoPerfil";
            this.textBoxTipoPerfil.Size = new System.Drawing.Size(149, 20);
            this.textBoxTipoPerfil.TabIndex = 1;
            // 
            // labelNombrePerfil
            // 
            this.labelNombrePerfil.AutoSize = true;
            this.labelNombrePerfil.Location = new System.Drawing.Point(14, 34);
            this.labelNombrePerfil.Name = "labelNombrePerfil";
            this.labelNombrePerfil.Size = new System.Drawing.Size(44, 13);
            this.labelNombrePerfil.TabIndex = 4;
            this.labelNombrePerfil.Text = "Nombre";
            // 
            // labelTipoPerfil
            // 
            this.labelTipoPerfil.AutoSize = true;
            this.labelTipoPerfil.Location = new System.Drawing.Point(14, 73);
            this.labelTipoPerfil.Name = "labelTipoPerfil";
            this.labelTipoPerfil.Size = new System.Drawing.Size(28, 13);
            this.labelTipoPerfil.TabIndex = 5;
            this.labelTipoPerfil.Text = "Tipo";
            // 
            // groupBoxNuevoPerfil
            // 
            this.groupBoxNuevoPerfil.Controls.Add(this.textBoxNombrePerfil);
            this.groupBoxNuevoPerfil.Controls.Add(this.labelTipoPerfil);
            this.groupBoxNuevoPerfil.Controls.Add(this.textBoxTipoPerfil);
            this.groupBoxNuevoPerfil.Controls.Add(this.labelNombrePerfil);
            this.groupBoxNuevoPerfil.Location = new System.Drawing.Point(30, 43);
            this.groupBoxNuevoPerfil.Name = "groupBoxNuevoPerfil";
            this.groupBoxNuevoPerfil.Size = new System.Drawing.Size(352, 139);
            this.groupBoxNuevoPerfil.TabIndex = 6;
            this.groupBoxNuevoPerfil.TabStop = false;
            this.groupBoxNuevoPerfil.Text = "Nuevo Perfil";
            // 
            // NuevoPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 309);
            this.Controls.Add(this.groupBoxNuevoPerfil);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonOK);
            this.Name = "NuevoPerfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Perfil";
            this.Load += new System.EventHandler(this.NuevoPerfil_Load);
            this.groupBoxNuevoPerfil.ResumeLayout(false);
            this.groupBoxNuevoPerfil.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.TextBox textBoxNombrePerfil;
        private System.Windows.Forms.TextBox textBoxTipoPerfil;
        private System.Windows.Forms.Label labelNombrePerfil;
        private System.Windows.Forms.Label labelTipoPerfil;
        private System.Windows.Forms.GroupBox groupBoxNuevoPerfil;
    }
}