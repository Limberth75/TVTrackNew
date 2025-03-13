using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TVTrack.Controller;
using TVTrack.Model;

namespace TVTrack.View
{
    public partial class ReportesForm : Form
    {
        public ReportesForm()
        {
            InitializeComponent();
        }

        private void btnCargarReportes_Click(object sender, EventArgs e)
        {
            CargarReportes();
        }

        private void CargarReportes()
        {
            lstReportes.Items.Clear();

            List<Usuario> usuarios = UsuarioController.ObtenerUsuarios();
            List<Contenido> contenidos = ContenidoController.ObtenerContenido();

            lstReportes.Items.Add($"Total de usuarios registrados: {usuarios.Count}");
            lstReportes.Items.Add($"Total de contenido disponible: {contenidos.Count}");

            lstReportes.Items.Add("---- Usuarios ----");
            foreach (var usuario in usuarios)
            {
                lstReportes.Items.Add($"👤 {usuario.Nombre} - {usuario.Email} - {usuario.Rol}");
            }

            lstReportes.Items.Add("---- Contenido ----");
            foreach (var contenido in contenidos)
            {
                lstReportes.Items.Add($"🎬 {contenido.Titulo} - {contenido.Categoria}");
            }
        }
    }
}
