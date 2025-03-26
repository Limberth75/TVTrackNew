using System;

namespace TVTrack.Model
{
    // Clase que representa un contenido multimedia (como una película o serie)
    public class Contenido
    {
        // Título del contenido (ej: "Breaking Bad", "Avengers")
        public string Titulo { get; set; }

        // Categoría o género del contenido (ej: "Drama", "Acción")
        public string Categoria { get; set; }

        // Calificación del contenido (entre 0.0 y 10.0, por ejemplo)
        public double Calificacion { get; set; }

        // Indica si el contenido está disponible actualmente en la plataforma
        public bool Disponible { get; set; }

        // Constructor que inicializa todos los campos al crear un nuevo contenido
        public Contenido(string titulo, string categoria, double calificacion, bool disponible)
        {
            Titulo = titulo;
            Categoria = categoria;
            Calificacion = calificacion;
            Disponible = disponible;
        }
    }
}
