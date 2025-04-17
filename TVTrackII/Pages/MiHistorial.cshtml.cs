using Microsoft.AspNetCore.Mvc.RazorPages;
using TVTrackII.Data;
using TVTrackII.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System;

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

        public List<ContenidoConFecha> Contenidos { get; set; } = new();

        public void OnGet()
        {
            var nombreUsuario = _httpContextAccessor.HttpContext?.Session.GetString("NombreUsuario");

            if (string.IsNullOrEmpty(nombreUsuario)) return;

            var usuario = _context.Usuarios.FirstOrDefault(u => u.Nombre == nombreUsuario);

            if (usuario != null)
            {
                Contenidos = _context.HistorialVisualizacion
                    .Where(h => h.UsuarioId == usuario.Id)
                    .OrderByDescending(h => h.FechaVisualizacion)
                    .Select(h => new ContenidoConFecha
                    {
                        Titulo = h.Contenido.Titulo,
                        Genero = h.Contenido.Genero,
                        Fecha = h.FechaVisualizacion
                    }).ToList();
            }
        }

        public class ContenidoConFecha
        {
            public string Titulo { get; set; }
            public string Genero { get; set; }
            public DateTime Fecha { get; set; }
        }
    }
}
