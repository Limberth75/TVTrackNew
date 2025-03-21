﻿using System;
using System.Windows.Forms;
using TVTrack.Controller;
using TVTrack.Model;

namespace TVTrack.View
{
    public partial class MainForm : Form
    {
        private Usuario usuarioActual;

        public MainForm(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;

            // Verifica si hay menos de 100 usuarios y genera los que faltan
            int usuariosActuales = UsuarioController.ObtenerUsuarios().Count;
            if (usuariosActuales < 100)
            {
                UsuarioController.GenerarUsuariosAleatorios(100 - usuariosActuales);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistroForm registroForm = new RegistroForm();
            registroForm.ShowDialog();

            var usuarios = UsuarioController.ObtenerUsuarios();
            if (usuarios.Count > 0)
            {
                usuarioActual = usuarios[^1];
            }
        }

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

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ReportesForm reportesForm = new ReportesForm();
            reportesForm.ShowDialog();
        }

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
