using System;
using System.Windows.Forms;
using TVTrack.Controller;
using TVTrack.Model;

namespace TVTrack.View
{
    // Formulario principal que permite acceder a diferentes funcionalidades del sistema
    public partial class MainForm : Form
    {
        // Usuario actual en sesión
        private Usuario usuarioActual;

        // Constructor del formulario principal. Recibe el usuario autenticado desde el login.
        public MainForm(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;

            // Verifica si hay menos de 100 usuarios en total. Si hay menos, genera usuarios aleatorios.
            int usuariosActuales = UsuarioController.ObtenerUsuarios().Count;
            if (usuariosActuales < 100)
            {
                UsuarioController.GenerarUsuariosAleatorios(100 - usuariosActuales);
            }
        }

        // Evento: abre el formulario de registro de usuario
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistroForm registroForm = new RegistroForm();
            registroForm.ShowDialog();

            // Después del registro, se actualiza el usuario actual al último registrado
            var usuarios = UsuarioController.ObtenerUsuarios();
            if (usuarios.Count > 0)
            {
                usuarioActual = usuarios[^1]; // El último usuario agregado
            }
        }

        // Evento: abre el formulario de recomendaciones personalizadas para el usuario actual
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

        // Evento: abre el formulario de reportes (usuarios y géneros)
        private void btnReportes_Click(object sender, EventArgs e)
        {
            ReportesForm reportesForm = new ReportesForm();
            reportesForm.ShowDialog();
        }

        // Evento: abre el formulario de contenido, permitiendo agregarlo al historial del usuario
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
