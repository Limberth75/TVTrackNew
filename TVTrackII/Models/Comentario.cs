using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVTrackII.Models
{
    public class Comentario
    {
        public int Id { get; set; }

        [Required]
        public string Texto { get; set; } = string.Empty;

        public DateTime Fecha { get; set; } = DateTime.Now;

        // Relaciones
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [ForeignKey("Contenido")]
        public int ContenidoId { get; set; }
        public Contenido Contenido { get; set; }
    }
}
