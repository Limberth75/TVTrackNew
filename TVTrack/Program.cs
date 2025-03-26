using System;
using System.Windows.Forms;
using TVTrack.View;

namespace TVTrack
{
    // Clase principal que contiene el punto de entrada de la aplicaci�n
    internal static class Program
    {
        // M�todo Main: se ejecuta al iniciar el programa
        [STAThread]
        static void Main()
        {
            // Habilita estilos visuales para los controles de Windows Forms
            Application.EnableVisualStyles();

            // Usa compatibilidad para el renderizado de texto en formularios
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia la aplicaci�n mostrando primero el formulario de login
            Application.Run(new LoginForm());
        }
    }
}
