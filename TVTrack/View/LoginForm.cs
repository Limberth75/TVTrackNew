using System;
using System.Windows.Forms;
using TVTrack.Controller;
using TVTrack.Model;

namespace TVTrack.View
{
    // Formulario de inicio de sesión del sistema
    public partial class LoginForm : Form
    {
        // Constructor del formulario: inicializa los componentes visuales
        public LoginForm()
        {
            InitializeComponent();
        }

        // Evento que se ejecuta al hacer clic en el botón "Iniciar sesión"
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Obtiene el nombre y la contraseña ingresados por el usuario
            string nombre = txtNombre.Text.Trim();
            string contraseña = txtContraseña.Text;

            // Busca al usuario por nombre usando el controlador
            Usuario usuario = UsuarioController.ObtenerUsuarioPorNombre(nombre);

            // Verifica si el usuario existe y si la contraseña es correcta
            if (usuario != null && usuario.Contraseña == contraseña)
            {
                // Muestra mensaje de bienvenida con nombre y rol del usuario
                MessageBox.Show($" Bienvenido, {usuario.Nombre} ({usuario.Rol})", "Ingreso exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Oculta el formulario de login y abre la ventana principal
                this.Hide();
                MainForm mainForm = new MainForm(usuario);
                mainForm.ShowDialog();

                // Vuelve a mostrar el formulario de login cuando se cierra el principal
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
