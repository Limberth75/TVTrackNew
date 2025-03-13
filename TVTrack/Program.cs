using System;
using System.Windows.Forms;
using TVTrack.Controller;
using TVTrack.Model;
using TVTrack.View;

namespace TVTrack
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Cargar un usuario de prueba para evitar errores
            Usuario usuarioInicial = new Usuario("Administrador", "admin@example.com", "admin123", "Admin");

            Application.Run(new MainForm(usuarioInicial));
        }
    }
}
