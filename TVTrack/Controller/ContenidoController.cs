using System;
using System.Collections.Generic;
using TVTrack.Model;

namespace TVTrack.Controller
{
    public static class ContenidoController
    {
        private static List<Contenido> contenidos = new List<Contenido>();

        static ContenidoController()
        {
            CargarContenido();
        }

        public static void CargarContenido()
        {
            contenidos.Clear();

            string[] generos = { "Drama", "Comedia", "Acción", "Ciencia Ficción", "Terror", "Aventura", "Romance" };
            Random random = new Random();

            for (int i = 1; i <= 100; i++)
            {
                string titulo = $"Película {i}";
                string genero = generos[random.Next(generos.Length)];
                double calificacion = Math.Round(random.NextDouble() * 10, 1); // Genera una calificación entre 0 y 10

                Contenido nuevoContenido = new Contenido(titulo, genero, calificacion, false);
                contenidos.Add(nuevoContenido);
            }
        }

        public static List<Contenido> ObtenerContenido()
        {
            return contenidos;
        }
    }
}
