using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVTrackII.Models
{
    public class HistorialVisualizacion
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int ContenidoId { get; set; }
        public Contenido Contenido { get; set; }

        public DateTime FechaVisualizacion { get; set; }  // <- Esta propiedad es crucial
    }
}
