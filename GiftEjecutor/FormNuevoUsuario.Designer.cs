namespace GiftEjecutor
{
    partial class FormNuevoUsuario
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
            this.textBoxNombreUsuario = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.groupBoxDatosUsuario = new System.Windows.Forms.GroupBox();
            this.labelRespuesta = new System.Windows.Forms.Label();
            this.textBoxRespuesta = new System.Windows.Forms.TextBox();
            this.labelPreguntaSecreta = new System.Windows.Forms.Label();
            this.textBoxPreguntaSecreta = new System.Windows.Forms.TextBox();
            this.labelConfirmaContrasena = new System.Windows.Forms.Label();
            this.textBoxConfirmaContrasena = new System.Windows.Forms.TextBox();
            this.labelContrasena = new System.Windows.Forms.Label();
            this.textBoxContrasena = new System.Windows.Forms.TextBox();
            this.labelNombreUsuario = new System.Windows.Forms.Label();
            this.labelNombrePerfil = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.comboPerfiles = new System.Windows.Forms.ComboBox();
            this.groupBoxDatosUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxNombreUsuario
            // 
            this.textBoxNombreUsuario.Location = new System.Drawing.Point(157, 19);
            this.textBoxNombreUsuario.Name = "textBoxNombreUsuario";
            this.textBoxNombreUsuario.Size = new System.Drawing.Size(130, 20);
            this.textBoxNombreUsuario.TabIndex = 8;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(113, 284);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 10;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // groupBoxDatosUsuario
            // 
            this.groupBoxDatosUsuario.Controls.Add(this.labelRespuesta);
            this.groupBoxDatosUsuario.Controls.Add(this.textBoxRespuesta);
            this.groupBoxDatosUsuario.Controls.Add(this.labelPreguntaSecreta);
            this.groupBoxDatosUsuario.Controls.Add(this.textBoxPreguntaSecreta);
            this.groupBoxDatosUsuario.Controls.Add(this.labelConfirmaContrasena);
            this.groupBoxDatosUsuario.Controls.Add(this.textBoxConfirmaContrasena);
            this.groupBoxDatosUsuario.Controls.Add(this.labelContrasena);
            this.groupBoxDatosUsuario.Controls.Add(this.textBoxContrasena);
            this.groupBoxDatosUsuario.Controls.Add(this.labelNombreUsuario);
            this.groupBoxDatosUsuario.Controls.Add(this.textBoxNombreUsuario);
            this.groupBoxDatosUsuario.Location = new System.Drawing.Point(7, 86);
            this.groupBoxDatosUsuario.Name = "groupBoxDatosUsuario";
            this.groupBoxDatosUsuario.Size = new System.Drawing.Size(317, 192);
            this.groupBoxDatosUsuario.TabIndex = 12;
            this.groupBoxDatosUsuario.TabStop = false;
            this.groupBoxDatosUsuario.Text = "Datos del Usuario";
            // 
            // labelRespuesta
            // 
            this.labelRespuesta.AutoSize = true;
            this.labelRespuesta.Location = new System.Drawing.Point(16, 126);
            this.labelRespuesta.Name = "labelRespuesta";
            this.labelRespuesta.Size = new System.Drawing.Size(58, 13);
            this.labelRespuesta.TabIndex = 21;
            this.labelRespuesta.Text = "Respuesta";
            // 
            // textBoxRespuesta
            // 
            this.textBoxRespuesta.Location = new System.Drawing.Point(157, 123);
            this.textBoxRespuesta.Name = "textBoxRespuesta";
            this.textBoxRespuesta.Size = new System.Drawing.Size(130, 20);
            this.textBoxRespuesta.TabIndex = 20;
            // 
            // labelPreguntaSecreta
            // 
            this.labelPreguntaSecreta.AutoSize = true;
            this.labelPreguntaSecreta.Location = new System.Drawing.Point(16, 100);
            this.labelPreguntaSecreta.Name = "labelPreguntaSecreta";
            this.labelPreguntaSecreta.Size = new System.Drawing.Size(90, 13);
            this.labelPreguntaSecreta.TabIndex = 19;
            this.labelPreguntaSecreta.Text = "Pregunta Secreta";
            // 
            // textBoxPreguntaSecreta
            // 
            this.textBoxPreguntaSecreta.Location = new System.Drawing.Point(157, 97);
            this.textBoxPreguntaSecreta.Name = "textBoxPreguntaSecreta";
            this.textBoxPreguntaSecreta.Size = new System.Drawing.Size(130, 20);
            this.textBoxPreguntaSecreta.TabIndex = 18;
            // 
            // labelConfirmaContrasena
            // 
            this.labelConfirmaContrasena.AutoSize = true;
            this.labelConfirmaContrasena.Location = new System.Drawing.Point(16, 74);
            this.labelConfirmaContrasena.Name = "labelConfirmaContrasena";
            this.labelConfirmaContrasena.Size = new System.Drawing.Size(140, 13);
            this.labelConfirmaContrasena.TabIndex = 17;
            this.labelConfirmaContrasena.Text = "Confirmacion de Contraseña";
            // 
            // textBoxConfirmaContrasena
            // 
            this.textBoxConfirmaContrasena.Location = new System.Drawing.Point(157, 71);
            this.textBoxConfirmaContrasena.Name = "textBoxConfirmaContrasena";
            this.textBoxConfirmaContrasena.Size = new System.Drawing.Size(130, 20);
            this.textBoxConfirmaContrasena.TabIndex = 16;
            this.textBoxConfirmaContrasena.UseSystemPasswordChar = true;
            // 
            // labelContrasena
            // 
            this.labelContrasena.AutoSize = true;
            this.labelContrasena.Location = new System.Drawing.Point(16, 48);
            this.labelContrasena.Name = "labelContrasena";
            this.labelContrasena.Size = new System.Drawing.Size(61, 13);
            this.labelContrasena.TabIndex = 15;
            this.labelContrasena.Text = "Contraseña";
            // 
            // textBoxContrasena
            // 
            this.textBoxContrasena.Location = new System.Drawing.Point(157, 45);
            this.textBoxContrasena.Name = "textBoxContrasena";
            this.textBoxContrasena.Size = new System.Drawing.Size(130, 20);
            this.textBoxContrasena.TabIndex = 14;
            this.textBoxContrasena.UseSystemPasswordChar = true;
            // 
            // labelNombreUsuario
            // 
            this.labelNombreUsuario.AutoSize = true;
            this.labelNombreUsuario.Location = new System.Drawing.Point(16, 22);
            this.labelNombreUsuario.Name = "labelNombreUsuario";
            this.labelNombreUsuario.Size = new System.Drawing.Size(98, 13);
            this.labelNombreUsuario.TabIndex = 13;
            this.labelNombreUsuario.Text = "Nombre de Usuario";
            // 
            // labelNombrePerfil
            // 
            this.labelNombrePerfil.AutoSize = true;
            this.labelNombrePerfil.Location = new System.Drawing.Point(23, 36);
            this.labelNombrePerfil.Name = "labelNombrePerfil";
            this.labelNombrePerfil.Size = new System.Drawing.Size(86, 13);
            this.labelNombrePerfil.TabIndex = 11;
            this.labelNombrePerfil.Text = "Perfil del Usuario";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(194, 284);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // comboPerfiles
            // 
            this.comboPerfiles.FormattingEnabled = true;
            this.comboPerfiles.Location = new System.Drawing.Point(173, 33);
            this.comboPerfiles.Name = "comboPerfiles";
            this.comboPerfiles.Size = new System.Drawing.Size(121, 21);
            this.comboPerfiles.TabIndex = 13;
            // 
            // FormNuevoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 343);
            this.Controls.Add(this.comboPerfiles);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.groupBoxDatosUsuario);
            this.Controls.Add(this.labelNombrePerfil);
            this.Controls.Add(this.buttonOK);
            this.Name = "FormNuevoUsuario";
            this.Text = "FormNuevoUsuario";
            this.groupBoxDatosUsuario.ResumeLayout(false);
            this.groupBoxDatosUsuario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNombreUsuario;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.GroupBox groupBoxDatosUsuario;
        private System.Windows.Forms.Label labelNombrePerfil;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelPreguntaSecreta;
        private System.Windows.Forms.TextBox textBoxPreguntaSecreta;
        private System.Windows.Forms.Label labelConfirmaContrasena;
        private System.Windows.Forms.TextBox textBoxConfirmaContrasena;
        private System.Windows.Forms.Label labelContrasena;
        private System.Windows.Forms.TextBox textBoxContrasena;
        private System.Windows.Forms.Label labelNombreUsuario;
        private System.Windows.Forms.Label labelRespuesta;
        private System.Windows.Forms.TextBox textBoxRespuesta;
        private System.Windows.Forms.ComboBox comboPerfiles;
    }
}