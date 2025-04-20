using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TVTrackII.Data;
using TVTrackII.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TVTrackII.Pages.Comentarios
{
    public class ComentariosIndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ComentariosIndexModel(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? comentarioTexto { get; set; }

        public string TituloContenido { get; set; } = string.Empty;
        public string Mensaje { get; set; } = string.Empty;
        public bool EstaAutorizado { get; set; } = false;

        public List<ComentarioDTO> Comentarios { get; set; } = new();

        public IActionResult OnGet()
        {
            CargarDatos();
            return Page();
        }

        public IActionResult OnGetAgregar()
        {
            var nombreUsuario = _httpContextAccessor.HttpContext?.Session.GetString("NombreUsuario");
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Nombre == nombreUsuario);
            if (usuario == null) return RedirectToPage("/Login");

            if (!_context.HistorialVisualizacion.Any(h => h.UsuarioId == usuario.Id && h.ContenidoId == id))
            {
                Mensaje = "No tienes permiso para comentar.";
                CargarDatos();
                return Page();
            }

            if (!string.IsNullOrWhiteSpace(comentarioTexto))
            {
                _context.Comentarios.Add(new Comentario
                {
                    ContenidoId = id,
                    UsuarioId = usuario.Id,
                    Texto = comentarioTexto,
                    Fecha = DateTime.Now
                });
                _context.SaveChanges();
            }

            return RedirectToPage(new { id });
        }

        private void CargarDatos()
        {
            var nombreUsuario = _httpContextAccessor.HttpContext?.Session.GetString("NombreUsuario");
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Nombre == nombreUsuario);
            if (usuario == null) return;

            var contenido = _context.Contenidos.FirstOrDefault(c => c.Id == id);
            if (contenido != null)
            {
                TituloContenido = contenido.Titulo;
            }

            EstaAutorizado = _context.HistorialVisualizacion
                .Any(h => h.UsuarioId == usuario.Id && h.ContenidoId == id);

            Comentarios = _context.Comentarios
                .Where(c => c.ContenidoId == id)
                .Include(c => c.Usuario)
                .OrderByDescending(c => c.Fecha)
                .Select(c => new ComentarioDTO
                {
                    Usuario = c.Usuario.Nombre,
                    Texto = c.Texto,
                    Fecha = c.Fecha
                })
                .ToList();
        }

        public class ComentarioDTO
        {
            public string Usuario { get; set; } = string.Empty;
            public string Texto { get; set; } = string.Empty;
            public DateTime Fecha { get; set; }
        }
    }
}
