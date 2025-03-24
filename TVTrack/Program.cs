using System;
using System.Windows.Forms;
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

            // Iniciar desde el formulario de login
            Application.Run(new LoginForm());
        }
    }
}
