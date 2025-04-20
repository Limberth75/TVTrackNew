using System;
using System.ComponentModel.DataAnnotations;

namespace TVTrackII.Models
{
    public class Comentario
    {
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int ContenidoId { get; set; }

        [Required]
        [StringLength(500)]
        public string Texto { get; set; } = string.Empty;

        public DateTime Fecha { get; set; } = DateTime.Now;

        // Relaciones
        public Usuario Usuario { get; set; } = null!;
        public Contenido Contenido { get; set; } = null!;
    }
}
