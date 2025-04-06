using System.ComponentModel.DataAnnotations;

namespace TVTrackV2.Models.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Contraseña { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^(usuario|admin)$", ErrorMessage = "Rol inválido.")]
        public string Rol { get; set; } = "usuario";

        public ICollection<HistorialVisualizacion> Historial { get; set; } = new List<HistorialVisualizacion>();
        public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
        public ICollection<Calificacion> Calificaciones { get; set; } = new List<Calificacion>();
    }
}
