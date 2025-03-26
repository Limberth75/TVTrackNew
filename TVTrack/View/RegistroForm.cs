using System;
using System.Windows.Forms;
using TVTrack.Controller;
using TVTrack.Model;

namespace TVTrack.View
{
    // Formulario para registrar un nuevo usuario en el sistema
    public partial class RegistroForm : Form
    {
        // Constructor: inicializa los componentes y carga los roles disponibles
        public RegistroForm()
        {
            InitializeComponent();

            // Agrega opciones al ComboBox de roles
            cmbRol.Items.Add("Usuario");
            cmbRol.Items.Add("Administrador");

            // Selecciona "Usuario" por defecto
            cmbRol.SelectedIndex = 0;
        }

        // Evento: se ejecuta al hacer clic en el botón "Guardar"
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtiene los datos ingresados por el usuario
            string nombre = txtNombre.Text.Trim();
            string email = txtEmail.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            // Verifica que haya una selección válida en el ComboBox y la convierte a string
            string rol = cmbRol.SelectedItem?.ToString() ?? "Usuario"; // ← Aquí resolvemos los 3 warnings

            // Validación: todos los campos son obligatorios
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show(" Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación: formato básico del email
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show(" Ingresa un email válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Agrega el nuevo usuario usando el controlador
            UsuarioController.AgregarUsuario(nombre, email, contraseña, rol);

            // Muestra mensaje de éxito y cierra el formulario
            MessageBox.Show($" Usuario {nombre} registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
