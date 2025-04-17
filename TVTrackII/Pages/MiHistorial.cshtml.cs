using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http; 
using Microsoft.EntityFrameworkCore;
using TVTrackII.Data;
using TVTrackII.Models;
using System.Collections.Generic;
using System.Linq;

namespace TVTrackII.Pages
{
    public class MiHistorialModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MiHistorialModel(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<HistorialVisualizacion> Contenidos { get; set; } = new();

        public void OnGet()
        {
            var nombreUsuario = _httpContextAccessor.HttpContext?.Session.GetString("NombreUsuario");
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Nombre == nombreUsuario);

            if (usuario == null) return;

            Contenidos = _context.HistorialVisualizaciones
                .Include(h => h.Contenido)
                .Where(h => h.UsuarioId == usuario.Id)
                .OrderByDescending(h => h.Fecha)
                .ToList();
        }
    }
}
