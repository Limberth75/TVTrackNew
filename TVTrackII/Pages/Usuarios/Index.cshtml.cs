using Microsoft.AspNetCore.Mvc.RazorPages;
using TVTrackII.Models;
using TVTrackII.Data;
using System.Collections.Generic;
using System.Linq;

namespace TVTrackII.Pages.Usuarios
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Usuario> ListaUsuarios { get; set; } = new();

        public void OnGet()
        {
            ListaUsuarios = _context.Usuarios.ToList();
        }
    }
}
