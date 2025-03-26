using System;
using System.Collections.Generic;
using TVTrack.Model;

namespace TVTrack.Controller
{
    // Clase estática que gestiona el contenido disponible (películas, series, etc.)
    public static class ContenidoController
    {
        // Lista privada que almacena todo el contenido generado
        private static List<Contenido> contenidos = new List<Contenido>();

        // Constructor estático: se ejecuta automáticamente la primera vez que se usa la clase
        static ContenidoController()
        {
            CargarContenido(); // Inicializa la lista con contenido generado aleatoriamente
        }

        // Método que llena la lista 'contenidos' con 100 elementos aleatorios
        public static void CargarContenido()
        {
            contenidos.Clear(); // Limpia la lista antes de llenarla

            // Lista de géneros posibles
            string[] generos = { "Drama", "Comedia", "Acción", "Ciencia Ficción", "Terror", "Aventura", "Romance" };
            Random random = new Random(); // Generador de números aleatorios

            for (int i = 1; i <= 100; i++)
            {
                string titulo = $"Película {i}"; // Título tipo "Película 1", "Película 2", etc.
                string genero = generos[random.Next(generos.Length)]; // Género aleatorio
                double calificacion = Math.Round(random.NextDouble() * 10, 1); // Calificación entre 0.0 y 10.0

                // Crea un nuevo contenido y lo agrega a la lista
                Contenido nuevoContenido = new Contenido(titulo, genero, calificacion, false);
                contenidos.Add(nuevoContenido);
            }
        }

        // Devuelve la lista completa de contenido generado
        public static List<Contenido> ObtenerContenido()
        {
            return contenidos;
        }
    }
}
