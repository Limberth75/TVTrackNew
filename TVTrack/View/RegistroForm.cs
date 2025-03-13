using System;
using System.Windows.Forms;
using TVTrack.Controller;
using TVTrack.Model;

namespace TVTrack.View
{
    public partial class RegistroForm : Form
    {
        public RegistroForm()
        {
            InitializeComponent();
            cmbRol.Items.Add("Usuario");
            cmbRol.Items.Add("Administrador");
            cmbRol.SelectedIndex = 0; // Selecciona "Usuario" por defecto
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string email = txtEmail.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();
            string rol = cmbRol.SelectedItem.ToString(); // Obtiene el rol seleccionado

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("❌ Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("❌ Ingresa un email válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UsuarioController.AgregarUsuario(nombre, email, contraseña, rol);
            MessageBox.Show($"✅ Usuario {nombre} registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
