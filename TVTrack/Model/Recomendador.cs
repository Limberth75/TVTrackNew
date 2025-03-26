using System.Collections.Generic;
using System.Linq;
using TVTrack.Model;

namespace TVTrack.Controller
{
    // Clase estática encargada de generar recomendaciones de contenido para los usuarios
    public static class Recomendador
    {
        // Genera una lista de recomendaciones basadas en el historial del usuario
        public static List<Contenido> GenerarRecomendaciones(Usuario usuario)
        {
            // Si el usuario no ha visto ningún contenido, no se puede generar una recomendación personalizada
            if (usuario.Historial.Count == 0)
            {
                return new List<Contenido>();
            }

            // Determina el género más frecuente en el historial del usuario
            string generoFavorito = usuario.Historial
                .GroupBy(c => c.Categoria)            // Agrupa los contenidos por categoría
                .OrderByDescending(g => g.Count())    // Ordena los grupos por cantidad de veces vistos
                .Select(g => g.Key)                   // Extrae el nombre del género
                .FirstOrDefault();                    // Toma el género más frecuente

            // Filtra contenidos que coincidan con el género favorito y que el usuario aún no haya visto
            List<Contenido> recomendaciones = ContenidoController.ObtenerContenido()
                .Where(c => c.Categoria == generoFavorito && !usuario.Historial.Contains(c))
                .Take(5) // Limita las recomendaciones a un máximo de 5 contenidos
                .ToList();

            // Devuelve la lista de contenidos recomendados
            return recomendaciones;
        }
    }
}
