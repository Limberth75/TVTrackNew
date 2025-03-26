using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TVTrack.Controller;
using TVTrack.Model;

namespace TVTrack.View
{
    // Formulario que muestra reportes de usuarios y contenidos del sistema
    public partial class ReportesForm : Form
    {
        // Constructor: inicializa los componentes del formulario
        public ReportesForm()
        {
            InitializeComponent();
        }

        // Evento: se ejecuta al hacer clic en el botón "Cargar Reportes"
        private void btnCargarReportes_Click(object sender, EventArgs e)
        {
            CargarReportes();
        }

        // Carga y muestra en pantalla la información de usuarios y contenidos
        private void CargarReportes()
        {
            lstReportes.Items.Clear(); // Limpia la lista visual antes de mostrar los nuevos datos

            // Obtiene listas actualizadas de usuarios y contenido
            List<Usuario> usuarios = UsuarioController.ObtenerUsuarios();
            List<Contenido> contenidos = ContenidoController.ObtenerContenido();

            // Muestra totales generales
            lstReportes.Items.Add($"Total de usuarios registrados: {usuarios.Count}");
            lstReportes.Items.Add($"Total de contenido disponible: {contenidos.Count}");

            // Sección de usuarios
            lstReportes.Items.Add("---- Usuarios ----");
            foreach (var usuario in usuarios)
            {
                lstReportes.Items.Add($"{usuario.Nombre} - {usuario.Email} - {usuario.Rol}");
            }

            // Sección de contenido
            lstReportes.Items.Add("---- Contenido ----");
            foreach (var contenido in contenidos)
            {
                lstReportes.Items.Add($"{contenido.Titulo} - {contenido.Categoria}");
            }
        }
    }
}
