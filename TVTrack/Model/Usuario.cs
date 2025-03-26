using System.Collections.Generic;

namespace TVTrack.Model
{
    // Clase que representa a un usuario del sistema
    public class Usuario
    {
        // Nombre del usuario (Ej: "Juan Pérez")
        public string Nombre { get; set; }

        // Correo electrónico del usuario
        public string Email { get; set; }

        // Contraseña del usuario (almacenada en texto plano, se recomienda cifrar en producción)
        public string Contraseña { get; set; }

        // Rol del usuario (Ej: "Usuario", "Administrador")
        public string Rol { get; set; }

        // Historial de contenidos vistos por el usuario
        public List<Contenido> Historial { get; set; }

        // Constructor que inicializa los datos del usuario y crea un historial vacío
        public Usuario(string nombre, string email, string contraseña, string rol)
        {
            Nombre = nombre;
            Email = email;
            Contraseña = contraseña;
            Rol = rol;
            Historial = new List<Contenido>();
        }
    }
}
