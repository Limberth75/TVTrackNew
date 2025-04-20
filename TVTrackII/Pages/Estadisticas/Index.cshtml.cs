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
            // Usamos directamente la tabla Contenidos y su propiedad VecesVisto
            var topContenidos = _context.Contenidos
                .Where(c => c.VecesVisto > 0)
                .OrderByDescending(c => c.VecesVisto)
                .Take(5)
                .Select(c => new
                {
                    Nombre = c.Titulo,
                    Veces = c.VecesVisto
                })
                .ToList();

            var nombres = topContenidos.Select(c => c.Nombre).ToList();
            var cantidades = topContenidos.Select(c => c.Veces).ToList();

            JsonNombresContenidos = JsonSerializer.Serialize(nombres);
            JsonCantidades = JsonSerializer.Serialize(cantidades);
        }
    }
}
