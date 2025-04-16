using System.Collections.Generic;
using TVTrackII.Models;

public class Contenido
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int VecesVisto { get; set; }

    public ICollection<HistorialVisualizacion> Historiales { get; set; }
}
