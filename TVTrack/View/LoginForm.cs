using System;
using System.Windows.Forms;
using TVTrack.Controller;
using TVTrack.Model;

namespace TVTrack.View
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string contraseña = txtContraseña.Text;

            Usuario usuario = UsuarioController.ObtenerUsuarioPorNombre(nombre);

            if (usuario != null && usuario.Contraseña == contraseña)
            {
                MessageBox.Show($"✅ Bienvenido, {usuario.Nombre} ({usuario.Rol})", "Ingreso exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                MainForm mainForm = new MainForm(usuario);
                mainForm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("❌ Nombre o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
