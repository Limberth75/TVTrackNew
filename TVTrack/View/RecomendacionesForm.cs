using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TVTrack.Controller;
using TVTrack.Model;

namespace TVTrack.View
{
    // Formulario que muestra recomendaciones de contenido personalizadas
    public partial class RecomendacionesForm : Form
    {
        private Usuario usuarioActual;

        public RecomendacionesForm(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        // Evento: se ejecuta al hacer clic en el botón de cargar recomendaciones
        private void btnCargarRecomendaciones_Click(object sender, EventArgs e)
        {
            CargarRecomendaciones();
        }

        // Carga las recomendaciones y las muestra en el ListBox
        private void CargarRecomendaciones()
        {
            lstRecomendaciones.Items.Clear();

            // Validar que el usuario tenga historial
            if (usuarioActual.Historial != null && usuarioActual.Historial.Count > 0)
            {
                // Obtener género favorito
                string generoFavorito = Recomendador.ObtenerGeneroFavorito(usuarioActual);

                // Mostrar encabezado
                lstRecomendaciones.Items.Add($" Basado en tu historial, tu género favorito es: {generoFavorito}");
                lstRecomendaciones.Items.Add("");

                // Generar recomendaciones
                List<Contenido> recomendaciones = Recomendador.GenerarRecomendaciones(usuarioActual);

                if (recomendaciones != null && recomendaciones.Count > 0)
                {
                    foreach (var rec in recomendaciones)
                    {
                        lstRecomendaciones.Items.Add($" {rec.Titulo} - {rec.Categoria}");
                    }
                }
                else
                {
                    lstRecomendaciones.Items.Add(" No hay recomendaciones disponibles.");
                }
            }
            else
            {
                lstRecomendaciones.Items.Add(" Tu historial está vacío. Ve contenido para obtener recomendaciones.");
            }
        }
    }
}
