namespace GiftEjecutor
{
    partial class FormAsignacionActividades
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboUsuarios = new System.Windows.Forms.ComboBox();
            this.comboExpedientes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxActividades = new System.Windows.Forms.GroupBox();
            this.dataGridActividadesNoSeleccionadas1 = new System.Windows.Forms.DataGridView();
            this.dataGridActividadesSeleccionadas1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.groupBoxActividades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridActividadesNoSeleccionadas1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridActividadesSeleccionadas1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // comboUsuarios
            // 
            this.comboUsuarios.FormattingEnabled = true;
            this.comboUsuarios.Location = new System.Drawing.Point(287, 12);
            this.comboUsuarios.Name = "comboUsuarios";
            this.comboUsuarios.Size = new System.Drawing.Size(189, 21);
            this.comboUsuarios.TabIndex = 1;
            this.comboUsuarios.SelectedIndexChanged += new System.EventHandler(this.comboUsuarios_SelectedIndexChanged);
            // 
            // comboExpedientes
            // 
            this.comboExpedientes.FormattingEnabled = true;
            this.comboExpedientes.Location = new System.Drawing.Point(287, 49);
            this.comboExpedientes.Name = "comboExpedientes";
            this.comboExpedientes.Size = new System.Drawing.Size(189, 21);
            this.comboExpedientes.TabIndex = 3;
            this.comboExpedientes.SelectedIndexChanged += new System.EventHandler(this.comboExpedientes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Expediente";
            // 
            // groupBoxActividades
            // 
            this.groupBoxActividades.Controls.Add(this.buttonAgregar);
            this.groupBoxActividades.Controls.Add(this.buttonEliminar);
            this.groupBoxActividades.Controls.Add(this.label4);
            this.groupBoxActividades.Controls.Add(this.label3);
            this.groupBoxActividades.Controls.Add(this.dataGridActividadesSeleccionadas1);
            this.groupBoxActividades.Controls.Add(this.dataGridActividadesNoSeleccionadas1);
            this.groupBoxActividades.Location = new System.Drawing.Point(13, 76);
            this.groupBoxActividades.Name = "groupBoxActividades";
            this.groupBoxActividades.Size = new System.Drawing.Size(640, 225);
            this.groupBoxActividades.TabIndex = 4;
            this.groupBoxActividades.TabStop = false;
            this.groupBoxActividades.Text = "Actividades";
            // 
            // dataGridActividadesNoSeleccionadas1
            // 
            this.dataGridActividadesNoSeleccionadas1.AllowUserToAddRows = false;
            this.dataGridActividadesNoSeleccionadas1.AllowUserToDeleteRows = false;
            this.dataGridActividadesNoSeleccionadas1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridActividadesNoSeleccionadas1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridActividadesNoSeleccionadas1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridActividadesNoSeleccionadas1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridActividadesNoSeleccionadas1.Location = new System.Drawing.Point(7, 49);
            this.dataGridActividadesNoSeleccionadas1.Name = "dataGridActividadesNoSeleccionadas1";
            this.dataGridActividadesNoSeleccionadas1.Size = new System.Drawing.Size(254, 153);
            this.dataGridActividadesNoSeleccionadas1.TabIndex = 0;
            this.dataGridActividadesNoSeleccionadas1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridActividades_CellContentClick);
            // 
            // dataGridActividadesSeleccionadas1
            // 
            this.dataGridActividadesSeleccionadas1.AllowUserToAddRows = false;
            this.dataGridActividadesSeleccionadas1.AllowUserToDeleteRows = false;
            this.dataGridActividadesSeleccionadas1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridActividadesSeleccionadas1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridActividadesSeleccionadas1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridActividadesSeleccionadas1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridActividadesSeleccionadas1.Location = new System.Drawing.Point(380, 49);
            this.dataGridActividadesSeleccionadas1.Name = "dataGridActividadesSeleccionadas1";
            this.dataGridActividadesSeleccionadas1.Size = new System.Drawing.Size(254, 153);
            this.dataGridActividadesSeleccionadas1.TabIndex = 1;
            this.dataGridActividadesSeleccionadas1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewActividadesSeleccionadas1_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Disponibles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(377, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Asignadas";
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(307, 130);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(27, 23);
            this.buttonEliminar.TabIndex = 4;
            this.buttonEliminar.Text = "-";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Location = new System.Drawing.Point(307, 101);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(27, 23);
            this.buttonAgregar.TabIndex = 5;
            this.buttonAgregar.Text = "+";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Location = new System.Drawing.Point(578, 307);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(75, 23);
            this.buttonCerrar.TabIndex = 5;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            // 
            // FormAsignacionActividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 337);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.groupBoxActividades);
            this.Controls.Add(this.comboExpedientes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboUsuarios);
            this.Controls.Add(this.label1);
            this.Name = "FormAsignacionActividades";
            this.Text = "Asignación de Actividades a Usuarios";
            this.Load += new System.EventHandler(this.FormAsignacionActividades_Load);
            this.groupBoxActividades.ResumeLayout(false);
            this.groupBoxActividades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridActividadesNoSeleccionadas1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridActividadesSeleccionadas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboUsuarios;
        private System.Windows.Forms.ComboBox comboExpedientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxActividades;
        private System.Windows.Forms.DataGridView dataGridActividadesNoSeleccionadas1;
        private System.Windows.Forms.DataGridView dataGridActividadesSeleccionadas1;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCerrar;
    }
}