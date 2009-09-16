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
            this.módulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.constructorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonActividad = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.directorio = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.módulosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(627, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarColeccionToolStripMenuItem,
            this.agregarExpedienteToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // agregarColeccionToolStripMenuItem
            // 
            this.agregarColeccionToolStripMenuItem.Name = "agregarColeccionToolStripMenuItem";
            this.agregarColeccionToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
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
            // módulosToolStripMenuItem
            // 
            this.módulosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.constructorToolStripMenuItem});
            this.módulosToolStripMenuItem.Name = "módulosToolStripMenuItem";
            this.módulosToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.módulosToolStripMenuItem.Text = "Módulos";
            // 
            // constructorToolStripMenuItem
            // 
            this.constructorToolStripMenuItem.Name = "constructorToolStripMenuItem";
            this.constructorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.constructorToolStripMenuItem.Text = "Constructor";
            this.constructorToolStripMenuItem.Click += new System.EventHandler(this.constructorToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(210, 307);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "buttonProbarActividadSimle";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(229, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(371, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(480, 154);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // buttonActividad
            // 
            this.buttonActividad.Location = new System.Drawing.Point(129, 307);
            this.buttonActividad.Name = "buttonActividad";
            this.buttonActividad.Size = new System.Drawing.Size(75, 23);
            this.buttonActividad.TabIndex = 8;
            this.buttonActividad.Text = "Actividad";
            this.buttonActividad.UseVisualStyleBackColor = true;
            this.buttonActividad.Click += new System.EventHandler(this.buttonActividad_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(4, 307);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "actualizarTreeView";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // directorio
            // 
            this.directorio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.directorio.Location = new System.Drawing.Point(4, 31);
            this.directorio.Name = "directorio";
            this.directorio.Size = new System.Drawing.Size(208, 270);
            this.directorio.TabIndex = 10;
            this.directorio.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.directorio_AfterSelect);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 334);
            this.Controls.Add(this.directorio);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.buttonActividad);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPrincipal";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem módulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem constructorToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buttonActividad;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TreeView directorio;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarColeccionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarExpedienteToolStripMenuItem;
    }
}