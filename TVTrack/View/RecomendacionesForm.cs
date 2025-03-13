using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TVTrack.Controller;
using TVTrack.Model;

namespace TVTrack.View
{
    public partial class RecomendacionesForm : Form
    {
        private Usuario usuarioActual;

        public RecomendacionesForm(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            CargarRecomendaciones();
        }

        private void CargarRecomendaciones()
        {
            lstRecomendaciones.Items.Clear();

            if (usuarioActual.Historial.Count > 0)
            {
                List<Contenido> recomendaciones = Recomendador.GenerarRecomendaciones(usuarioActual);

                if (recomendaciones != null && recomendaciones.Count > 0)
                {
                    foreach (var rec in recomendaciones)
                    {
                        lstRecomendaciones.Items.Add($"{rec.Titulo} - {rec.Categoria}");
                    }
                }
                else
                {
                    lstRecomendaciones.Items.Add("No hay recomendaciones disponibles.");
                }
            }
            else
            {
                lstRecomendaciones.Items.Add("No hay historial de visualización.");
            }
        }

        private void btnCargarRecomendaciones_Click(object sender, EventArgs e)
        {
            CargarRecomendaciones();
        }
    }
}
