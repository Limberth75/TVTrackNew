using System.Collections.Generic;


namespace TVTrack.Model
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }
        public List<Contenido> Historial { get; set; }

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
