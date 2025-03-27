using System;
using System.Windows.Forms;
using TVTrack.Controller;
using TVTrack.Model;

namespace TVTrack.View
{
    // Formulario principal que permite acceder a las funcionalidades del sistema
    public partial class MainForm : Form
    {
        // Usuario que inició sesión
        private Usuario usuarioActual;

        // Constructor que recibe el usuario autenticado
        public MainForm(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;

            // Control de acceso según rol
            // Si el usuario es solo "Usuario", se restringen funcionalidades
            if (usuarioActual.Rol == "Usuario")
            {
                btnReportes.Enabled = false;   // Desactiva botón de reportes
                btnRegistrar.Enabled = false;  // Desactiva botón de registro
            }

            // Verifica y genera usuarios si hay menos de 100
            int usuariosActuales = UsuarioController.ObtenerUsuarios().Count;
            if (usuariosActuales < 100)
            {
                UsuarioController.GenerarUsuariosAleatorios(100 - usuariosActuales);
            }
        }

        // Evento: abre el formulario de registro de usuario (solo admins)
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (usuarioActual.Rol != "Administrador")
            {
                MessageBox.Show("Acceso denegado: solo administradores pueden registrar usuarios.", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pasa el usuario actual para validar rol dentro del formulario
            RegistroForm registroForm = new RegistroForm(usuarioActual);
            registroForm.ShowDialog();

            // Solo actualiza si se registró un nuevo usuario
            if (registroForm.UsuarioRegistrado)
            {
                var usuarios = UsuarioController.ObtenerUsuarios();
                if (usuarios.Count > 0)
                {
                    usuarioActual = usuarios[^1]; // Último usuario agregado
                }
            }
        }

        // Evento: abre el formulario de recomendaciones (acceso libre)
        private void btnRecomendaciones_Click(object sender, EventArgs e)
        {
            if (usuarioActual == null)
            {
                MessageBox.Show("Debe registrar un usuario antes de ver recomendaciones.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RecomendacionesForm recomendacionesForm = new RecomendacionesForm(usuarioActual);
            recomendacionesForm.ShowDialog();
        }

        // Evento: abre el formulario de reportes (solo admins)
        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (usuarioActual.Rol != "Administrador")
            {
                MessageBox.Show("Acceso denegado: solo administradores pueden ver reportes.", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ReportesForm reportesForm = new ReportesForm();
            reportesForm.ShowDialog();
        }

        // Evento: abre el formulario de contenido (acceso libre)
        private void btnContenido_Click(object sender, EventArgs e)
        {
            if (usuarioActual == null)
            {
                MessageBox.Show("Debe registrar un usuario antes de ver contenido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ContenidoForm contenidoForm = new ContenidoForm(usuarioActual);
            contenidoForm.ShowDialog();
        }
    }
}
