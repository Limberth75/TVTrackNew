using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TVTrack.Model;
using TVTrack.Controller;

namespace TVTrack.View
{
    public partial class ContenidoForm : Form
    {
        private Usuario usuarioActual;
        private List<Contenido> listaContenido;

        public ContenidoForm(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            CargarContenido();
        }

        private void CargarContenido()
        {
            listaContenido = ContenidoController.ObtenerContenido();
            if (listaContenido.Count == 0)
            {
                MessageBox.Show("No hay contenido disponible. Se generarán automáticamente 100 registros.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ContenidoController.CargarContenido();
                listaContenido = ContenidoController.ObtenerContenido();
            }
            ActualizarListaContenido(listaContenido);
        }

        private void ActualizarListaContenido(List<Contenido> contenidoFiltrado)
        {
            lstContenido.Items.Clear();
            foreach (var contenido in contenidoFiltrado)
            {
                lstContenido.Items.Add($"{contenido.Titulo} - {contenido.Categoria} - {contenido.Calificacion}/10");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text.Trim().ToLower();
            var contenidoFiltrado = listaContenido.Where(c =>
                c.Titulo.ToLower().Contains(busqueda) ||
                c.Categoria.ToLower().Contains(busqueda)).ToList();

            if (contenidoFiltrado.Count == 0)
            {
                MessageBox.Show("No se encontraron coincidencias.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ActualizarListaContenido(contenidoFiltrado);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (lstContenido.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un contenido para agregar a su historial.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Contenido contenidoSeleccionado = listaContenido[lstContenido.SelectedIndex];
            UsuarioController.AgregarContenidoAHistorial(usuarioActual, contenidoSeleccionado);
            MessageBox.Show($"Contenido '{contenidoSeleccionado.Titulo}' agregado a tu historial.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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
            MessageBox.Show($"Contenido '{contenidoSeleccionado.Titulo}' eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
