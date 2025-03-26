using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json; // Librería externa para manejo de JSON
using TVTrack.Model;

namespace TVTrack.Controller
{
    // Clase estática que maneja la lógica relacionada con usuarios
    public static class UsuarioController
    {
        // Lista de usuarios cargada desde archivo JSON al iniciar
        private static List<Usuario> usuarios = CargarUsuarios();

        // Agrega un nuevo usuario a la lista y guarda los cambios en el archivo
        public static void AgregarUsuario(string nombre, string email, string contraseña, string rol)
        {
            Usuario nuevoUsuario = new Usuario(nombre, email, contraseña, rol);
            usuarios.Add(nuevoUsuario);
            GuardarUsuarios(); // Guarda todos los usuarios en el archivo JSON
        }

        // Devuelve la lista completa de usuarios
        public static List<Usuario> ObtenerUsuarios()
        {
            return usuarios;
        }

        // Busca un usuario por nombre (sin importar mayúsculas/minúsculas)
        public static Usuario ObtenerUsuarioPorNombre(string nombre)
        {
            return usuarios.Find(u => u.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        // Agrega un contenido al historial de un usuario y guarda los cambios
        public static void AgregarContenidoAHistorial(Usuario usuario, Contenido contenido)
        {
            if (usuario != null && contenido != null)
            {
                usuario.Historial.Add(contenido);
                GuardarUsuarios(); // Guarda el nuevo historial del usuario
            }
        }

        // Genera una cantidad de usuarios aleatorios para pruebas o demostración
        public static void GenerarUsuariosAleatorios(int cantidad)
        {
            // Datos base para crear nombres y roles aleatorios
            string[] nombres = { "Juan", "Ana", "Carlos", "Elena", "Miguel", "Sofia", "Pedro", "Lucia", "David", "Laura" };
            string[] apellidos = { "Gomez", "Perez", "Rodriguez", "Fernandez", "Lopez", "Martinez", "Garcia", "Sanchez" };
            string[] roles = { "Usuario", "Administrador" };
            Random random = new Random();

            for (int i = 0; i < cantidad; i++)
            {
                // Genera nombre, correo, contraseña y rol aleatorio
                string nombreCompleto = $"{nombres[random.Next(nombres.Length)]} {apellidos[random.Next(apellidos.Length)]}";
                string correo = $"{nombreCompleto.Replace(" ", "").ToLower()}{random.Next(100, 999)}@mail.com";
                string contraseña = "password" + random.Next(1000, 9999);
                string rol = roles[random.Next(roles.Length)];

                // Evita agregar usuarios duplicados por correo
                if (usuarios.Exists(u => u.Email == correo))
                {
                    continue;
                }

                // Agrega el nuevo usuario a la lista
                AgregarUsuario(nombreCompleto, correo, contraseña, rol);
            }
        }

        // Guarda todos los usuarios en un archivo JSON local
        private static void GuardarUsuarios()
        {
            File.WriteAllText("usuarios.json", JsonConvert.SerializeObject(usuarios, Formatting.Indented));
        }

        // Carga los usuarios desde el archivo JSON si existe; si no, devuelve una lista vacía
        private static List<Usuario> CargarUsuarios()
        {
            if (!File.Exists("usuarios.json")) return new List<Usuario>();

            string data = File.ReadAllText("usuarios.json");
            return JsonConvert.DeserializeObject<List<Usuario>>(data);
        }
    }
}
