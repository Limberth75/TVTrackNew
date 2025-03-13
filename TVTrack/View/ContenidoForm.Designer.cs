namespace TVTrack.View
{
    partial class ContenidoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstContenido;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;

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
            this.lstContenido = new System.Windows.Forms.ListBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // lstContenido
            // 
            this.lstContenido.FormattingEnabled = true;
            this.lstContenido.ItemHeight = 20;
            this.lstContenido.Location = new System.Drawing.Point(20, 50);
            this.lstContenido.Name = "lstContenido";
            this.lstContenido.Size = new System.Drawing.Size(350, 200);
            this.lstContenido.TabIndex = 0;

            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(20, 15);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(200, 27);
            this.txtBuscar.TabIndex = 1;

            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(230, 15);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 27);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(20, 270);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 30);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(150, 270);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // 
            // ContenidoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 320);
            this.Controls.Add(this.lstContenido);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEliminar);
            this.Name = "ContenidoForm";
            this.Text = "Gestión de Contenido";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
