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
            this.ColleccionesAsignadas = new System.Windows.Forms.GroupBox();
            this.buttonEliminarPerfil = new System.Windows.Forms.Button();
            this.tabColecciones = new System.Windows.Forms.TabControl();
            this.comboBoxFlujoTrabajo = new System.Windows.Forms.ComboBox();
            this.labelFlujo = new System.Windows.Forms.Label();
            this.comboBoxColecciones = new System.Windows.Forms.ComboBox();
            this.groupBoxAsignarColecciones = new System.Windows.Forms.GroupBox();
            this.buttonAsignarColeccion = new System.Windows.Forms.Button();
            this.labelMensaje = new System.Windows.Forms.Label();
            this.ColleccionesAsignadas.SuspendLayout();
            this.groupBoxAsignarColecciones.SuspendLayout();
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
            this.labelTipo.Location = new System.Drawing.Point(48, 75);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(28, 13);
            this.labelTipo.TabIndex = 1;
            this.labelTipo.Text = "Tipo";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(138, 49);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.ReadOnly = true;
            this.textBoxNombre.Size = new System.Drawing.Size(121, 20);
            this.textBoxNombre.TabIndex = 2;
            // 
            // textBoxTipo
            // 
            this.textBoxTipo.Location = new System.Drawing.Point(138, 75);
            this.textBoxTipo.Name = "textBoxTipo";
            this.textBoxTipo.ReadOnly = true;
            this.textBoxTipo.Size = new System.Drawing.Size(121, 20);
            this.textBoxTipo.TabIndex = 3;
            // 
            // ColleccionesAsignadas
            // 
            this.ColleccionesAsignadas.Controls.Add(this.buttonEliminarPerfil);
            this.ColleccionesAsignadas.Controls.Add(this.tabColecciones);
            this.ColleccionesAsignadas.Location = new System.Drawing.Point(51, 250);
            this.ColleccionesAsignadas.Name = "ColleccionesAsignadas";
            this.ColleccionesAsignadas.Size = new System.Drawing.Size(639, 299);
            this.ColleccionesAsignadas.TabIndex = 5;
            this.ColleccionesAsignadas.TabStop = false;
            this.ColleccionesAsignadas.Text = "Collecciones Asignadas";
            // 
            // buttonEliminarPerfil
            // 
            this.buttonEliminarPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminarPerfil.Location = new System.Drawing.Point(585, 28);
            this.buttonEliminarPerfil.Name = "buttonEliminarPerfil";
            this.buttonEliminarPerfil.Size = new System.Drawing.Size(31, 31);
            this.buttonEliminarPerfil.TabIndex = 7;
            this.buttonEliminarPerfil.Text = "-";
            this.buttonEliminarPerfil.UseVisualStyleBackColor = true;
            this.buttonEliminarPerfil.Click += new System.EventHandler(this.buttonEliminarPerfil_Click);
            // 
            // tabColecciones
            // 
            this.tabColecciones.Location = new System.Drawing.Point(8, 28);
            this.tabColecciones.Name = "tabColecciones";
            this.tabColecciones.SelectedIndex = 0;
            this.tabColecciones.Size = new System.Drawing.Size(571, 256);
            this.tabColecciones.TabIndex = 8;
            // 
            // comboBoxFlujoTrabajo
            // 
            this.comboBoxFlujoTrabajo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFlujoTrabajo.FormattingEnabled = true;
            this.comboBoxFlujoTrabajo.Location = new System.Drawing.Point(138, 101);
            this.comboBoxFlujoTrabajo.Name = "comboBoxFlujoTrabajo";
            this.comboBoxFlujoTrabajo.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFlujoTrabajo.TabIndex = 7;
            this.comboBoxFlujoTrabajo.SelectedIndexChanged += new System.EventHandler(this.comboBoxFlujoTrabajo_SelectedIndexChanged);
            // 
            // labelFlujo
            // 
            this.labelFlujo.AutoSize = true;
            this.labelFlujo.Location = new System.Drawing.Point(48, 101);
            this.labelFlujo.Name = "labelFlujo";
            this.labelFlujo.Size = new System.Drawing.Size(68, 13);
            this.labelFlujo.TabIndex = 8;
            this.labelFlujo.Text = "Flujo Trabajo";
            // 
            // comboBoxColecciones
            // 
            this.comboBoxColecciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColecciones.FormattingEnabled = true;
            this.comboBoxColecciones.Location = new System.Drawing.Point(6, 19);
            this.comboBoxColecciones.Name = "comboBoxColecciones";
            this.comboBoxColecciones.Size = new System.Drawing.Size(160, 21);
            this.comboBoxColecciones.TabIndex = 9;
            // 
            // groupBoxAsignarColecciones
            // 
            this.groupBoxAsignarColecciones.Controls.Add(this.buttonAsignarColeccion);
            this.groupBoxAsignarColecciones.Controls.Add(this.comboBoxColecciones);
            this.groupBoxAsignarColecciones.Location = new System.Drawing.Point(51, 155);
            this.groupBoxAsignarColecciones.Name = "groupBoxAsignarColecciones";
            this.groupBoxAsignarColecciones.Size = new System.Drawing.Size(342, 89);
            this.groupBoxAsignarColecciones.TabIndex = 11;
            this.groupBoxAsignarColecciones.TabStop = false;
            this.groupBoxAsignarColecciones.Text = "Asignar colecciones";
            // 
            // buttonAsignarColeccion
            // 
            this.buttonAsignarColeccion.Location = new System.Drawing.Point(183, 19);
            this.buttonAsignarColeccion.Name = "buttonAsignarColeccion";
            this.buttonAsignarColeccion.Size = new System.Drawing.Size(126, 23);
            this.buttonAsignarColeccion.TabIndex = 10;
            this.buttonAsignarColeccion.Text = "Asignar colección";
            this.buttonAsignarColeccion.UseVisualStyleBackColor = true;
            this.buttonAsignarColeccion.Click += new System.EventHandler(this.buttonAsignarColeccion_Click);
            // 
            // labelMensaje
            // 
            this.labelMensaje.AutoSize = true;
            this.labelMensaje.Location = new System.Drawing.Point(135, 139);
            this.labelMensaje.Name = "labelMensaje";
            this.labelMensaje.Size = new System.Drawing.Size(0, 13);
            this.labelMensaje.TabIndex = 12;
            // 
            // FormDetallesPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 565);
            this.Controls.Add(this.labelMensaje);
            this.Controls.Add(this.groupBoxAsignarColecciones);
            this.Controls.Add(this.labelFlujo);
            this.Controls.Add(this.comboBoxFlujoTrabajo);
            this.Controls.Add(this.ColleccionesAsignadas);
            this.Controls.Add(this.textBoxTipo);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.labelTipo);
            this.Controls.Add(this.labelNombre);
            this.Name = "FormDetallesPerfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalles Perfil";
            this.Load += new System.EventHandler(this.FormDetallesPerfil_Load);
            this.ColleccionesAsignadas.ResumeLayout(false);
            this.groupBoxAsignarColecciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelTipo;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxTipo;
        private System.Windows.Forms.GroupBox ColleccionesAsignadas;
        private System.Windows.Forms.Button buttonEliminarPerfil;
        private System.Windows.Forms.ComboBox comboBoxFlujoTrabajo;
        private System.Windows.Forms.Label labelFlujo;
        private System.Windows.Forms.ComboBox comboBoxColecciones;
        private System.Windows.Forms.GroupBox groupBoxAsignarColecciones;
        private System.Windows.Forms.Button buttonAsignarColeccion;
        private System.Windows.Forms.TabControl tabColecciones;
        private System.Windows.Forms.Label labelMensaje;
    }
}