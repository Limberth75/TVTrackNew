namespace TVTrackII.Models
{
    public class Calificacion
    {
        public int Id { get; set; }
        public int ContenidoId { get; set; }
        public int Puntuacion { get; set; } // Entre 1 y 5

        public Contenido? Contenido { get; set; }
    }
}
