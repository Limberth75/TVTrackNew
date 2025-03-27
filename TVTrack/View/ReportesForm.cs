using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TVTrack.Controller;
using TVTrack.Model;

namespace TVTrack.View
{
    // Formulario que muestra reportes del sistema
    public partial class ReportesForm : Form
    {
        public ReportesForm()
        {
            InitializeComponent();
        }

        // Evento: cargar los reportes al hacer clic
        private void btnCargarReportes_Click(object sender, EventArgs e)
        {
            CargarReportes();
        }

        // Carga y muestra todos los reportes en la lista
        private void CargarReportes()
        {
            lstReportes.Items.Clear();

            List<Usuario> usuarios = UsuarioController.ObtenerUsuarios();
            List<Contenido> contenidos = ContenidoController.ObtenerContenido();

            // Totales generales
            lstReportes.Items.Add($"Total de usuarios registrados: {usuarios.Count}");
            lstReportes.Items.Add($"Total de contenido disponible: {contenidos.Count}");

            // Listado de usuarios
            lstReportes.Items.Add("---- Usuarios ----");
            foreach (var usuario in usuarios)
            {
                lstReportes.Items.Add($"👤 {usuario.Nombre} - {usuario.Email} - {usuario.Rol}");
            }

            // Listado de contenidos
            lstReportes.Items.Add("---- Contenido ----");
            foreach (var contenido in contenidos)
            {
                lstReportes.Items.Add($"🎬 {contenido.Titulo} - {contenido.Categoria}");
            }

            // --- MÉTRICAS ---

            lstReportes.Items.Add("---- Métricas ----");

            // 1. Contenido más visto
            var contenidoMasVisto = usuarios
                .SelectMany(u => u.Historial)
                .GroupBy(c => c.Titulo)
                .Select(g => new { Titulo = g.Key, Veces = g.Count() })
                .OrderByDescending(g => g.Veces)
                .FirstOrDefault();

            if (contenidoMasVisto != null)
            {
                lstReportes.Items.Add($"📺 Contenido más visto: {contenidoMasVisto.Titulo} ({contenidoMasVisto.Veces} veces)");
            }
            else
            {
                lstReportes.Items.Add("📺 Contenido más visto: No hay visualizaciones registradas.");
            }

            // 2. Género más popular
            var generoMasPopular = usuarios
                .SelectMany(u => u.Historial)
                .GroupBy(c => c.Categoria)
                .Select(g => new { Genero = g.Key, Veces = g.Count() })
                .OrderByDescending(g => g.Veces)
                .FirstOrDefault();

            if (generoMasPopular != null)
            {
                lstReportes.Items.Add($"🎞️ Género más popular: {generoMasPopular.Genero} ({generoMasPopular.Veces} visualizaciones)");
            }
            else
            {
                lstReportes.Items.Add("🎞️ Género más popular: No hay datos disponibles.");
            }

            // 3. Usuario más activo
            var usuarioMasActivo = usuarios
                .Select(u => new { Usuario = u.Nombre, Vistos = u.Historial.Count })
                .OrderByDescending(u => u.Vistos)
                .FirstOrDefault();

            if (usuarioMasActivo != null && usuarioMasActivo.Vistos > 0)
            {
                lstReportes.Items.Add($"🏆 Usuario más activo: {usuarioMasActivo.Usuario} ({usuarioMasActivo.Vistos} contenidos vistos)");
            }
            else
            {
                lstReportes.Items.Add("🏆 Usuario más activo: No hay actividad registrada.");
            }
        }
    }
}
