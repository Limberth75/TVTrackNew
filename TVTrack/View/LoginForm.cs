using System;
using System.Windows.Forms;
using TVTrack.Controller;
using TVTrack.Model;

namespace TVTrack.View
{
    // Formulario de inicio de sesión del sistema
    public partial class LoginForm : Form
    {
        // Constructor del formulario
        public LoginForm()
        {
            InitializeComponent();
        }

        // Evento: se ejecuta al hacer clic en el botón "Iniciar sesión"
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Obtiene los datos ingresados por el usuario
            string nombre = txtNombre.Text.Trim();
            string contraseña = txtContraseña.Text;

            // Busca al usuario por nombre (puede devolver null)
            Usuario? usuario = UsuarioController.ObtenerUsuarioPorNombre(nombre);

            // Verifica si el usuario existe y si la contraseña coincide
            if (usuario != null && usuario.Contraseña == contraseña)
            {
                MessageBox.Show($" Bienvenido, {usuario.Nombre} ({usuario.Rol})", "Ingreso exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Oculta el formulario de login y muestra el formulario principal
                this.Hide();
                MainForm mainForm = new MainForm(usuario);
                mainForm.ShowDialog();

                // Vuelve al login si se cierra el formulario principal
                this.Show();
            }
            else
            {
                // Si los datos son incorrectos, muestra mensaje de error
                MessageBox.Show(" Nombre o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
