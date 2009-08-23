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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFlujosTrabajo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridFlujosTrabajo
            // 
            this.dataGridFlujosTrabajo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFlujosTrabajo.Location = new System.Drawing.Point(40, 85);
            this.dataGridFlujosTrabajo.Name = "dataGridFlujosTrabajo";
            this.dataGridFlujosTrabajo.Size = new System.Drawing.Size(468, 150);
            this.dataGridFlujosTrabajo.TabIndex = 0;
            // 
            // FormConstructor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 266);
            this.Controls.Add(this.dataGridFlujosTrabajo);
            this.Name = "FormConstructor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormConstructor";
            this.Load += new System.EventHandler(this.FormConstructor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFlujosTrabajo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridFlujosTrabajo;

    }
}