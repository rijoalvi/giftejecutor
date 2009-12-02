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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarColeccionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarExpedienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesi�nToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edici�nToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarNombreToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m�dulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.constructorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gesti�nPerfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gesti�nDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignaci�nDeExpedientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignaci�nDeActividadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonActividad = new System.Windows.Forms.Button();
            this.directorio = new System.Windows.Forms.TreeView();
            this.labelPorRealizar = new System.Windows.Forms.Label();
            this.labelEnCurso = new System.Windows.Forms.Label();
            this.labelRealizadas = new System.Windows.Forms.Label();
            this.labelActividadesPorRealizar = new System.Windows.Forms.Label();
            this.labelActividadEnCurso = new System.Windows.Forms.Label();
            this.labelTituloExp = new System.Windows.Forms.Label();
            this.panelDetalleActividades = new System.Windows.Forms.Panel();
            this.labelActividadesRealizadas = new System.Windows.Forms.Label();
            this.listaFormularios = new System.Windows.Forms.ListBox();
            this.labelFormulariosCreados = new System.Windows.Forms.Label();
            this.pictureBoxVistaPrevia = new System.Windows.Forms.PictureBox();
            this.pictureBoxInbox = new System.Windows.Forms.PictureBox();
            this.labelAviso = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelInbox = new System.Windows.Forms.Panel();
            this.botonRechazarActInbox = new System.Windows.Forms.Button();
            this.botonEjecutarActInbox = new System.Windows.Forms.Button();
            this.dataGridInbox = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panelDetalleActividades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVistaPrevia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInbox)).BeginInit();
            this.panelInbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInbox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.edici�nToolStripMenuItem,
            this.m�dulosToolStripMenuItem});
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
            this.cerrarSesi�nToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // agregarColeccionToolStripMenuItem
            // 
            this.agregarColeccionToolStripMenuItem.Name = "agregarColeccionToolStripMenuItem";
            this.agregarColeccionToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.agregarColeccionToolStripMenuItem.Text = "Nueva Coleccion";
            this.agregarColeccionToolStripMenuItem.Click += new System.EventHandler(this.agregarColeccionToolStripMenuItem_Click);
            // 
            // agregarExpedienteToolStripMenuItem
            // 
            this.agregarExpedienteToolStripMenuItem.Name = "agregarExpedienteToolStripMenuItem";
            this.agregarExpedienteToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.agregarExpedienteToolStripMenuItem.Text = "Nuevo Expediente";
            this.agregarExpedienteToolStripMenuItem.Click += new System.EventHandler(this.agregarExpedienteToolStripMenuItem_Click);
            // 
            // cerrarSesi�nToolStripMenuItem
            // 
            this.cerrarSesi�nToolStripMenuItem.Name = "cerrarSesi�nToolStripMenuItem";
            this.cerrarSesi�nToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.cerrarSesi�nToolStripMenuItem.Text = "Cerrar Sesi�n";
            this.cerrarSesi�nToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesi�nToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.AccessibleDescription = "";
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // edici�nToolStripMenuItem
            // 
            this.edici�nToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarNombreToolStripMenuItem1,
            this.eliminarToolStripMenuItem});
            this.edici�nToolStripMenuItem.Name = "edici�nToolStripMenuItem";
            this.edici�nToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.edici�nToolStripMenuItem.Text = "Edici�n";
            // 
            // cambiarNombreToolStripMenuItem1
            // 
            this.cambiarNombreToolStripMenuItem1.Name = "cambiarNombreToolStripMenuItem1";
            this.cambiarNombreToolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
            this.cambiarNombreToolStripMenuItem1.Text = "Cambiar Nombre";
            this.cambiarNombreToolStripMenuItem1.Click += new System.EventHandler(this.cambiarNombreToolStripMenuItem1_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // m�dulosToolStripMenuItem
            // 
            this.m�dulosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.constructorToolStripMenuItem,
            this.gesti�nPerfilesToolStripMenuItem,
            this.gesti�nDeUsuariosToolStripMenuItem,
            this.asignaci�nDeExpedientesToolStripMenuItem,
            this.asignaci�nDeActividadesToolStripMenuItem});
            this.m�dulosToolStripMenuItem.Name = "m�dulosToolStripMenuItem";
            this.m�dulosToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.m�dulosToolStripMenuItem.Text = "Herramientas";
            // 
            // constructorToolStripMenuItem
            // 
            this.constructorToolStripMenuItem.Name = "constructorToolStripMenuItem";
            this.constructorToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.constructorToolStripMenuItem.Text = "Constructor";
            this.constructorToolStripMenuItem.Click += new System.EventHandler(this.constructorToolStripMenuItem_Click);
            // 
            // gesti�nPerfilesToolStripMenuItem
            // 
            this.gesti�nPerfilesToolStripMenuItem.Name = "gesti�nPerfilesToolStripMenuItem";
            this.gesti�nPerfilesToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.gesti�nPerfilesToolStripMenuItem.Text = "Gesti�n perfiles";
            this.gesti�nPerfilesToolStripMenuItem.Click += new System.EventHandler(this.gesti�nPerfilesToolStripMenuItem_Click);
            // 
            // gesti�nDeUsuariosToolStripMenuItem
            // 
            this.gesti�nDeUsuariosToolStripMenuItem.Name = "gesti�nDeUsuariosToolStripMenuItem";
            this.gesti�nDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.gesti�nDeUsuariosToolStripMenuItem.Text = "Gesti�n de Usuarios";
            this.gesti�nDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.gesti�nDeUsuariosToolStripMenuItem_Click);
            // 
            // asignaci�nDeExpedientesToolStripMenuItem
            // 
            this.asignaci�nDeExpedientesToolStripMenuItem.Name = "asignaci�nDeExpedientesToolStripMenuItem";
            this.asignaci�nDeExpedientesToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.asignaci�nDeExpedientesToolStripMenuItem.Text = "Asignaci�n de Expedientes";
            this.asignaci�nDeExpedientesToolStripMenuItem.Click += new System.EventHandler(this.asignaci�nDeExpedientesToolStripMenuItem_Click);
            // 
            // asignaci�nDeActividadesToolStripMenuItem
            // 
            this.asignaci�nDeActividadesToolStripMenuItem.Name = "asignaci�nDeActividadesToolStripMenuItem";
            this.asignaci�nDeActividadesToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.asignaci�nDeActividadesToolStripMenuItem.Text = "Asignaci�n de Actividades";
            this.asignaci�nDeActividadesToolStripMenuItem.Click += new System.EventHandler(this.asignaci�nDeActividadesToolStripMenuItem_Click);
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
            this.directorio.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.directorio_AfterCollapse);
            this.directorio.DoubleClick += new System.EventHandler(this.directorio_DoubleClick);
            this.directorio.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.directorio_AfterSelect);
            this.directorio.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.directorio_AfterExpand);
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
            // panelDetalleActividades
            // 
            this.panelDetalleActividades.Controls.Add(this.labelPorRealizar);
            this.panelDetalleActividades.Controls.Add(this.labelActividadesRealizadas);
            this.panelDetalleActividades.Controls.Add(this.labelEnCurso);
            this.panelDetalleActividades.Controls.Add(this.labelActividadesPorRealizar);
            this.panelDetalleActividades.Controls.Add(this.labelRealizadas);
            this.panelDetalleActividades.Controls.Add(this.labelActividadEnCurso);
            this.panelDetalleActividades.Location = new System.Drawing.Point(5, 778);
            this.panelDetalleActividades.Name = "panelDetalleActividades";
            this.panelDetalleActividades.Size = new System.Drawing.Size(967, 96);
            this.panelDetalleActividades.TabIndex = 19;
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
            // pictureBoxVistaPrevia
            // 
            this.pictureBoxVistaPrevia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBoxVistaPrevia.Image = global::GiftEjecutor.Properties.Resources.Pesta�aNoInvertidaPrevia;
            this.pictureBoxVistaPrevia.Location = new System.Drawing.Point(253, 24);
            this.pictureBoxVistaPrevia.Name = "pictureBoxVistaPrevia";
            this.pictureBoxVistaPrevia.Size = new System.Drawing.Size(69, 25);
            this.pictureBoxVistaPrevia.TabIndex = 24;
            this.pictureBoxVistaPrevia.TabStop = false;
            this.pictureBoxVistaPrevia.Click += new System.EventHandler(this.pictureBoxVistaPrevia_Click);
            // 
            // pictureBoxInbox
            // 
            this.pictureBoxInbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBoxInbox.Image = global::GiftEjecutor.Properties.Resources.Pesta�aInvertidaInbox;
            this.pictureBoxInbox.Location = new System.Drawing.Point(321, 24);
            this.pictureBoxInbox.Name = "pictureBoxInbox";
            this.pictureBoxInbox.Size = new System.Drawing.Size(69, 25);
            this.pictureBoxInbox.TabIndex = 25;
            this.pictureBoxInbox.TabStop = false;
            this.pictureBoxInbox.Click += new System.EventHandler(this.pictureBoxInbox_Click);
            // 
            // labelAviso
            // 
            this.labelAviso.AutoSize = true;
            this.labelAviso.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAviso.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelAviso.Location = new System.Drawing.Point(298, 307);
            this.labelAviso.Name = "labelAviso";
            this.labelAviso.Size = new System.Drawing.Size(501, 23);
            this.labelAviso.TabIndex = 28;
            this.labelAviso.Text = "El expediente no ha sido inicializado todav�a.";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panelInbox
            // 
            this.panelInbox.Controls.Add(this.botonRechazarActInbox);
            this.panelInbox.Controls.Add(this.botonEjecutarActInbox);
            this.panelInbox.Controls.Add(this.dataGridInbox);
            this.panelInbox.Controls.Add(this.label1);
            this.panelInbox.Location = new System.Drawing.Point(257, 56);
            this.panelInbox.Name = "panelInbox";
            this.panelInbox.Size = new System.Drawing.Size(644, 573);
            this.panelInbox.TabIndex = 30;
            // 
            // botonRechazarActInbox
            // 
            this.botonRechazarActInbox.Location = new System.Drawing.Point(150, 376);
            this.botonRechazarActInbox.Name = "botonRechazarActInbox";
            this.botonRechazarActInbox.Size = new System.Drawing.Size(116, 23);
            this.botonRechazarActInbox.TabIndex = 5;
            this.botonRechazarActInbox.Text = "Rechazar Actividad";
            this.botonRechazarActInbox.UseVisualStyleBackColor = true;
            this.botonRechazarActInbox.Click += new System.EventHandler(this.botonRechazarActInbox_Click);
            // 
            // botonEjecutarActInbox
            // 
            this.botonEjecutarActInbox.Location = new System.Drawing.Point(17, 376);
            this.botonEjecutarActInbox.Name = "botonEjecutarActInbox";
            this.botonEjecutarActInbox.Size = new System.Drawing.Size(116, 23);
            this.botonEjecutarActInbox.TabIndex = 4;
            this.botonEjecutarActInbox.Text = "Ejecutar Actividad";
            this.botonEjecutarActInbox.UseVisualStyleBackColor = true;
            this.botonEjecutarActInbox.Click += new System.EventHandler(this.botonEjecutarActInbox_Click);
            // 
            // dataGridInbox
            // 
            this.dataGridInbox.AllowUserToAddRows = false;
            this.dataGridInbox.AllowUserToDeleteRows = false;
            this.dataGridInbox.AllowUserToOrderColumns = true;
            this.dataGridInbox.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridInbox.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridInbox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInbox.Location = new System.Drawing.Point(17, 63);
            this.dataGridInbox.Name = "dataGridInbox";
            this.dataGridInbox.ReadOnly = true;
            this.dataGridInbox.Size = new System.Drawing.Size(610, 295);
            this.dataGridInbox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Actividades por realizar:";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GiftEjecutor.Properties.Resources.Fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1048, 776);
            this.Controls.Add(this.panelInbox);
            this.Controls.Add(this.pictureBoxInbox);
            this.Controls.Add(this.labelAviso);
            this.Controls.Add(this.pictureBoxVistaPrevia);
            this.Controls.Add(this.labelFormulariosCreados);
            this.Controls.Add(this.listaFormularios);
            this.Controls.Add(this.labelTituloExp);
            this.Controls.Add(this.directorio);
            this.Controls.Add(this.buttonActividad);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelDetalleActividades);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GIFT Ejecutor";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.Shown += new System.EventHandler(this.FormPrincipal_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelDetalleActividades.ResumeLayout(false);
            this.panelDetalleActividades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVistaPrevia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInbox)).EndInit();
            this.panelInbox.ResumeLayout(false);
            this.panelInbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem m�dulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem constructorToolStripMenuItem;
        private System.Windows.Forms.Button buttonActividad;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarColeccionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarExpedienteToolStripMenuItem;
        private System.Windows.Forms.Label labelActividadesPorRealizar;
        private System.Windows.Forms.Label labelActividadEnCurso;
        private System.Windows.Forms.Label labelPorRealizar;
        private System.Windows.Forms.Label labelEnCurso;
        private System.Windows.Forms.Label labelRealizadas;
        private System.Windows.Forms.Label labelTituloExp;
        private System.Windows.Forms.ToolStripMenuItem gesti�nPerfilesToolStripMenuItem;
        private System.Windows.Forms.Panel panelDetalleActividades;
        private System.Windows.Forms.Label labelActividadesRealizadas;
        private System.Windows.Forms.ListBox listaFormularios;
        private System.Windows.Forms.Label labelFormulariosCreados;
        private System.Windows.Forms.ToolStripMenuItem gesti�nDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignaci�nDeExpedientesToolStripMenuItem;
        private System.Windows.Forms.TreeView directorio;
        private ArbolGift arbol;
        private System.Windows.Forms.PictureBox pictureBoxVistaPrevia;
        private System.Windows.Forms.PictureBox pictureBoxInbox;
        private System.Windows.Forms.ToolStripMenuItem asignaci�nDeActividadesToolStripMenuItem;
        private System.Windows.Forms.Label labelAviso;
        private System.Windows.Forms.ToolStripMenuItem edici�nToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarNombreToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesi�nToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Panel panelInbox;
        private System.Windows.Forms.DataGridView dataGridInbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonRechazarActInbox;
        private System.Windows.Forms.Button botonEjecutarActInbox;
    }
}