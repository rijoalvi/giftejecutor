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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarColeccionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarExpedienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarNombreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarBETAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m�dulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.constructorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonActividad = new System.Windows.Forms.Button();
            this.directorio = new System.Windows.Forms.TreeView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelEjecutorial = new System.Windows.Forms.Panel();
            this.labelPorRealizar = new System.Windows.Forms.Label();
            this.labelEnCurso = new System.Windows.Forms.Label();
            this.labelRealizadas = new System.Windows.Forms.Label();
            this.buttonVerDisenoExpediente = new System.Windows.Forms.Button();
            this.labelDetalleActividadesRealizadas = new System.Windows.Forms.Label();
            this.labelActividadesPorRealizar = new System.Windows.Forms.Label();
            this.labelActividadEnCurso = new System.Windows.Forms.Label();
            this.labelActividadesRealizadas = new System.Windows.Forms.Label();
            this.dataGridDetallesEjecucion = new System.Windows.Forms.DataGridView();
            this.labelDetalleEjecutorial = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panelFormularios = new System.Windows.Forms.Panel();
            this.botonVerDisenno = new System.Windows.Forms.Button();
            this.botonSigFormulario = new System.Windows.Forms.Button();
            this.labelTituloExp = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelEjecutorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetallesEjecucion)).BeginInit();
            this.panelFormularios.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.m�dulosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
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
            // m�dulosToolStripMenuItem
            // 
            this.m�dulosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.constructorToolStripMenuItem});
            this.m�dulosToolStripMenuItem.Name = "m�dulosToolStripMenuItem";
            this.m�dulosToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.m�dulosToolStripMenuItem.Text = "M�dulos";
            // 
            // constructorToolStripMenuItem
            // 
            this.constructorToolStripMenuItem.Name = "constructorToolStripMenuItem";
            this.constructorToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.constructorToolStripMenuItem.Text = "Constructor";
            this.constructorToolStripMenuItem.Click += new System.EventHandler(this.constructorToolStripMenuItem_Click);
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
            this.directorio.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.directorio_AfterSelect_1);
            this.directorio.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.directorio_NodeMouseClick);
            this.directorio.Click += new System.EventHandler(this.directorio_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(824, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 138);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 635);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "pruebaActividad";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(85, 635);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "abrir form";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelEjecutorial
            // 
            this.panelEjecutorial.Controls.Add(this.labelPorRealizar);
            this.panelEjecutorial.Controls.Add(this.labelEnCurso);
            this.panelEjecutorial.Controls.Add(this.labelRealizadas);
            this.panelEjecutorial.Controls.Add(this.buttonVerDisenoExpediente);
            this.panelEjecutorial.Controls.Add(this.labelDetalleActividadesRealizadas);
            this.panelEjecutorial.Controls.Add(this.labelActividadesPorRealizar);
            this.panelEjecutorial.Controls.Add(this.labelActividadEnCurso);
            this.panelEjecutorial.Controls.Add(this.labelActividadesRealizadas);
            this.panelEjecutorial.Controls.Add(this.dataGridDetallesEjecucion);
            this.panelEjecutorial.Controls.Add(this.labelDetalleEjecutorial);
            this.panelEjecutorial.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.panelEjecutorial.Location = new System.Drawing.Point(256, 189);
            this.panelEjecutorial.Name = "panelEjecutorial";
            this.panelEjecutorial.Size = new System.Drawing.Size(716, 669);
            this.panelEjecutorial.TabIndex = 16;
            // 
            // labelPorRealizar
            // 
            this.labelPorRealizar.AutoSize = true;
            this.labelPorRealizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPorRealizar.ForeColor = System.Drawing.Color.Firebrick;
            this.labelPorRealizar.Location = new System.Drawing.Point(7, 249);
            this.labelPorRealizar.Name = "labelPorRealizar";
            this.labelPorRealizar.Size = new System.Drawing.Size(13, 18);
            this.labelPorRealizar.TabIndex = 9;
            this.labelPorRealizar.Text = " ";
            // 
            // labelEnCurso
            // 
            this.labelEnCurso.AutoSize = true;
            this.labelEnCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnCurso.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.labelEnCurso.Location = new System.Drawing.Point(5, 142);
            this.labelEnCurso.Name = "labelEnCurso";
            this.labelEnCurso.Size = new System.Drawing.Size(13, 18);
            this.labelEnCurso.TabIndex = 8;
            this.labelEnCurso.Text = " ";
            // 
            // labelRealizadas
            // 
            this.labelRealizadas.AutoSize = true;
            this.labelRealizadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRealizadas.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelRealizadas.Location = new System.Drawing.Point(5, 58);
            this.labelRealizadas.Name = "labelRealizadas";
            this.labelRealizadas.Size = new System.Drawing.Size(13, 18);
            this.labelRealizadas.TabIndex = 7;
            this.labelRealizadas.Text = " ";
            // 
            // buttonVerDisenoExpediente
            // 
            this.buttonVerDisenoExpediente.Font = new System.Drawing.Font("Verdana", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVerDisenoExpediente.Location = new System.Drawing.Point(501, 639);
            this.buttonVerDisenoExpediente.Name = "buttonVerDisenoExpediente";
            this.buttonVerDisenoExpediente.Size = new System.Drawing.Size(209, 23);
            this.buttonVerDisenoExpediente.TabIndex = 6;
            this.buttonVerDisenoExpediente.Text = "Ver el Dise�o del Expediente";
            this.buttonVerDisenoExpediente.UseVisualStyleBackColor = true;
            this.buttonVerDisenoExpediente.Click += new System.EventHandler(this.buttonVerDisenoExpediente_Click);
            // 
            // labelDetalleActividadesRealizadas
            // 
            this.labelDetalleActividadesRealizadas.AutoSize = true;
            this.labelDetalleActividadesRealizadas.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDetalleActividadesRealizadas.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelDetalleActividadesRealizadas.Location = new System.Drawing.Point(-1, 319);
            this.labelDetalleActividadesRealizadas.Name = "labelDetalleActividadesRealizadas";
            this.labelDetalleActividadesRealizadas.Size = new System.Drawing.Size(453, 23);
            this.labelDetalleActividadesRealizadas.TabIndex = 5;
            this.labelDetalleActividadesRealizadas.Text = "Detalles del trabajo sobre el expediente:";
            this.labelDetalleActividadesRealizadas.Click += new System.EventHandler(this.labelDetalleActividadesRealizadas_Click);
            // 
            // labelActividadesPorRealizar
            // 
            this.labelActividadesPorRealizar.AutoSize = true;
            this.labelActividadesPorRealizar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActividadesPorRealizar.Location = new System.Drawing.Point(5, 222);
            this.labelActividadesPorRealizar.Name = "labelActividadesPorRealizar";
            this.labelActividadesPorRealizar.Size = new System.Drawing.Size(168, 13);
            this.labelActividadesPorRealizar.TabIndex = 4;
            this.labelActividadesPorRealizar.Text = "Actividades por realizar:";
            // 
            // labelActividadEnCurso
            // 
            this.labelActividadEnCurso.AutoSize = true;
            this.labelActividadEnCurso.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActividadEnCurso.Location = new System.Drawing.Point(3, 118);
            this.labelActividadEnCurso.Name = "labelActividadEnCurso";
            this.labelActividadEnCurso.Size = new System.Drawing.Size(132, 13);
            this.labelActividadEnCurso.TabIndex = 3;
            this.labelActividadEnCurso.Text = "Actividad en curso:";
            // 
            // labelActividadesRealizadas
            // 
            this.labelActividadesRealizadas.AutoSize = true;
            this.labelActividadesRealizadas.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActividadesRealizadas.Location = new System.Drawing.Point(3, 35);
            this.labelActividadesRealizadas.Name = "labelActividadesRealizadas";
            this.labelActividadesRealizadas.Size = new System.Drawing.Size(179, 13);
            this.labelActividadesRealizadas.TabIndex = 2;
            this.labelActividadesRealizadas.Text = "Actividades ya realizadas:";
            // 
            // dataGridDetallesEjecucion
            // 
            this.dataGridDetallesEjecucion.AllowUserToAddRows = false;
            this.dataGridDetallesEjecucion.AllowUserToDeleteRows = false;
            this.dataGridDetallesEjecucion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridDetallesEjecucion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridDetallesEjecucion.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridDetallesEjecucion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDetallesEjecucion.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridDetallesEjecucion.Location = new System.Drawing.Point(6, 358);
            this.dataGridDetallesEjecucion.Name = "dataGridDetallesEjecucion";
            this.dataGridDetallesEjecucion.ReadOnly = true;
            this.dataGridDetallesEjecucion.Size = new System.Drawing.Size(710, 256);
            this.dataGridDetallesEjecucion.TabIndex = 1;
            // 
            // labelDetalleEjecutorial
            // 
            this.labelDetalleEjecutorial.AutoSize = true;
            this.labelDetalleEjecutorial.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDetalleEjecutorial.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelDetalleEjecutorial.Location = new System.Drawing.Point(-1, 0);
            this.labelDetalleEjecutorial.Name = "labelDetalleEjecutorial";
            this.labelDetalleEjecutorial.Size = new System.Drawing.Size(401, 23);
            this.labelDetalleEjecutorial.TabIndex = 0;
            this.labelDetalleEjecutorial.Text = "Estado de Ejecuci�n del Expediente ";
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Verdana", 36F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                            | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelTitulo.Location = new System.Drawing.Point(295, 69);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(395, 59);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "GIFT Ejecutor";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(166, 635);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "buttonCillo";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panelFormularios
            // 
            this.panelFormularios.Controls.Add(this.botonVerDisenno);
            this.panelFormularios.Controls.Add(this.botonSigFormulario);
            this.panelFormularios.Location = new System.Drawing.Point(253, 828);
            this.panelFormularios.Name = "panelFormularios";
            this.panelFormularios.Size = new System.Drawing.Size(716, 30);
            this.panelFormularios.TabIndex = 10;
            // 
            // botonVerDisenno
            // 
            this.botonVerDisenno.Font = new System.Drawing.Font("Verdana", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.botonVerDisenno.Location = new System.Drawing.Point(537, 3);
            this.botonVerDisenno.Name = "botonVerDisenno";
            this.botonVerDisenno.Size = new System.Drawing.Size(176, 23);
            this.botonVerDisenno.TabIndex = 3;
            this.botonVerDisenno.Text = "Ver Estado de Ejecucion";
            this.botonVerDisenno.UseVisualStyleBackColor = true;
            this.botonVerDisenno.Click += new System.EventHandler(this.botonVerDisenno_Click);
            // 
            // botonSigFormulario
            // 
            this.botonSigFormulario.Font = new System.Drawing.Font("Verdana", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.botonSigFormulario.Location = new System.Drawing.Point(361, 3);
            this.botonSigFormulario.Name = "botonSigFormulario";
            this.botonSigFormulario.Size = new System.Drawing.Size(156, 23);
            this.botonSigFormulario.TabIndex = 2;
            this.botonSigFormulario.Text = "Ver Siguiente Formulario";
            this.botonSigFormulario.UseVisualStyleBackColor = true;
            this.botonSigFormulario.Click += new System.EventHandler(this.botonSigFormulario_Click);
            // 
            // labelTituloExp
            // 
            this.labelTituloExp.AutoSize = true;
            this.labelTituloExp.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloExp.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelTituloExp.Location = new System.Drawing.Point(260, 31);
            this.labelTituloExp.Name = "labelTituloExp";
            this.labelTituloExp.Size = new System.Drawing.Size(306, 23);
            this.labelTituloExp.TabIndex = 1;
            this.labelTituloExp.Text = "Formularios del Expediente";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GiftEjecutor.Properties.Resources.Fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 861);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.labelTituloExp);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.directorio);
            this.Controls.Add(this.buttonActividad);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelEjecutorial);
            this.Controls.Add(this.panelFormularios);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelEjecutorial.ResumeLayout(false);
            this.panelEjecutorial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetallesEjecucion)).EndInit();
            this.panelFormularios.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem m�dulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem constructorToolStripMenuItem;
        private System.Windows.Forms.Button buttonActividad;
        private System.Windows.Forms.TreeView directorio;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarColeccionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarExpedienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarNombreToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem eliminarBETAToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelEjecutorial;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.DataGridView dataGridDetallesEjecucion;
        private System.Windows.Forms.Label labelDetalleEjecutorial;
        private System.Windows.Forms.Label labelDetalleActividadesRealizadas;
        private System.Windows.Forms.Label labelActividadesPorRealizar;
        private System.Windows.Forms.Label labelActividadEnCurso;
        private System.Windows.Forms.Label labelActividadesRealizadas;
        private System.Windows.Forms.Button buttonVerDisenoExpediente;
        private System.Windows.Forms.Label labelPorRealizar;
        private System.Windows.Forms.Label labelEnCurso;
        private System.Windows.Forms.Label labelRealizadas;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panelFormularios;
        private System.Windows.Forms.Label labelTituloExp;
        private System.Windows.Forms.Button botonVerDisenno;
        private System.Windows.Forms.Button botonSigFormulario;
    }
}