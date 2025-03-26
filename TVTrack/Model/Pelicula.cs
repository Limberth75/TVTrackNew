using System.Collections.Generic;

namespace TVTrack.Model
{
    // Clase que representa una película con su título, género y plataforma
    public class Pelicula
    {
        // Título de la película (Ej: "Inception", "Titanic")
        public string Titulo { get; set; }

        // Género de la película (Ej: Acción, Comedia, Drama)
        public string Genero { get; set; }

        // Plataforma donde está disponible (Ej: Netflix, HBO, Disney+)
        public string Plataforma { get; set; }

        // Constructor que inicializa una nueva instancia de Película
        public Pelicula(string titulo, string genero, string plataforma)
        {
            Titulo = titulo;
            Genero = genero;
            Plataforma = plataforma;
        }
    }
}
