namespace GiftEjecutor
{
    partial class Splash
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
            this.labelCargando = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCargando
            // 
            this.labelCargando.AutoSize = true;
            this.labelCargando.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(100)))), ((int)(((byte)(101)))));
            this.labelCargando.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCargando.ForeColor = System.Drawing.Color.Cyan;
            this.labelCargando.Location = new System.Drawing.Point(224, 567);
            this.labelCargando.Name = "labelCargando";
            this.labelCargando.Size = new System.Drawing.Size(148, 25);
            this.labelCargando.TabIndex = 0;
            this.labelCargando.Text = "Cargando...";
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GiftEjecutor.Properties.Resources.GIFT;
            this.ClientSize = new System.Drawing.Size(600, 601);
            this.ControlBox = false;
            this.Controls.Add(this.labelCargando);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Splash";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCargando;
    }
}