using System.Collections.Generic;
using System.Linq;
using TVTrack.Model;

namespace TVTrack.Controller
{
    public static class Recomendador
    {
        public static List<Contenido> GenerarRecomendaciones(Usuario usuario)
        {
            if (usuario.Historial.Count == 0)
            {
                return new List<Contenido>();
            }

            var generosFavoritos = usuario.Historial
                .GroupBy(c => c.Categoria)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .ToList();

            var contenidoDisponible = ContenidoController.ObtenerContenido();
            List<Contenido> recomendaciones = new List<Contenido>();

            foreach (var genero in generosFavoritos)
            {
                var recomendacionesGenero = contenidoDisponible
                    .Where(c => c.Categoria == genero && !usuario.Historial.Contains(c))
                    .ToList();

                foreach (var rec in recomendacionesGenero)
                {
                    if (recomendaciones.Count < 5)
                    {
                        recomendaciones.Add(rec);
                    }
                    else break;
                }

                if (recomendaciones.Count >= 5)
                    break;
            }

            if (recomendaciones.Count == 0)
            {
                var aleatorios = contenidoDisponible
                    .Where(c => !usuario.Historial.Contains(c))
                    .OrderBy(c => System.Guid.NewGuid())
                    .Take(3)
                    .ToList();

                recomendaciones.AddRange(aleatorios);
            }

            return recomendaciones;
        }

        // ✅ MÉTODO NUEVO para obtener el género favorito del usuario
        public static string ObtenerGeneroFavorito(Usuario usuario)
        {
            if (usuario.Historial == null || usuario.Historial.Count == 0)
                return "N/A";

            return usuario.Historial
                .GroupBy(c => c.Categoria)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault() ?? "N/A";
        }
    }
}
