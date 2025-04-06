using System.ComponentModel.DataAnnotations;

namespace TVTrackV2.Models.Entities
{
    public class Contenido
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public string Categoria { get; set; } = string.Empty;

        [Required]
        public string Plataforma { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Descripcion { get; set; }

        public DateTime FechaEstreno { get; set; }

        public int DuracionMinutos { get; set; }

        public bool Disponible { get; set; }

        public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
        public ICollection<Calificacion> Calificaciones { get; set; } = new List<Calificacion>();
        public ICollection<HistorialVisualizacion> Historiales { get; set; } = new List<HistorialVisualizacion>();
    }
}
