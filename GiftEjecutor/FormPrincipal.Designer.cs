namespace GiftEjecutor
{
    partial class FormPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarColeccionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarExpedienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarNombreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarBETAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.módulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.constructorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónPerfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignaciónDeExpedientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignaciónDeActividadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desconexiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonActividad = new System.Windows.Forms.Button();
            this.directorio = new System.Windows.Forms.TreeView();
            this.labelPorRealizar = new System.Windows.Forms.Label();
            this.labelEnCurso = new System.Windows.Forms.Label();
            this.labelRealizadas = new System.Windows.Forms.Label();
            this.labelActividadesPorRealizar = new System.Windows.Forms.Label();
            this.labelActividadEnCurso = new System.Windows.Forms.Label();
            this.labelTituloExp = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelActividadesRealizadas = new System.Windows.Forms.Label();
            this.listaFormularios = new System.Windows.Forms.ListBox();
            this.labelFormulariosCreados = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.módulosToolStripMenuItem,
            this.usuarioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1048, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarColeccionToolStripMenuItem,
            this.agregarExpedienteToolStripMenuItem,
            this.cambiarNombreToolStripMenuItem,
            this.eliminarBETAToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // agregarColeccionToolStripMenuItem
            // 
            this.agregarColeccionToolStripMenuItem.Name = "agregarColeccionToolStripMenuItem";
            this.agregarColeccionToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.agregarColeccionToolStripMenuItem.Text = "Agregar Coleccion";
            this.agregarColeccionToolStripMenuItem.Click += new System.EventHandler(this.agregarColeccionToolStripMenuItem_Click);
            // 
            // agregarExpedienteToolStripMenuItem
            // 
            this.agregarExpedienteToolStripMenuItem.Name = "agregarExpedienteToolStripMenuItem";
            this.agregarExpedienteToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.agregarExpedienteToolStripMenuItem.Text = "Crear Expediente";
            this.agregarExpedienteToolStripMenuItem.Click += new System.EventHandler(this.agregarExpedienteToolStripMenuItem_Click);
            // 
            // cambiarNombreToolStripMenuItem
            // 
            this.cambiarNombreToolStripMenuItem.Name = "cambiarNombreToolStripMenuItem";
            this.cambiarNombreToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.cambiarNombreToolStripMenuItem.Text = "Cambiar Nombre";
            this.cambiarNombreToolStripMenuItem.Click += new System.EventHandler(this.cambiarNombreToolStripMenuItem_Click);
            // 
            // eliminarBETAToolStripMenuItem
            // 
            this.eliminarBETAToolStripMenuItem.Name = "eliminarBETAToolStripMenuItem";
            this.eliminarBETAToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.eliminarBETAToolStripMenuItem.Text = "Eliminar (BETA)";
            this.eliminarBETAToolStripMenuItem.Click += new System.EventHandler(this.eliminarBETAToolStripMenuItem_Click);
            // 
            // módulosToolStripMenuItem
            // 
            this.módulosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.constructorToolStripMenuItem,
            this.gestiónPerfilesToolStripMenuItem,
            this.gestiónDeUsuariosToolStripMenuItem,
            this.asignaciónDeExpedientesToolStripMenuItem,
            this.asignaciónDeActividadesToolStripMenuItem});
            this.módulosToolStripMenuItem.Name = "módulosToolStripMenuItem";
            this.módulosToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.módulosToolStripMenuItem.Text = "Módulos";
            // 
            // constructorToolStripMenuItem
            // 
            this.constructorToolStripMenuItem.Name = "constructorToolStripMenuItem";
            this.constructorToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.constructorToolStripMenuItem.Text = "Constructor";
            this.constructorToolStripMenuItem.Click += new System.EventHandler(this.constructorToolStripMenuItem_Click);
            // 
            // gestiónPerfilesToolStripMenuItem
            // 
            this.gestiónPerfilesToolStripMenuItem.Name = "gestiónPerfilesToolStripMenuItem";
            this.gestiónPerfilesToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.gestiónPerfilesToolStripMenuItem.Text = "Gestión perfiles";
            this.gestiónPerfilesToolStripMenuItem.Click += new System.EventHandler(this.gestiónPerfilesToolStripMenuItem_Click);
            // 
            // gestiónDeUsuariosToolStripMenuItem
            // 
            this.gestiónDeUsuariosToolStripMenuItem.Name = "gestiónDeUsuariosToolStripMenuItem";
            this.gestiónDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.gestiónDeUsuariosToolStripMenuItem.Text = "Gestión de Usuarios";
            this.gestiónDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.gestiónDeUsuariosToolStripMenuItem_Click);
            // 
            // asignaciónDeExpedientesToolStripMenuItem
            // 
            this.asignaciónDeExpedientesToolStripMenuItem.Name = "asignaciónDeExpedientesToolStripMenuItem";
            this.asignaciónDeExpedientesToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.asignaciónDeExpedientesToolStripMenuItem.Text = "Asignación de Expedientes";
            this.asignaciónDeExpedientesToolStripMenuItem.Click += new System.EventHandler(this.asignaciónDeExpedientesToolStripMenuItem_Click);
            // 
            // asignaciónDeActividadesToolStripMenuItem
            // 
            this.asignaciónDeActividadesToolStripMenuItem.Name = "asignaciónDeActividadesToolStripMenuItem";
            this.asignaciónDeActividadesToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.asignaciónDeActividadesToolStripMenuItem.Text = "Asignación de Actividades";
            this.asignaciónDeActividadesToolStripMenuItem.Click += new System.EventHandler(this.asignaciónDeActividadesToolStripMenuItem_Click);
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.desconexiónToolStripMenuItem});
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // desconexiónToolStripMenuItem
            // 
            this.desconexiónToolStripMenuItem.Name = "desconexiónToolStripMenuItem";
            this.desconexiónToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.desconexiónToolStripMenuItem.Text = "Desconexión";
            this.desconexiónToolStripMenuItem.Click += new System.EventHandler(this.desconexiónToolStripMenuItem_Click);
            // 
            // buttonActividad
            // 
            this.buttonActividad.Location = new System.Drawing.Point(4, 307);
            this.buttonActividad.Name = "buttonActividad";
            this.buttonActividad.Size = new System.Drawing.Size(75, 23);
            this.buttonActividad.TabIndex = 8;
            this.buttonActividad.Text = "Actividad";
            this.buttonActividad.UseVisualStyleBackColor = true;
            this.buttonActividad.Visible = false;
            this.buttonActividad.Click += new System.EventHandler(this.buttonActividad_Click);
            // 
            // directorio
            // 
            this.directorio.Location = new System.Drawing.Point(4, 31);
            this.directorio.Name = "directorio";
            this.directorio.Size = new System.Drawing.Size(246, 598);
            this.directorio.TabIndex = 10;
            this.directorio.DoubleClick += new System.EventHandler(this.directorio_DoubleClick);
            this.directorio.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.directorio_AfterSelect);
            // 
            // labelPorRealizar
            // 
            this.labelPorRealizar.AutoSize = true;
            this.labelPorRealizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPorRealizar.ForeColor = System.Drawing.Color.Firebrick;
            this.labelPorRealizar.Location = new System.Drawing.Point(256, 73);
            this.labelPorRealizar.Name = "labelPorRealizar";
            this.labelPorRealizar.Size = new System.Drawing.Size(11, 13);
            this.labelPorRealizar.TabIndex = 9;
            this.labelPorRealizar.Text = " ";
            // 
            // labelEnCurso
            // 
            this.labelEnCurso.AutoSize = true;
            this.labelEnCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnCurso.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.labelEnCurso.Location = new System.Drawing.Point(253, 46);
            this.labelEnCurso.Name = "labelEnCurso";
            this.labelEnCurso.Size = new System.Drawing.Size(11, 13);
            this.labelEnCurso.TabIndex = 8;
            this.labelEnCurso.Text = " ";
            // 
            // labelRealizadas
            // 
            this.labelRealizadas.AutoSize = true;
            this.labelRealizadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRealizadas.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelRealizadas.Location = new System.Drawing.Point(253, 15);
            this.labelRealizadas.Name = "labelRealizadas";
            this.labelRealizadas.Size = new System.Drawing.Size(11, 13);
            this.labelRealizadas.TabIndex = 7;
            this.labelRealizadas.Text = " ";
            // 
            // labelActividadesPorRealizar
            // 
            this.labelActividadesPorRealizar.AutoSize = true;
            this.labelActividadesPorRealizar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActividadesPorRealizar.Location = new System.Drawing.Point(253, 58);
            this.labelActividadesPorRealizar.Name = "labelActividadesPorRealizar";
            this.labelActividadesPorRealizar.Size = new System.Drawing.Size(168, 13);
            this.labelActividadesPorRealizar.TabIndex = 4;
            this.labelActividadesPorRealizar.Text = "Actividades por realizar:";
            // 
            // labelActividadEnCurso
            // 
            this.labelActividadEnCurso.AutoSize = true;
            this.labelActividadEnCurso.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActividadEnCurso.Location = new System.Drawing.Point(253, 31);
            this.labelActividadEnCurso.Name = "labelActividadEnCurso";
            this.labelActividadEnCurso.Size = new System.Drawing.Size(132, 13);
            this.labelActividadEnCurso.TabIndex = 3;
            this.labelActividadEnCurso.Text = "Actividad en curso:";
            // 
            // labelTituloExp
            // 
            this.labelTituloExp.AutoSize = true;
            this.labelTituloExp.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloExp.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelTituloExp.Location = new System.Drawing.Point(392, 25);
            this.labelTituloExp.Name = "labelTituloExp";
            this.labelTituloExp.Size = new System.Drawing.Size(131, 23);
            this.labelTituloExp.TabIndex = 1;
            this.labelTituloExp.Text = "Expediente";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelPorRealizar);
            this.panel1.Controls.Add(this.labelActividadesRealizadas);
            this.panel1.Controls.Add(this.labelEnCurso);
            this.panel1.Controls.Add(this.labelActividadesPorRealizar);
            this.panel1.Controls.Add(this.labelRealizadas);
            this.panel1.Controls.Add(this.labelActividadEnCurso);
            this.panel1.Location = new System.Drawing.Point(5, 778);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(967, 96);
            this.panel1.TabIndex = 19;
            // 
            // labelActividadesRealizadas
            // 
            this.labelActividadesRealizadas.AutoSize = true;
            this.labelActividadesRealizadas.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActividadesRealizadas.Location = new System.Drawing.Point(253, 0);
            this.labelActividadesRealizadas.Name = "labelActividadesRealizadas";
            this.labelActividadesRealizadas.Size = new System.Drawing.Size(179, 13);
            this.labelActividadesRealizadas.TabIndex = 3;
            this.labelActividadesRealizadas.Text = "Actividades ya realizadas:";
            // 
            // listaFormularios
            // 
            this.listaFormularios.FormattingEnabled = true;
            this.listaFormularios.Location = new System.Drawing.Point(910, 71);
            this.listaFormularios.Name = "listaFormularios";
            this.listaFormularios.Size = new System.Drawing.Size(127, 199);
            this.listaFormularios.TabIndex = 21;
            // 
            // labelFormulariosCreados
            // 
            this.labelFormulariosCreados.AutoSize = true;
            this.labelFormulariosCreados.Location = new System.Drawing.Point(907, 55);
            this.labelFormulariosCreados.Name = "labelFormulariosCreados";
            this.labelFormulariosCreados.Size = new System.Drawing.Size(104, 13);
            this.labelFormulariosCreados.TabIndex = 22;
            this.labelFormulariosCreados.Text = "Formularios creados:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Image = global::GiftEjecutor.Properties.Resources.PestañaNoInvertidaPrevia;
            this.pictureBox1.Location = new System.Drawing.Point(253, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 25);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Image = global::GiftEjecutor.Properties.Resources.PestañaInvertidaInbox;
            this.pictureBox2.Location = new System.Drawing.Point(321, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(69, 25);
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GiftEjecutor.Properties.Resources.Fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1048, 876);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelFormulariosCreados);
            this.Controls.Add(this.listaFormularios);
            this.Controls.Add(this.labelTituloExp);
            this.Controls.Add(this.directorio);
            this.Controls.Add(this.buttonActividad);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GIFT Ejecutor";
            this.Shown += new System.EventHandler(this.FormPrincipal_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem módulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem constructorToolStripMenuItem;
        private System.Windows.Forms.Button buttonActividad;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarColeccionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarExpedienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarNombreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarBETAToolStripMenuItem;
        private System.Windows.Forms.Label labelActividadesPorRealizar;
        private System.Windows.Forms.Label labelActividadEnCurso;
        private System.Windows.Forms.Label labelPorRealizar;
        private System.Windows.Forms.Label labelEnCurso;
        private System.Windows.Forms.Label labelRealizadas;
        private System.Windows.Forms.Label labelTituloExp;
        private System.Windows.Forms.ToolStripMenuItem gestiónPerfilesToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelActividadesRealizadas;
        private System.Windows.Forms.ListBox listaFormularios;
        private System.Windows.Forms.Label labelFormulariosCreados;
        private System.Windows.Forms.ToolStripMenuItem gestiónDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignaciónDeExpedientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desconexiónToolStripMenuItem;
        private System.Windows.Forms.TreeView directorio;
        private ArbolGift arbol;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem asignaciónDeActividadesToolStripMenuItem;
    }
}