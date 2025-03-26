using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TVTrack.Controller;
using TVTrack.Model;

namespace TVTrack.View
{
    // Formulario que muestra recomendaciones de contenido para el usuario actual
    public partial class RecomendacionesForm : Form
    {
        // Usuario activo que recibe las recomendaciones
        private Usuario usuarioActual;

        // Constructor: recibe el usuario actual y guarda la referencia
        public RecomendacionesForm(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        // Carga y muestra las recomendaciones en el ListBox
        private void CargarRecomendaciones()
        {
            lstRecomendaciones.Items.Clear();

            // Si el usuario tiene historial, se generan recomendaciones
            if (usuarioActual.Historial.Count > 0)
            {
                List<Contenido> recomendaciones = Recomendador.GenerarRecomendaciones(usuarioActual);

                // Si hay recomendaciones, se muestran en la lista
                if (recomendaciones != null && recomendaciones.Count > 0)
                {
                    foreach (var rec in recomendaciones)
                    {
                        lstRecomendaciones.Items.Add($"{rec.Titulo} - {rec.Categoria}");
                    }
                }
                else
                {
                    // Si no hay recomendaciones (aunque haya historial)
                    lstRecomendaciones.Items.Add("No hay recomendaciones disponibles.");
                }
            }
            else
            {
                // Si el usuario no tiene historial
                lstRecomendaciones.Items.Add("No hay historial de visualización.");
            }
        }

        // Evento: se ejecuta al hacer clic en el botón "Cargar Recomendaciones"
        private void btnCargarRecomendaciones_Click(object sender, EventArgs e)
        {
            CargarRecomendaciones();
        }
    }
}
