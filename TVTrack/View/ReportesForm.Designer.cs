namespace TVTrack.View
{
    partial class ReportesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstReportes;
        private System.Windows.Forms.Button btnCargarReportes;

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
            this.lstReportes = new System.Windows.Forms.ListBox();
            this.btnCargarReportes = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lstReportes
            this.lstReportes.FormattingEnabled = true;
            this.lstReportes.ItemHeight = 20;
            this.lstReportes.Location = new System.Drawing.Point(20, 20);
            this.lstReportes.Name = "lstReportes";
            this.lstReportes.Size = new System.Drawing.Size(350, 200);
            this.lstReportes.TabIndex = 0;

            // btnCargarReportes
            this.btnCargarReportes.Location = new System.Drawing.Point(20, 230);
            this.btnCargarReportes.Name = "btnCargarReportes";
            this.btnCargarReportes.Size = new System.Drawing.Size(350, 30);
            this.btnCargarReportes.TabIndex = 1;
            this.btnCargarReportes.Text = "Cargar Reportes";
            this.btnCargarReportes.UseVisualStyleBackColor = true;
            this.btnCargarReportes.Click += new System.EventHandler(this.btnCargarReportes_Click);

            // ReportesForm
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.lstReportes);
            this.Controls.Add(this.btnCargarReportes);
            this.Name = "ReportesForm";
            this.Text = "Reportes";
            this.ResumeLayout(false);
        }
    }
}
