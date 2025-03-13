namespace TVTrack.View
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnRecomendaciones;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnContenido;

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
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnRecomendaciones = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnContenido = new System.Windows.Forms.Button();

            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(30, 30);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(150, 40);
            this.btnRegistrar.Text = "Registrar Usuario";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);

            // 
            // btnRecomendaciones
            // 
            this.btnRecomendaciones.Location = new System.Drawing.Point(30, 80);
            this.btnRecomendaciones.Name = "btnRecomendaciones";
            this.btnRecomendaciones.Size = new System.Drawing.Size(150, 40);
            this.btnRecomendaciones.Text = "Ver Recomendaciones";
            this.btnRecomendaciones.UseVisualStyleBackColor = true;
            this.btnRecomendaciones.Click += new System.EventHandler(this.btnRecomendaciones_Click);

            // 
            // btnReportes
            // 
            this.btnReportes.Location = new System.Drawing.Point(30, 130);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(150, 40);
            this.btnReportes.Text = "Ver Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);

            // 
            // btnContenido
            // 
            this.btnContenido.Location = new System.Drawing.Point(30, 180);
            this.btnContenido.Name = "btnContenido";
            this.btnContenido.Size = new System.Drawing.Size(150, 40);
            this.btnContenido.Text = "Ver Contenido";
            this.btnContenido.UseVisualStyleBackColor = true;
            this.btnContenido.Click += new System.EventHandler(this.btnContenido_Click);

            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnRecomendaciones);
            this.Controls.Add(this.btnReportes);
            this.Controls.Add(this.btnContenido);
            this.Text = "TV Track - Inicio";
            this.ResumeLayout(false);
        }
    }
}
