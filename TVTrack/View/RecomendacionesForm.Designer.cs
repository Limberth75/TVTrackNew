namespace TVTrack.View
{
    partial class RecomendacionesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstRecomendaciones;
        private System.Windows.Forms.Button btnCargarRecomendaciones;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lstRecomendaciones = new System.Windows.Forms.ListBox();
            this.btnCargarRecomendaciones = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // lstRecomendaciones
            // 
            this.lstRecomendaciones.FormattingEnabled = true;
            this.lstRecomendaciones.ItemHeight = 20;
            this.lstRecomendaciones.Location = new System.Drawing.Point(20, 20);
            this.lstRecomendaciones.Name = "lstRecomendaciones";
            this.lstRecomendaciones.Size = new System.Drawing.Size(350, 200);
            this.lstRecomendaciones.TabIndex = 0;

            // 
            // btnCargarRecomendaciones
            // 
            this.btnCargarRecomendaciones.Location = new System.Drawing.Point(20, 230);
            this.btnCargarRecomendaciones.Name = "btnCargarRecomendaciones";
            this.btnCargarRecomendaciones.Size = new System.Drawing.Size(200, 30);
            this.btnCargarRecomendaciones.TabIndex = 1;
            this.btnCargarRecomendaciones.Text = "Cargar Recomendaciones";
            this.btnCargarRecomendaciones.UseVisualStyleBackColor = true;
            this.btnCargarRecomendaciones.Click += new System.EventHandler(this.btnCargarRecomendaciones_Click);

            // 
            // RecomendacionesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 280);
            this.Controls.Add(this.lstRecomendaciones);
            this.Controls.Add(this.btnCargarRecomendaciones);
            this.Name = "RecomendacionesForm";
            this.Text = "Recomendaciones";
            this.ResumeLayout(false);
        }
    }
}
