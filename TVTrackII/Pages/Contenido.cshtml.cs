using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System;
using TVTrackII.Data;
using TVTrackII.Models;

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

        public void OnGet()
        {
            var rol = _httpContextAccessor.HttpContext?.Session.GetString("RolUsuario");
            var nombre = _httpContextAccessor.HttpContext?.Session.GetString("NombreUsuario");

            if (string.IsNullOrEmpty(rol) || string.IsNullOrEmpty(nombre))
            {
                Contenidos = new List<Contenido>();
                return;
            }

            if (rol == "Administrador")
            {
                Contenidos = _context.Contenidos.ToList();
            }
            else
            {
                Contenidos = _context.Contenidos.ToList(); // Mostrar todos
            }
        }

        public IActionResult OnPostVer(int idContenido)
        {
            var nombre = _httpContextAccessor.HttpContext?.Session.GetString("NombreUsuario");
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Nombre == nombre);

            if (usuario != null)
            {
                bool yaRegistrado = _context.HistorialVisualizacion
                    .Any(h => h.UsuarioId == usuario.Id && h.ContenidoId == idContenido);

                if (!yaRegistrado)
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

            return RedirectToPage(); // recarga Contenido.cshtml
        }
    }
}
