namespace TVTrack.View
{
    partial class RegistroForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Button btnGuardar;

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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblNombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 10);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(64, 20);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";

            // txtNombre
            this.txtNombre.Location = new System.Drawing.Point(20, 30);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(250, 27);
            this.txtNombre.TabIndex = 1;

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 60);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 20);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email:";

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(20, 80);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 27);
            this.txtEmail.TabIndex = 3;

            // lblContraseña
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(20, 110);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(85, 20);
            this.lblContraseña.TabIndex = 4;
            this.lblContraseña.Text = "Contraseña:";

            // txtContraseña
            this.txtContraseña.Location = new System.Drawing.Point(20, 130);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(250, 27);
            this.txtContraseña.TabIndex = 5;
            this.txtContraseña.UseSystemPasswordChar = true;

            // lblRol
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(20, 160);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(32, 20);
            this.lblRol.TabIndex = 6;
            this.lblRol.Text = "Rol:";

            // cmbRol
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.Location = new System.Drawing.Point(20, 180);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(250, 27);
            this.cmbRol.TabIndex = 7;

            // btnGuardar
            this.btnGuardar.Location = new System.Drawing.Point(20, 220);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(250, 30);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar Usuario";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // RegistroForm
            this.ClientSize = new System.Drawing.Size(300, 280);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblContraseña);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.btnGuardar);
            this.Name = "RegistroForm";
            this.Text = "Registro de Usuario";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
