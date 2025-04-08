using System.ComponentModel.DataAnnotations;

namespace TVTrackII.Models
{
    public class Comentario
    {
        public int Id { get; set; }

        public string UsuarioId { get; set; } = "";
        public string Texto { get; set; } = "";
        public int Rating { get; set; }

        public int ContenidoId { get; set; }
        public Contenido? Contenido { get; set; }
    }
}
