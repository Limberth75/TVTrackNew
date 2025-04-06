using System.ComponentModel.DataAnnotations;

namespace TVTrackV2.Models.Entities
{
    public class Comentario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Texto { get; set; } = string.Empty;

        public DateTime Fecha { get; set; } = DateTime.Now;

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public int ContenidoId { get; set; }
        public Contenido Contenido { get; set; } = null!;
    }
}
