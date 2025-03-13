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

            string generoFavorito = usuario.Historial
                .GroupBy(c => c.Categoria)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            List<Contenido> recomendaciones = ContenidoController.ObtenerContenido()
                .Where(c => c.Categoria == generoFavorito && !usuario.Historial.Contains(c))
                .Take(5)
                .ToList();

            return recomendaciones;
        }
    }
}
