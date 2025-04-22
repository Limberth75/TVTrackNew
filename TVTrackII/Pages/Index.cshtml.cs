using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TVTrackII.Data;
using TVTrackII.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TVTrackII.Pages.Comentarios
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IndexModel(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)// Constructor
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [BindProperty]  //Nuevo comentario a agregar
        public Comentario NuevoComentario { get; set; } = new(); //Comentarios mostrados

        public List<ComentarioDTO> Comentarios { get; set; } = new();

        public void OnGet(int idContenido)
        {
            NuevoComentario.ContenidoId = idContenido;

            Comentarios = _context.Comentarios
                .Where(c => c.ContenidoId == idContenido)
                .Include(c => c.Usuario)
                .OrderByDescending(c => c.Fecha)
                .Select(c => new ComentarioDTO
                {
                    Texto = c.Texto,
                    Fecha = c.Fecha,
                    UsuarioNombre = c.Usuario.Nombre
                }).ToList();
        }

        public IActionResult OnPost() //Agrega un nuevo comentario a la base
        {
            var nombre = _httpContextAccessor.HttpContext?.Session.GetString("NombreUsuario");
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Nombre == nombre);

            if (usuario != null && !string.IsNullOrWhiteSpace(NuevoComentario.Texto))
            {
                NuevoComentario.UsuarioId = usuario.Id;
                NuevoComentario.Fecha = DateTime.Now;

                _context.Comentarios.Add(NuevoComentario);
                _context.SaveChanges();
            }

            return RedirectToPage(new { idContenido = NuevoComentario.ContenidoId });
        }

        public class ComentarioDTO
        {
            public string Texto { get; set; }
            public DateTime Fecha { get; set; }
            public string UsuarioNombre { get; set; }
        }
    }
}
