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

        public List<Contenido> Contenidos { get; set; } = new();
        public List<HistorialVistaDTO> HistorialAdmin { get; set; } = new();

        public void OnGet()
        {
            var rol = _httpContextAccessor.HttpContext?.Session.GetString("RolUsuario");
            var nombre = _httpContextAccessor.HttpContext?.Session.GetString("NombreUsuario");

            if (rol == "Administrador")
            {
                HistorialAdmin = _context.HistorialVisualizacion
                    .Include(h => h.Usuario)
                    .Include(h => h.Contenido)
                    .Select(h => new HistorialVistaDTO
                    {
                        Usuario = h.Usuario.Nombre,
                        Titulo = h.Contenido.Titulo,
                        Genero = h.Contenido.Genero,
                        Fecha = h.FechaVisualizacion
                    })
                    .ToList();
            }
            else if (rol == "Usuario")
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
                bool yaVisto = _context.HistorialVisualizacion
                    .Any(h => h.UsuarioId == usuario.Id && h.ContenidoId == idContenido);

                if (!yaVisto)
                {
                    _context.HistorialVisualizacion.Add(new HistorialVisualizacion
                    {
                        UsuarioId = usuario.Id,
                        ContenidoId = idContenido,
                        FechaVisualizacion = DateTime.Now
                    });

                    _context.SaveChanges();
                }
            }

            return RedirectToPage(); // Redirige de vuelta a /Contenido
        }

        public class HistorialVistaDTO
        {
            public string Usuario { get; set; }
            public string Titulo { get; set; }
            public string Genero { get; set; }
            public DateTime Fecha { get; set; }
        }
    }
}
