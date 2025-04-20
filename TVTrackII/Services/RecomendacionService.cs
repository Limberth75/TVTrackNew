using System.Collections.Generic;
using System.Linq;
using TVTrackII.Data;
using TVTrackII.Models;

namespace TVTrackII.Services
{
    public class RecomendacionService
    {
        private readonly ApplicationDbContext _context;

        public RecomendacionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Contenido> ObtenerRecomendaciones(int usuarioId)
        {
            var generoFavorito = _context.HistorialVisualizacion
                .Where(h => h.UsuarioId == usuarioId)
                .Join(_context.Contenidos,
                      h => h.ContenidoId,
                      c => c.Id,
                      (h, c) => c.Genero)
                .GroupBy(g => g)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            if (string.IsNullOrEmpty(generoFavorito))
                return new List<Contenido>();

            var vistos = _context.HistorialVisualizacion
                .Where(h => h.UsuarioId == usuarioId)
                .Select(h => h.ContenidoId)
                .ToList();

            var recomendaciones = _context.Contenidos
                .Where(c => c.Genero == generoFavorito && !vistos.Contains(c.Id))
                .ToList();

            return recomendaciones;
        }
    }
}
