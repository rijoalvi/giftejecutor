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
            this.radioButtonEjecutorECCI = new System.Windows.Forms.RadioButton();
            this.radioButtonEjecutorExterna = new System.Windows.Forms.RadioButton();
            this.buttonIniciar = new System.Windows.Forms.Button();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonConfiguradorECCI = new System.Windows.Forms.RadioButton();
            this.radioButtonConfiguradorExterna = new System.Windows.Forms.RadioButton();
            this.groupBoxConexiones.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxConexiones
            // 
            this.groupBoxConexiones.Controls.Add(this.radioButtonEjecutorECCI);
            this.groupBoxConexiones.Controls.Add(this.radioButtonEjecutorExterna);
            this.groupBoxConexiones.Location = new System.Drawing.Point(12, 24);
            this.groupBoxConexiones.Name = "groupBoxConexiones";
            this.groupBoxConexiones.Size = new System.Drawing.Size(230, 67);
            this.groupBoxConexiones.TabIndex = 0;
            this.groupBoxConexiones.TabStop = false;
            this.groupBoxConexiones.Text = "Ejecutor";
            // 
            // radioButtonEjecutorECCI
            // 
            this.radioButtonEjecutorECCI.AutoSize = true;
            this.radioButtonEjecutorECCI.Location = new System.Drawing.Point(21, 42);
            this.radioButtonEjecutorECCI.Name = "radioButtonEjecutorECCI";
            this.radioButtonEjecutorECCI.Size = new System.Drawing.Size(107, 17);
            this.radioButtonEjecutorECCI.TabIndex = 2;
            this.radioButtonEjecutorECCI.Text = "SQLServer, ECCI";
            this.radioButtonEjecutorECCI.UseVisualStyleBackColor = true;
            this.radioButtonEjecutorECCI.CheckedChanged += new System.EventHandler(this.radioButtonSQLServerConfigurador_CheckedChanged);
            // 
            // radioButtonEjecutorExterna
            // 
            this.radioButtonEjecutorExterna.AutoSize = true;
            this.radioButtonEjecutorExterna.Checked = true;
            this.radioButtonEjecutorExterna.Location = new System.Drawing.Point(21, 19);
            this.radioButtonEjecutorExterna.Name = "radioButtonEjecutorExterna";
            this.radioButtonEjecutorExterna.Size = new System.Drawing.Size(113, 17);
            this.radioButtonEjecutorExterna.TabIndex = 1;
            this.radioButtonEjecutorExterna.TabStop = true;
            this.radioButtonEjecutorExterna.Text = "SQLServer, EEUU";
            this.radioButtonEjecutorExterna.UseVisualStyleBackColor = true;
            this.radioButtonEjecutorExterna.CheckedChanged += new System.EventHandler(this.radioButtonMYSQL_CheckedChanged);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonConfiguradorECCI);
            this.groupBox1.Controls.Add(this.radioButtonConfiguradorExterna);
            this.groupBox1.Location = new System.Drawing.Point(267, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 67);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurador";
            // 
            // radioButtonConfiguradorECCI
            // 
            this.radioButtonConfiguradorECCI.AutoSize = true;
            this.radioButtonConfiguradorECCI.Location = new System.Drawing.Point(17, 42);
            this.radioButtonConfiguradorECCI.Name = "radioButtonConfiguradorECCI";
            this.radioButtonConfiguradorECCI.Size = new System.Drawing.Size(160, 17);
            this.radioButtonConfiguradorECCI.TabIndex = 3;
            this.radioButtonConfiguradorECCI.TabStop = true;
            this.radioButtonConfiguradorECCI.Text = "Conexión ECCI (SQL Server)";
            this.radioButtonConfiguradorECCI.UseVisualStyleBackColor = true;
            // 
            // radioButtonConfiguradorExterna
            // 
            this.radioButtonConfiguradorExterna.AutoSize = true;
            this.radioButtonConfiguradorExterna.Checked = true;
            this.radioButtonConfiguradorExterna.Location = new System.Drawing.Point(17, 19);
            this.radioButtonConfiguradorExterna.Name = "radioButtonConfiguradorExterna";
            this.radioButtonConfiguradorExterna.Size = new System.Drawing.Size(172, 17);
            this.radioButtonConfiguradorExterna.TabIndex = 2;
            this.radioButtonConfiguradorExterna.TabStop = true;
            this.radioButtonConfiguradorExterna.Text = "Conexión Externa (SQL Server)";
            this.radioButtonConfiguradorExterna.UseVisualStyleBackColor = true;
            this.radioButtonConfiguradorExterna.CheckedChanged += new System.EventHandler(this.radioButtonConexionExternaConfigurador_CheckedChanged);
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
        private System.Windows.Forms.RadioButton radioButtonEjecutorECCI;
        private System.Windows.Forms.RadioButton radioButtonEjecutorExterna;
        private System.Windows.Forms.Button buttonIniciar;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        //private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonConfiguradorECCI;
        private System.Windows.Forms.RadioButton radioButtonConfiguradorExterna;
    }
}