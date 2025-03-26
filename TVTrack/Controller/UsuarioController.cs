using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TVTrack.Model;

namespace TVTrack.Controller
{
    // Controlador encargado de gestionar usuarios del sistema
    public static class UsuarioController
    {
        // Lista interna de usuarios cargada desde archivo JSON
        private static List<Usuario> usuarios = CargarUsuarios();

        // Agrega un nuevo usuario y guarda la lista actualizada
        public static void AgregarUsuario(string nombre, string email, string contraseña, string rol)
        {
            Usuario nuevoUsuario = new Usuario(nombre, email, contraseña, rol);
            usuarios.Add(nuevoUsuario);
            GuardarUsuarios();
        }

        // Devuelve la lista de todos los usuarios
        public static List<Usuario> ObtenerUsuarios()
        {
            return usuarios;
        }

        // Busca y devuelve un usuario por nombre (retorna null si no lo encuentra)
        public static Usuario? ObtenerUsuarioPorNombre(string nombre)
        {
            return usuarios.Find(u => u.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        // Agrega contenido al historial de un usuario específico
        public static void AgregarContenidoAHistorial(Usuario usuario, Contenido contenido)
        {
            if (usuario != null && contenido != null)
            {
                usuario.Historial.Add(contenido);
                GuardarUsuarios(); // Guarda cambios en el archivo
            }
        }

        // Genera una cantidad de usuarios aleatorios (sin duplicados por email)
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

                // Evita usuarios duplicados por correo
                if (usuarios.Exists(u => u.Email == correo))
                {
                    continue;
                }

                AgregarUsuario(nombreCompleto, correo, contraseña, rol);
            }
        }

        // Guarda los usuarios en archivo JSON
        private static void GuardarUsuarios()
        {
            File.WriteAllText("usuarios.json", JsonConvert.SerializeObject(usuarios, Formatting.Indented));
        }

        // Carga los usuarios desde el archivo JSON (o devuelve lista vacía si no existe)
        private static List<Usuario> CargarUsuarios()
        {
            if (!File.Exists("usuarios.json"))
                return new List<Usuario>();

            string data = File.ReadAllText("usuarios.json");
            return JsonConvert.DeserializeObject<List<Usuario>>(data) ?? new List<Usuario>(); // ← importante para evitar null
        }
    }
}
