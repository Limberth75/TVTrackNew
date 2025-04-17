using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVTrackII.Models
{
    public class HistorialVisualizacion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int ContenidoId { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }

        [ForeignKey("ContenidoId")]
        public Contenido? Contenido { get; set; }
    }
}
