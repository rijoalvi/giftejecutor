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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.radioButtonSQLServerConfigurador = new System.Windows.Forms.RadioButton();
            this.radioButtonMySQLEjecutor = new System.Windows.Forms.RadioButton();
            this.buttonIniciar = new System.Windows.Forms.Button();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonConexionExternaConfigurador = new System.Windows.Forms.RadioButton();
            this.radioButtonConexionECCIConfigurador = new System.Windows.Forms.RadioButton();
            this.groupBoxConexiones.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxConexiones
            // 
            this.groupBoxConexiones.Controls.Add(this.linkLabel1);
            this.groupBoxConexiones.Controls.Add(this.radioButtonSQLServerConfigurador);
            this.groupBoxConexiones.Controls.Add(this.radioButtonMySQLEjecutor);
            this.groupBoxConexiones.Location = new System.Drawing.Point(12, 24);
            this.groupBoxConexiones.Name = "groupBoxConexiones";
            this.groupBoxConexiones.Size = new System.Drawing.Size(230, 67);
            this.groupBoxConexiones.TabIndex = 0;
            this.groupBoxConexiones.TabStop = false;
            this.groupBoxConexiones.Text = "Ejecutor";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(114, 21);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(37, 13);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "check";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // radioButtonSQLServerConfigurador
            // 
            this.radioButtonSQLServerConfigurador.AutoSize = true;
            this.radioButtonSQLServerConfigurador.Location = new System.Drawing.Point(21, 42);
            this.radioButtonSQLServerConfigurador.Name = "radioButtonSQLServerConfigurador";
            this.radioButtonSQLServerConfigurador.Size = new System.Drawing.Size(107, 17);
            this.radioButtonSQLServerConfigurador.TabIndex = 2;
            this.radioButtonSQLServerConfigurador.Text = "SQLServer, ECCI";
            this.radioButtonSQLServerConfigurador.UseVisualStyleBackColor = true;
            this.radioButtonSQLServerConfigurador.CheckedChanged += new System.EventHandler(this.radioButtonSQLServerConfigurador_CheckedChanged);
            // 
            // radioButtonMySQLEjecutor
            // 
            this.radioButtonMySQLEjecutor.AutoSize = true;
            this.radioButtonMySQLEjecutor.Checked = true;
            this.radioButtonMySQLEjecutor.Location = new System.Drawing.Point(21, 19);
            this.radioButtonMySQLEjecutor.Name = "radioButtonMySQLEjecutor";
            this.radioButtonMySQLEjecutor.Size = new System.Drawing.Size(98, 17);
            this.radioButtonMySQLEjecutor.TabIndex = 1;
            this.radioButtonMySQLEjecutor.TabStop = true;
            this.radioButtonMySQLEjecutor.Text = "MYSQL, EEUU";
            this.radioButtonMySQLEjecutor.UseVisualStyleBackColor = true;
            this.radioButtonMySQLEjecutor.CheckedChanged += new System.EventHandler(this.radioButtonMYSQL_CheckedChanged);
            // 
            // buttonIniciar
            // 
            this.buttonIniciar.Location = new System.Drawing.Point(193, 172);
            this.buttonIniciar.Name = "buttonIniciar";
            this.buttonIniciar.Size = new System.Drawing.Size(75, 23);
            this.buttonIniciar.TabIndex = 0;
            this.buttonIniciar.Text = "Iniciar";
            this.buttonIniciar.UseVisualStyleBackColor = true;
            this.buttonIniciar.Click += new System.EventHandler(this.buttonIniciar_Click);
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=BD;Initial Catalog=bdInge1g2_g2;Persist Security Info=True;User ID=us" +
                "uarioInge1_g2;Password=ui1_g2";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            this.sqlConnection1.InfoMessage += new System.Data.SqlClient.SqlInfoMessageEventHandler(this.sqlConnection1_InfoMessage);
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonConexionECCIConfigurador);
            this.groupBox1.Controls.Add(this.radioButtonConexionExternaConfigurador);
            this.groupBox1.Location = new System.Drawing.Point(267, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 67);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurador";
            // 
            // radioButtonConexionExternaConfigurador
            // 
            this.radioButtonConexionExternaConfigurador.AutoSize = true;
            this.radioButtonConexionExternaConfigurador.Checked = true;
            this.radioButtonConexionExternaConfigurador.Location = new System.Drawing.Point(17, 19);
            this.radioButtonConexionExternaConfigurador.Name = "radioButtonConexionExternaConfigurador";
            this.radioButtonConexionExternaConfigurador.Size = new System.Drawing.Size(172, 17);
            this.radioButtonConexionExternaConfigurador.TabIndex = 2;
            this.radioButtonConexionExternaConfigurador.TabStop = true;
            this.radioButtonConexionExternaConfigurador.Text = "Conexión Externa (SQL Server)";
            this.radioButtonConexionExternaConfigurador.UseVisualStyleBackColor = true;
            this.radioButtonConexionExternaConfigurador.CheckedChanged += new System.EventHandler(this.radioButtonConexionExternaConfigurador_CheckedChanged);
            // 
            // radioButtonConexionECCIConfigurador
            // 
            this.radioButtonConexionECCIConfigurador.AutoSize = true;
            this.radioButtonConexionECCIConfigurador.Location = new System.Drawing.Point(17, 42);
            this.radioButtonConexionECCIConfigurador.Name = "radioButtonConexionECCIConfigurador";
            this.radioButtonConexionECCIConfigurador.Size = new System.Drawing.Size(160, 17);
            this.radioButtonConexionECCIConfigurador.TabIndex = 3;
            this.radioButtonConexionECCIConfigurador.TabStop = true;
            this.radioButtonConexionECCIConfigurador.Text = "Conexión ECCI (SQL Server)";
            this.radioButtonConexionECCIConfigurador.UseVisualStyleBackColor = true;
            // 
            // FormConexiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 207);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonIniciar);
            this.Controls.Add(this.groupBoxConexiones);
            this.Name = "FormConexiones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GIFT Ejecutor";
            this.Load += new System.EventHandler(this.FormConexiones_Load);
            this.groupBoxConexiones.ResumeLayout(false);
            this.groupBoxConexiones.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConexiones;
        private System.Windows.Forms.RadioButton radioButtonSQLServerConfigurador;
        private System.Windows.Forms.RadioButton radioButtonMySQLEjecutor;
        private System.Windows.Forms.Button buttonIniciar;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonConexionECCIConfigurador;
        private System.Windows.Forms.RadioButton radioButtonConexionExternaConfigurador;
    }
}