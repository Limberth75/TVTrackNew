#nullable enable
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using TVTrackII.Data;
using TVTrackII.Models;

namespace TVTrackII.Pages.Estadisticas
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public string JsonNombresContenidos { get; set; } = "[]";
        public string JsonCantidades { get; set; } = "[]";

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            var topContenidos = _context.HistorialVisualizaciones
                .Include(h => h.Contenido)
                .GroupBy(h => h.ContenidoId)
                .Select(g => new
                {
                    Nombre = g.First().Contenido.Titulo,
                    Veces = g.Count()
                })
                .OrderByDescending(g => g.Veces)
                .Take(5)
                .ToList();

            var nombres = topContenidos.Select(c => c.Nombre).ToList();
            var cantidades = topContenidos.Select(c => c.Veces).ToList();

            JsonNombresContenidos = JsonSerializer.Serialize(nombres);
            JsonCantidades = JsonSerializer.Serialize(cantidades);
        }
    }
}
