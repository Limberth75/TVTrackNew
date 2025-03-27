using System;
using System.Windows.Forms;
using TVTrack.Controller;
using TVTrack.Model;

namespace TVTrack.View
{
    // Formulario para registrar un nuevo usuario
    public partial class RegistroForm : Form
    {
        private Usuario? usuarioActual;

        // Indica si se registró un usuario nuevo (usado por MainForm)
        public bool UsuarioRegistrado { get; private set; } = false;

        // Constructor: recibe opcionalmente el usuario actual para control de rol
        public RegistroForm(Usuario? usuario = null)
        {
            InitializeComponent();
            usuarioActual = usuario;

            // Validación de rol: solo permite acceso a administradores
            if (usuarioActual != null && usuarioActual.Rol != "Administrador")
            {
                MessageBox.Show("Acceso denegado: solo administradores pueden registrar usuarios.", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Cargar roles en ComboBox
            cmbRol.Items.Add("Usuario");
            cmbRol.Items.Add("Administrador");
            cmbRol.SelectedIndex = 0;
        }

        // Evento: guarda el nuevo usuario
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string email = txtEmail.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();
            string rol = cmbRol.SelectedItem?.ToString() ?? "Usuario";

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show(" Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show(" Ingresa un email válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Registrar usuario y marcar que se registró
            UsuarioController.AgregarUsuario(nombre, email, contraseña, rol);
            UsuarioRegistrado = true;

            MessageBox.Show($" Usuario {nombre} registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
