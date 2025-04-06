namespace TVTrackV2.Models.Entities
{
    public class HistorialVisualizacion
    {
        public int Id { get; set; }

        public DateTime FechaVisualizacion { get; set; } = DateTime.Now;

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public int ContenidoId { get; set; }
        public Contenido Contenido { get; set; } = null!;
    }
}
