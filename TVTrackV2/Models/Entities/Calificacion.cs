using System.ComponentModel.DataAnnotations;

namespace TVTrackV2.Models.Entities
{
    public class Calificacion
    {
        public int Id { get; set; }

        [Range(1, 5)]
        public int Puntuacion { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public int ContenidoId { get; set; }
        public Contenido Contenido { get; set; } = null!;
    }
}
