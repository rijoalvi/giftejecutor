namespace GiftEjecutor
{
    partial class FormGestionUsuarios
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
            this.buttonAgregarPerfil = new System.Windows.Forms.Button();
            this.buttonEliminarPerfil = new System.Windows.Forms.Button();
            this.groupBoxPerfiles = new System.Windows.Forms.GroupBox();
            this.labelIndicacion = new System.Windows.Forms.Label();
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxPerfiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAgregarPerfil
            // 
            this.buttonAgregarPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregarPerfil.Location = new System.Drawing.Point(621, 40);
            this.buttonAgregarPerfil.Name = "buttonAgregarPerfil";
            this.buttonAgregarPerfil.Size = new System.Drawing.Size(19, 19);
            this.buttonAgregarPerfil.TabIndex = 1;
            this.buttonAgregarPerfil.Text = "+";
            this.buttonAgregarPerfil.UseVisualStyleBackColor = true;
            this.buttonAgregarPerfil.Click += new System.EventHandler(this.buttonAgregarPerfil_Click);
            // 
            // buttonEliminarPerfil
            // 
            this.buttonEliminarPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminarPerfil.Location = new System.Drawing.Point(621, 61);
            this.buttonEliminarPerfil.Name = "buttonEliminarPerfil";
            this.buttonEliminarPerfil.Size = new System.Drawing.Size(19, 19);
            this.buttonEliminarPerfil.TabIndex = 2;
            this.buttonEliminarPerfil.Text = "-";
            this.buttonEliminarPerfil.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonEliminarPerfil.UseVisualStyleBackColor = true;
            this.buttonEliminarPerfil.Click += new System.EventHandler(this.buttonEliminarPerfil_Click);
            // 
            // groupBoxPerfiles
            // 
            this.groupBoxPerfiles.Controls.Add(this.labelIndicacion);
            this.groupBoxPerfiles.Controls.Add(this.dataGridViewUsuarios);
            this.groupBoxPerfiles.Controls.Add(this.buttonEliminarPerfil);
            this.groupBoxPerfiles.Controls.Add(this.buttonAgregarPerfil);
            this.groupBoxPerfiles.Location = new System.Drawing.Point(9, 7);
            this.groupBoxPerfiles.Name = "groupBoxPerfiles";
            this.groupBoxPerfiles.Size = new System.Drawing.Size(646, 293);
            this.groupBoxPerfiles.TabIndex = 3;
            this.groupBoxPerfiles.TabStop = false;
            this.groupBoxPerfiles.Text = "Usuarios";
            // 
            // labelIndicacion
            // 
            this.labelIndicacion.AutoSize = true;
            this.labelIndicacion.ForeColor = System.Drawing.Color.DarkRed;
            this.labelIndicacion.Location = new System.Drawing.Point(19, 264);
            this.labelIndicacion.Name = "labelIndicacion";
            this.labelIndicacion.Size = new System.Drawing.Size(466, 13);
            this.labelIndicacion.TabIndex = 3;
            this.labelIndicacion.Text = "Para ver los datos detallados de un usuario o editarlos, haga doble click sobre e" +
                "l usuario deseado";
            // 
            // dataGridViewUsuarios
            // 
            this.dataGridViewUsuarios.AllowUserToAddRows = false;
            this.dataGridViewUsuarios.AllowUserToDeleteRows = false;
            this.dataGridViewUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUsuarios.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuarios.Location = new System.Drawing.Point(22, 19);
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.ReadOnly = true;
            this.dataGridViewUsuarios.Size = new System.Drawing.Size(593, 242);
            this.dataGridViewUsuarios.TabIndex = 0;
            this.dataGridViewUsuarios.DoubleClick += new System.EventHandler(this.dataGridViewUsuarios_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(582, 304);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormGestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 339);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxPerfiles);
            this.Name = "FormGestionUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Usuarios";
            this.Load += new System.EventHandler(this.GestionUsuarios_Load);
            this.groupBoxPerfiles.ResumeLayout(false);
            this.groupBoxPerfiles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAgregarPerfil;
        private System.Windows.Forms.Button buttonEliminarPerfil;
        private System.Windows.Forms.GroupBox groupBoxPerfiles;
        private System.Windows.Forms.DataGridView dataGridViewUsuarios;
        private System.Windows.Forms.Label labelIndicacion;
        private System.Windows.Forms.Button button1;
    }
}