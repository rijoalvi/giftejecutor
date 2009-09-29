namespace GiftEjecutor
{
    partial class FormConstructor
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
            this.dataGridFlujosTrabajo = new System.Windows.Forms.DataGridView();
            this.buttonConstruir = new System.Windows.Forms.Button();
            this.labelIDFlujo = new System.Windows.Forms.Label();
            this.textBoxIDFlujoTrabajo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFlujosTrabajo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridFlujosTrabajo
            // 
            this.dataGridFlujosTrabajo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFlujosTrabajo.Location = new System.Drawing.Point(28, 28);
            this.dataGridFlujosTrabajo.Name = "dataGridFlujosTrabajo";
            this.dataGridFlujosTrabajo.Size = new System.Drawing.Size(486, 193);
            this.dataGridFlujosTrabajo.TabIndex = 0;
            this.dataGridFlujosTrabajo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridFlujosTrabajo_CellClick);
            this.dataGridFlujosTrabajo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridFlujosTrabajo_CellContentClick);
            // 
            // buttonConstruir
            // 
            this.buttonConstruir.Location = new System.Drawing.Point(28, 266);
            this.buttonConstruir.Name = "buttonConstruir";
            this.buttonConstruir.Size = new System.Drawing.Size(75, 23);
            this.buttonConstruir.TabIndex = 1;
            this.buttonConstruir.Text = "Construir";
            this.buttonConstruir.UseVisualStyleBackColor = true;
            this.buttonConstruir.Click += new System.EventHandler(this.buttonConstruir_Click);
            // 
            // labelIDFlujo
            // 
            this.labelIDFlujo.AutoSize = true;
            this.labelIDFlujo.Location = new System.Drawing.Point(25, 224);
            this.labelIDFlujo.Name = "labelIDFlujo";
            this.labelIDFlujo.Size = new System.Drawing.Size(82, 13);
            this.labelIDFlujo.TabIndex = 2;
            this.labelIDFlujo.Text = "ID Flujo Trabajo";
            // 
            // textBoxIDFlujoTrabajo
            // 
            this.textBoxIDFlujoTrabajo.Location = new System.Drawing.Point(28, 240);
            this.textBoxIDFlujoTrabajo.Name = "textBoxIDFlujoTrabajo";
            this.textBoxIDFlujoTrabajo.Size = new System.Drawing.Size(100, 20);
            this.textBoxIDFlujoTrabajo.TabIndex = 3;
            // 
            // FormConstructor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 304);
            this.Controls.Add(this.textBoxIDFlujoTrabajo);
            this.Controls.Add(this.labelIDFlujo);
            this.Controls.Add(this.buttonConstruir);
            this.Controls.Add(this.dataGridFlujosTrabajo);
            this.Name = "FormConstructor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Construir Flujo de Trabajo";
            this.Load += new System.EventHandler(this.FormConstructor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFlujosTrabajo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridFlujosTrabajo;
        private System.Windows.Forms.Button buttonConstruir;
        private System.Windows.Forms.Label labelIDFlujo;
        private System.Windows.Forms.TextBox textBoxIDFlujoTrabajo;

    }
}