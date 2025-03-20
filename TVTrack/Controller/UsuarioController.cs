using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TVTrack.Model;

namespace TVTrack.Controller
{
    public static class UsuarioController
    {
        private static List<Usuario> usuarios = CargarUsuarios();

        public static void AgregarUsuario(string nombre, string email, string contraseña, string rol)
        {
            Usuario nuevoUsuario = new Usuario(nombre, email, contraseña, rol);
            usuarios.Add(nuevoUsuario);
            GuardarUsuarios();
        }

        public static List<Usuario> ObtenerUsuarios()
        {
            return usuarios;
        }

        public static Usuario ObtenerUsuarioPorNombre(string nombre)
        {
            return usuarios.Find(u => u.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        public static void AgregarContenidoAHistorial(Usuario usuario, Contenido contenido)
        {
            if (usuario != null && contenido != null)
            {
                usuario.Historial.Add(contenido);
                GuardarUsuarios(); // Guarda los cambios en el historial del usuario
            }
        }

        public static void GenerarUsuariosAleatorios(int cantidad)
        {
            string[] nombres = { "Juan", "Ana", "Carlos", "Elena", "Miguel", "Sofia", "Pedro", "Lucia", "David", "Laura" };
            string[] apellidos = { "Gomez", "Perez", "Rodriguez", "Fernandez", "Lopez", "Martinez", "Garcia", "Sanchez" };
            string[] roles = { "Usuario", "Administrador" };
            Random random = new Random();

            for (int i = 0; i < cantidad; i++)
            {
                string nombreCompleto = $"{nombres[random.Next(nombres.Length)]} {apellidos[random.Next(apellidos.Length)]}";
                string correo = $"{nombreCompleto.Replace(" ", "").ToLower()}{random.Next(100, 999)}@mail.com";
                string contraseña = "password" + random.Next(1000, 9999);
                string rol = roles[random.Next(roles.Length)];

                if (usuarios.Exists(u => u.Email == correo))
                {
                    continue; // Evita duplicados
                }

                AgregarUsuario(nombreCompleto, correo, contraseña, rol);
            }
        }

        private static void GuardarUsuarios()
        {
            File.WriteAllText("usuarios.json", JsonConvert.SerializeObject(usuarios, Formatting.Indented));
        }

        private static List<Usuario> CargarUsuarios()
        {
            if (!File.Exists("usuarios.json")) return new List<Usuario>();
            string data = File.ReadAllText("usuarios.json");
            return JsonConvert.DeserializeObject<List<Usuario>>(data);
        }
    }
}
