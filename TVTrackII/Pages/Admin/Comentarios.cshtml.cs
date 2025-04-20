using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TVTrackII.Data;
using TVTrackII.Models;

namespace TVTrackII.Pages.Admin
{
    public class ComentariosModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ComentariosModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ComentarioDTO> Comentarios { get; set; } = new();

        public void OnGet()
        {
            Comentarios = _context.Comentarios
                .Include(c => c.Usuario)
                .Include(c => c.Contenido)
                .OrderByDescending(c => c.Fecha)
                .Select(c => new ComentarioDTO
                {
                    Usuario = c.Usuario.Nombre,
                    Contenido = c.Contenido.Titulo,
                    Texto = c.Texto,
                    Fecha = c.Fecha
                })
                .ToList();
        }

        public class ComentarioDTO
        {
            public string Usuario { get; set; } = string.Empty;
            public string Contenido { get; set; } = string.Empty;
            public string Texto { get; set; } = string.Empty;
            public DateTime Fecha { get; set; }
        }
    }
}
