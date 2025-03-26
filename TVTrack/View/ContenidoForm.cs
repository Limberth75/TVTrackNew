using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TVTrack.Model;
using TVTrack.Controller;

namespace TVTrack.View
{
    // Formulario que permite al usuario explorar, buscar y gestionar contenido
    public partial class ContenidoForm : Form
    {
        // Usuario actualmente activo en la sesión
        private Usuario usuarioActual;

        // Lista completa del contenido cargado
        private List<Contenido> listaContenido;

        // Constructor del formulario: recibe el usuario actual y carga el contenido
        public ContenidoForm(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            CargarContenido();
        }

        // Carga el contenido desde el controlador. Si no hay ninguno, genera automáticamente 100 registros.
        private void CargarContenido()
        {
            listaContenido = ContenidoController.ObtenerContenido();

            if (listaContenido.Count == 0)
            {
                MessageBox.Show(
                    "No hay contenido disponible. Se generarán automáticamente 100 registros.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ContenidoController.CargarContenido();
                listaContenido = ContenidoController.ObtenerContenido();
            }

            ActualizarListaContenido(listaContenido);
        }

        // Actualiza visualmente la lista mostrada en el ListBox con contenido (filtrado o completo)
        private void ActualizarListaContenido(List<Contenido> contenidoFiltrado)
        {
            lstContenido.Items.Clear();

            foreach (var contenido in contenidoFiltrado)
            {
                lstContenido.Items.Add($"{contenido.Titulo} - {contenido.Categoria} - {contenido.Calificacion}/10");
            }
        }

        // Evento: busca contenido según el texto ingresado en el cuadro de búsqueda
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text.Trim().ToLower();

            var contenidoFiltrado = listaContenido.Where(c =>
                c.Titulo.ToLower().Contains(busqueda) ||
                c.Categoria.ToLower().Contains(busqueda)
            ).ToList();

            if (contenidoFiltrado.Count == 0)
            {
                MessageBox.Show("No se encontraron coincidencias.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ActualizarListaContenido(contenidoFiltrado);
        }

        // Evento: agrega el contenido seleccionado al historial del usuario actual
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (lstContenido.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un contenido para agregar a su historial.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Contenido contenidoSeleccionado = listaContenido[lstContenido.SelectedIndex];

            UsuarioController.AgregarContenidoAHistorial(usuarioActual, contenidoSeleccionado);

            MessageBox.Show(
                $"Contenido '{contenidoSeleccionado.Titulo}' agregado a tu historial.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // Evento: elimina el contenido seleccionado solo de la lista actual (no del sistema global)
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstContenido.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un contenido para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Contenido contenidoSeleccionado = listaContenido[lstContenido.SelectedIndex];
            listaContenido.Remove(contenidoSeleccionado);

            ActualizarListaContenido(listaContenido);

            MessageBox.Show(
                $"Contenido '{contenidoSeleccionado.Titulo}' eliminado.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
