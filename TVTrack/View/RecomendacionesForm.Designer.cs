namespace TVTrack.View
{
    partial class RecomendacionesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.lstRecomendaciones = new System.Windows.Forms.ListBox();
            this.btnCargarRecomendaciones = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstRecomendaciones
            // 
            this.lstRecomendaciones.FormattingEnabled = true;
            this.lstRecomendaciones.ItemHeight = 15;
            this.lstRecomendaciones.Location = new System.Drawing.Point(12, 12);
            this.lstRecomendaciones.Name = "lstRecomendaciones";
            this.lstRecomendaciones.Size = new System.Drawing.Size(460, 364);
            this.lstRecomendaciones.TabIndex = 0;
            // 
            // btnCargarRecomendaciones
            // 
            this.btnCargarRecomendaciones.Location = new System.Drawing.Point(170, 390);
            this.btnCargarRecomendaciones.Name = "btnCargarRecomendaciones";
            this.btnCargarRecomendaciones.Size = new System.Drawing.Size(150, 30);
            this.btnCargarRecomendaciones.TabIndex = 1;
            this.btnCargarRecomendaciones.Text = "Ver recomendaciones";
            this.btnCargarRecomendaciones.UseVisualStyleBackColor = true;
            this.btnCargarRecomendaciones.Click += new System.EventHandler(this.btnCargarRecomendaciones_Click);
            // 
            // RecomendacionesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 441);
            this.Controls.Add(this.btnCargarRecomendaciones);
            this.Controls.Add(this.lstRecomendaciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RecomendacionesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recomendaciones personalizadas";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox lstRecomendaciones;
        private System.Windows.Forms.Button btnCargarRecomendaciones;
    }
}
