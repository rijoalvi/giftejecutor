namespace GiftEjecutor
{
    partial class FormConexiones
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
            this.groupBoxConexiones = new System.Windows.Forms.GroupBox();
            this.radioButtonMYSQL = new System.Windows.Forms.RadioButton();
            this.radioButtonSQLServer = new System.Windows.Forms.RadioButton();
            this.buttonIniciar = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBoxConexiones.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxConexiones
            // 
            this.groupBoxConexiones.Controls.Add(this.linkLabel1);
            this.groupBoxConexiones.Controls.Add(this.radioButtonSQLServer);
            this.groupBoxConexiones.Controls.Add(this.radioButtonMYSQL);
            this.groupBoxConexiones.Location = new System.Drawing.Point(66, 24);
            this.groupBoxConexiones.Name = "groupBoxConexiones";
            this.groupBoxConexiones.Size = new System.Drawing.Size(298, 67);
            this.groupBoxConexiones.TabIndex = 0;
            this.groupBoxConexiones.TabStop = false;
            this.groupBoxConexiones.Text = "Conexiones";
            // 
            // radioButtonMYSQL
            // 
            this.radioButtonMYSQL.AutoSize = true;
            this.radioButtonMYSQL.Checked = true;
            this.radioButtonMYSQL.Location = new System.Drawing.Point(21, 19);
            this.radioButtonMYSQL.Name = "radioButtonMYSQL";
            this.radioButtonMYSQL.Size = new System.Drawing.Size(98, 17);
            this.radioButtonMYSQL.TabIndex = 1;
            this.radioButtonMYSQL.TabStop = true;
            this.radioButtonMYSQL.Text = "MYSQL, EEUU";
            this.radioButtonMYSQL.UseVisualStyleBackColor = true;
            this.radioButtonMYSQL.CheckedChanged += new System.EventHandler(this.radioButtonMYSQL_CheckedChanged);
            // 
            // radioButtonSQLServer
            // 
            this.radioButtonSQLServer.AutoSize = true;
            this.radioButtonSQLServer.Location = new System.Drawing.Point(21, 42);
            this.radioButtonSQLServer.Name = "radioButtonSQLServer";
            this.radioButtonSQLServer.Size = new System.Drawing.Size(107, 17);
            this.radioButtonSQLServer.TabIndex = 2;
            this.radioButtonSQLServer.Text = "SQLServer, ECCI";
            this.radioButtonSQLServer.UseVisualStyleBackColor = true;
            // 
            // buttonIniciar
            // 
            this.buttonIniciar.Location = new System.Drawing.Point(99, 111);
            this.buttonIniciar.Name = "buttonIniciar";
            this.buttonIniciar.Size = new System.Drawing.Size(75, 23);
            this.buttonIniciar.TabIndex = 0;
            this.buttonIniciar.Text = "Iniciar";
            this.buttonIniciar.UseVisualStyleBackColor = true;
            this.buttonIniciar.Click += new System.EventHandler(this.buttonIniciar_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(125, 21);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(167, 13);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.bluechiphosting.com/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // FormConexiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 157);
            this.Controls.Add(this.buttonIniciar);
            this.Controls.Add(this.groupBoxConexiones);
            this.Name = "FormConexiones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GIFT Ejecutor";
            this.Load += new System.EventHandler(this.FormConexiones_Load);
            this.groupBoxConexiones.ResumeLayout(false);
            this.groupBoxConexiones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConexiones;
        private System.Windows.Forms.RadioButton radioButtonSQLServer;
        private System.Windows.Forms.RadioButton radioButtonMYSQL;
        private System.Windows.Forms.Button buttonIniciar;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}