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
            if (usuarioActual.Rol == "Usuario")
            {
                btnReportes.Enabled = false;
                btnRegistrar.Enabled = false;
            }

            // SUSCRIPCIÓN al evento del patrón OBSERVER
            UsuarioController.UsuarioAgregado += OnUsuarioAgregado;

            // Verifica y genera usuarios si hay menos de 100
            int usuariosActuales = UsuarioController.ObtenerUsuarios().Count;
            if (usuariosActuales < 100)
            {
                UsuarioController.GenerarUsuariosAleatorios(100 - usuariosActuales);
            }
        }

        // OBSERVADOR: se ejecuta cuando se registra un nuevo usuario
        private void OnUsuarioAgregado()
        {
            MessageBox.Show("🔔 Se ha registrado un nuevo usuario.", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Evento: abrir formulario de registro (solo admins)
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (usuarioActual.Rol != "Administrador")
            {
                MessageBox.Show("Acceso denegado: solo administradores pueden registrar usuarios.", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RegistroForm registroForm = new RegistroForm(usuarioActual);
            registroForm.ShowDialog();

            // Solo actualiza el usuario actual si se registró uno nuevo
            if (registroForm.UsuarioRegistrado)
            {
                var usuarios = UsuarioController.ObtenerUsuarios();
                if (usuarios.Count > 0)
                {
                    usuarioActual = usuarios[^1]; // Último usuario registrado
                }
            }
        }

        // Evento: abrir recomendaciones (acceso libre)
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

        // Evento: abrir reportes (solo admins)
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

        // Evento: abrir formulario de contenido (acceso libre)
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

