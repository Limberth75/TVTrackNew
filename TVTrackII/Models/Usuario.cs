﻿namespace TVTrackII.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;

        // Nuevas propiedades
        public string Contrasena { get; set; } = string.Empty;
        public string Rol { get; set; } = "Usuario"; // "Usuario" o "Administrador"
    }
}
