namespace TVTrackII.Models
{
    public class Contenido
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public int DuracionMinutos { get; set; }
        public DateTime FechaEstreno { get; set; }
        public bool Disponible { get; set; }
    }
}
