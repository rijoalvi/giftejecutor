namespace GiftEjecutor
{
    partial class FormGestionPerfiles
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
            this.dataGridViewPerfiles = new System.Windows.Forms.DataGridView();
            this.buttonAgregarPerfil = new System.Windows.Forms.Button();
            this.buttonEliminarPerfil = new System.Windows.Forms.Button();
            this.groupBoxPerfiles = new System.Windows.Forms.GroupBox();
            this.buttonDetalles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPerfiles)).BeginInit();
            this.groupBoxPerfiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewPerfiles
            // 
            this.dataGridViewPerfiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPerfiles.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewPerfiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPerfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPerfiles.Location = new System.Drawing.Point(22, 19);
            this.dataGridViewPerfiles.Name = "dataGridViewPerfiles";
            this.dataGridViewPerfiles.Size = new System.Drawing.Size(547, 242);
            this.dataGridViewPerfiles.TabIndex = 0;
            this.dataGridViewPerfiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPerfiles_CellClick);
            this.dataGridViewPerfiles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPerfiles_CellContentClick);
            // 
            // buttonAgregarPerfil
            // 
            this.buttonAgregarPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregarPerfil.Location = new System.Drawing.Point(575, 19);
            this.buttonAgregarPerfil.Name = "buttonAgregarPerfil";
            this.buttonAgregarPerfil.Size = new System.Drawing.Size(31, 31);
            this.buttonAgregarPerfil.TabIndex = 1;
            this.buttonAgregarPerfil.Text = "+";
            this.buttonAgregarPerfil.UseVisualStyleBackColor = true;
            this.buttonAgregarPerfil.Click += new System.EventHandler(this.buttonAgregarPerfil_Click);
            // 
            // buttonEliminarPerfil
            // 
            this.buttonEliminarPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminarPerfil.Location = new System.Drawing.Point(575, 56);
            this.buttonEliminarPerfil.Name = "buttonEliminarPerfil";
            this.buttonEliminarPerfil.Size = new System.Drawing.Size(31, 31);
            this.buttonEliminarPerfil.TabIndex = 2;
            this.buttonEliminarPerfil.Text = "-";
            this.buttonEliminarPerfil.UseVisualStyleBackColor = true;
            this.buttonEliminarPerfil.Click += new System.EventHandler(this.buttonEliminarPerfil_Click);
            // 
            // groupBoxPerfiles
            // 
            this.groupBoxPerfiles.Controls.Add(this.buttonDetalles);
            this.groupBoxPerfiles.Controls.Add(this.dataGridViewPerfiles);
            this.groupBoxPerfiles.Controls.Add(this.buttonEliminarPerfil);
            this.groupBoxPerfiles.Controls.Add(this.buttonAgregarPerfil);
            this.groupBoxPerfiles.Location = new System.Drawing.Point(12, 12);
            this.groupBoxPerfiles.Name = "groupBoxPerfiles";
            this.groupBoxPerfiles.Size = new System.Drawing.Size(646, 279);
            this.groupBoxPerfiles.TabIndex = 3;
            this.groupBoxPerfiles.TabStop = false;
            this.groupBoxPerfiles.Text = "Perfiles";
            // 
            // buttonDetalles
            // 
            this.buttonDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDetalles.Location = new System.Drawing.Point(575, 93);
            this.buttonDetalles.Name = "buttonDetalles";
            this.buttonDetalles.Size = new System.Drawing.Size(62, 31);
            this.buttonDetalles.TabIndex = 3;
            this.buttonDetalles.Text = "Detalles";
            this.buttonDetalles.UseVisualStyleBackColor = true;
            this.buttonDetalles.Click += new System.EventHandler(this.buttonDetalles_Click);
            // 
            // FormGestionPerfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 443);
            this.Controls.Add(this.groupBoxPerfiles);
            this.Name = "FormGestionPerfiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionPerfiles";
            this.Load += new System.EventHandler(this.GestionPerfiles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPerfiles)).EndInit();
            this.groupBoxPerfiles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPerfiles;
        private System.Windows.Forms.Button buttonAgregarPerfil;
        private System.Windows.Forms.Button buttonEliminarPerfil;
        private System.Windows.Forms.GroupBox groupBoxPerfiles;
        private System.Windows.Forms.Button buttonDetalles;
    }
}