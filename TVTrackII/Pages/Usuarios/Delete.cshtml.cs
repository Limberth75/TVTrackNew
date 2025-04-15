using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TVTrackII.Data;
using TVTrackII.Models;

namespace TVTrackII.Pages.Usuarios
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Usuario Usuario { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            Usuario? usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return RedirectToPage("Index");
            }

            Usuario = usuario;
            return Page();
        }

        public IActionResult OnPost()
        {
            Usuario? usuario = _context.Usuarios.Find(Usuario.Id);
            if (usuario == null)
            {
                return RedirectToPage("Index");
            }

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
