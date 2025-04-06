using System.Collections.Generic;

namespace TVTrack.Model
{
    public class Contenido
    {
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public double Calificacion { get; set; }
        public bool Disponible { get; set; }

        public Contenido() { }

        public Contenido(string titulo, string categoria, double calificacion, bool disponible)
        {
            Titulo = titulo;
            Categoria = categoria;
            Calificacion = calificacion;
            Disponible = disponible;
        }
    }
}
