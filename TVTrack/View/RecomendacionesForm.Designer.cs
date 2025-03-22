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
            lstRecomendaciones = new ListBox();
            btnCargarRecomendaciones = new Button();
            SuspendLayout();
            // 
            // lstRecomendaciones
            // 
            lstRecomendaciones.FormattingEnabled = true;
            lstRecomendaciones.ItemHeight = 25;
            lstRecomendaciones.Location = new Point(25, 31);
            lstRecomendaciones.Margin = new Padding(4, 5, 4, 5);
            lstRecomendaciones.Name = "lstRecomendaciones";
            lstRecomendaciones.Size = new Size(436, 304);
            lstRecomendaciones.TabIndex = 0;
            // 
            // btnCargarRecomendaciones
            // 
            btnCargarRecomendaciones.Location = new Point(25, 359);
            btnCargarRecomendaciones.Margin = new Padding(4, 5, 4, 5);
            btnCargarRecomendaciones.Name = "btnCargarRecomendaciones";
            btnCargarRecomendaciones.Size = new Size(250, 47);
            btnCargarRecomendaciones.TabIndex = 1;
            btnCargarRecomendaciones.Text = "Cargar Recomendaciones";
            btnCargarRecomendaciones.TextAlign = ContentAlignment.MiddleRight;
            btnCargarRecomendaciones.UseVisualStyleBackColor = true;
            btnCargarRecomendaciones.Click += btnCargarRecomendaciones_Click;
            // 
            // RecomendacionesForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 438);
            Controls.Add(lstRecomendaciones);
            Controls.Add(btnCargarRecomendaciones);
            Margin = new Padding(4, 5, 4, 5);
            Name = "RecomendacionesForm";
            Text = "Recomendaciones";
            ResumeLayout(false);
        }
    }
}
