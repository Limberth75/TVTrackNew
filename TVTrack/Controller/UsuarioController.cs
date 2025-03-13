using System.Collections.Generic;
using System.Linq;
using TVTrack.Model;

namespace TVTrack.Controller
{
    public static class UsuarioController
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        public static void AgregarUsuario(string nombre, string email, string contraseña, string rol)
        {
            Usuario nuevoUsuario = new Usuario(nombre, email, contraseña, rol);
            usuarios.Add(nuevoUsuario);
        }

        public static List<Usuario> ObtenerUsuarios()
        {
            return usuarios;
        }

        public static Usuario ObtenerUsuarioPorNombre(string nombre)
        {
            return usuarios.FirstOrDefault(u => u.Nombre == nombre);
        }

        // ✅ **Nuevo método para agregar contenido al historial del usuario**
        public static void AgregarContenidoAHistorial(Usuario usuario, Contenido contenido)
        {
            if (usuario != null && contenido != null)
            {
                usuario.Historial.Add(contenido);
            }
        }
    }
}
