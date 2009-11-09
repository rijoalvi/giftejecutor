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
            this.radioButtonECCI = new System.Windows.Forms.RadioButton();
            this.radioButtonExterna = new System.Windows.Forms.RadioButton();
            this.buttonIniciar = new System.Windows.Forms.Button();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.groupBoxConexiones.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxConexiones
            // 
            this.groupBoxConexiones.Controls.Add(this.radioButtonECCI);
            this.groupBoxConexiones.Controls.Add(this.radioButtonExterna);
            this.groupBoxConexiones.Location = new System.Drawing.Point(15, 205);
            this.groupBoxConexiones.Name = "groupBoxConexiones";
            this.groupBoxConexiones.Size = new System.Drawing.Size(293, 49);
            this.groupBoxConexiones.TabIndex = 3;
            this.groupBoxConexiones.TabStop = false;
            // 
            // radioButtonECCI
            // 
            this.radioButtonECCI.AutoSize = true;
            this.radioButtonECCI.Location = new System.Drawing.Point(172, 19);
            this.radioButtonECCI.Name = "radioButtonECCI";
            this.radioButtonECCI.Size = new System.Drawing.Size(107, 17);
            this.radioButtonECCI.TabIndex = 3;
            this.radioButtonECCI.Text = "SQLServer, ECCI";
            this.radioButtonECCI.UseVisualStyleBackColor = true;
            // 
            // radioButtonExterna
            // 
            this.radioButtonExterna.AutoSize = true;
            this.radioButtonExterna.Checked = true;
            this.radioButtonExterna.Location = new System.Drawing.Point(21, 19);
            this.radioButtonExterna.Name = "radioButtonExterna";
            this.radioButtonExterna.Size = new System.Drawing.Size(113, 17);
            this.radioButtonExterna.TabIndex = 3;
            this.radioButtonExterna.TabStop = true;
            this.radioButtonExterna.Text = "SQLServer, EEUU";
            this.radioButtonExterna.UseVisualStyleBackColor = true;
            this.radioButtonExterna.CheckedChanged += new System.EventHandler(this.radioButtonExterna_CheckedChanged);
            // 
            // buttonIniciar
            // 
            this.buttonIniciar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIniciar.ForeColor = System.Drawing.Color.DarkGreen;
            this.buttonIniciar.Location = new System.Drawing.Point(219, 280);
            this.buttonIniciar.Name = "buttonIniciar";
            this.buttonIniciar.Size = new System.Drawing.Size(75, 23);
            this.buttonIniciar.TabIndex = 4;
            this.buttonIniciar.Text = "Iniciar";
            this.buttonIniciar.UseVisualStyleBackColor = true;
            this.buttonIniciar.Click += new System.EventHandler(this.buttonIniciar_Click);
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=BD;Initial Catalog=bdInge1g2_g2;Persist Security Info=True;User ID=us" +
                "uarioInge1_g2;Password=ui1_g2";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(12, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione la Conexión que Desea Utilizar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(451, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Favor ingresar el nombre de usuario y contraseña:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(15, 98);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.Text = "admin";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(15, 139);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Usuario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Contraseña:";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(13, 13);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(328, 32);
            this.labelError.TabIndex = 8;
            this.labelError.Text = "Nombre de usuario o contraseña incorrecto, \r\nfavor intentar nuevamente";
            // 
            // FormConexiones
            // 
            this.AcceptButton = this.buttonIniciar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 331);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonIniciar);
            this.Controls.Add(this.groupBoxConexiones);
            this.Name = "FormConexiones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FormConexiones_Load);
            this.groupBoxConexiones.ResumeLayout(false);
            this.groupBoxConexiones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConexiones;
        private System.Windows.Forms.RadioButton radioButtonECCI;
        private System.Windows.Forms.RadioButton radioButtonExterna;
        private System.Windows.Forms.Button buttonIniciar;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        //private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.MaskedTextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelError;
    }
}