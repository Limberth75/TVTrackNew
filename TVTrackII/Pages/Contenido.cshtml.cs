using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TVTrackII.Data;
using TVTrackII.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TVTrackII.Pages
{
    public class ContenidoModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContenidoModel(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // Lista que contiene los contenidos disponibles para mostrar
        public List<Contenido> Contenidos { get; set; } = new();
        // DTO en caso de uso futuro de reportes
        public List<HistorialVistaDTO> HistorialAdmin { get; set; } = new();

        public void OnGet()
        {
            var rol = _httpContextAccessor.HttpContext?.Session.GetString("RolUsuario");
            var nombre = _httpContextAccessor.HttpContext?.Session.GetString("NombreUsuario");

            if (rol == "Administrador")
            {
                Contenidos = _context.Contenidos
                    .OrderBy(c => c.Titulo)
                    .ToList();
            }
            else if (rol == "Usuario")  // Usuario va a ver solo lo que aún no ha visto
            {
                var usuario = _context.Usuarios.FirstOrDefault(u => u.Nombre == nombre);
                if (usuario != null)
                {
                    var vistos = _context.HistorialVisualizacion
                        .Where(h => h.UsuarioId == usuario.Id)
                        .Select(h => h.ContenidoId)
                        .ToList();

                    Contenidos = _context.Contenidos
                        .Where(c => !vistos.Contains(c.Id))
                        .ToList();
                }
            }
        }

        public IActionResult OnGetVer(int idContenido)
        {
            var nombre = _httpContextAccessor.HttpContext?.Session.GetString("NombreUsuario");
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Nombre == nombre);

            if (usuario != null)
            {
                // Verificar si ya lo vio
                bool yaVisto = _context.HistorialVisualizacion
                    .Any(h => h.UsuarioId == usuario.Id && h.ContenidoId == idContenido);

                if (!yaVisto)
                {
                    // Registrar visualización
                    _context.HistorialVisualizacion.Add(new HistorialVisualizacion
                    {
                        UsuarioId = usuario.Id,
                        ContenidoId = idContenido,
                        Fecha = DateTime.Now
                    });

                    // Incrementar VecesVisto
                    var contenido = _context.Contenidos.FirstOrDefault(c => c.Id == idContenido);
                    if (contenido != null)
                    {
                        contenido.VecesVisto += 1;
                        _context.Contenidos.Update(contenido);
                    }

                    _context.SaveChanges();
                }
            }

            return RedirectToPage();
        }

        public class HistorialVistaDTO
        {
            public string Usuario { get; set; } = string.Empty;
            public string Titulo { get; set; } = string.Empty;
            public string Genero { get; set; } = string.Empty;
            public DateTime Fecha { get; set; }
        }
    }
}
