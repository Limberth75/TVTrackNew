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

        // Evento: al hacer clic en el botón "Cargar Recomendaciones"
        private void btnCargarRecomendaciones_Click(object sender, EventArgs e)
        {
            CargarRecomendaciones();
        }

        // Lógica principal: carga las recomendaciones y el historial
        private void CargarRecomendaciones()
        {
            lstRecomendaciones.Items.Clear();

            if (usuarioActual.Historial != null && usuarioActual.Historial.Count > 0)
            {
                // Género favorito
                string generoFavorito = Recomendador.ObtenerGeneroFavorito(usuarioActual);

                // Encabezado
                lstRecomendaciones.Items.Add($" Basado en tu historial, tu género favorito es: {generoFavorito}");
                lstRecomendaciones.Items.Add("");

                // Recomendaciones
                List<Contenido> recomendaciones = Recomendador.GenerarRecomendaciones(usuarioActual);

                if (recomendaciones != null && recomendaciones.Count > 0)
                {
                    lstRecomendaciones.Items.Add(" Recomendaciones personalizadas:");
                    foreach (var rec in recomendaciones)
                    {
                        lstRecomendaciones.Items.Add($" {rec.Titulo} - {rec.Categoria}");
                    }
                }
                else
                {
                    lstRecomendaciones.Items.Add(" No hay recomendaciones disponibles.");
                }

                // Mostrar historial del usuario
                lstRecomendaciones.Items.Add("");
                lstRecomendaciones.Items.Add(" Historial de visualización:");
                foreach (var item in usuarioActual.Historial)
                {
                    lstRecomendaciones.Items.Add($" {item.Titulo} - {item.Categoria}");
                }
            }
            else
            {
                lstRecomendaciones.Items.Add(" No se encontraron recomendaciones porque no tienes historial.");
            }
        }
    }
}
