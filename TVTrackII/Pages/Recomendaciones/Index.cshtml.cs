using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using TVTrackII.Services;
using TVTrackII.Models;
using TVTrackII.Data;
using System.Collections.Generic;
using System.Linq;

namespace TVTrackII.Pages.Recomendaciones
{
    public class IndexModel : PageModel
    {
        private readonly RecomendacionService _recomendacionService;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IndexModel(RecomendacionService recomendacionService, ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _recomendacionService = recomendacionService;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<Contenido> Recomendaciones { get; set; } = new();

        public void OnGet()
        {
            var nombre = _httpContextAccessor.HttpContext?.Session.GetString("NombreUsuario");
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Nombre == nombre);

            if (usuario != null)
            {
                Recomendaciones = _recomendacionService.ObtenerRecomendaciones(usuario.Id);
            }
        }
    }
}
