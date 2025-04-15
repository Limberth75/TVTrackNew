using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TVTrackII.Data;
using TVTrackII.Models;

namespace TVTrackII.Pages.Usuarios
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Usuario Usuario { get; set; } = new();

        public string MensajeError { get; set; } = string.Empty;

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
            if (!ModelState.IsValid)
                return Page();

            var correoNormalizado = Usuario.Correo.Trim().ToLower();

            if (!correoNormalizado.EndsWith(".com"))
            {
                MensajeError = "El correo debe terminar en '.com'.";
                return Page();
            }

            bool correoDuplicado = _context.Usuarios.Any(u => u.Correo.Trim().ToLower() == correoNormalizado && u.Id != Usuario.Id);
            if (correoDuplicado)
            {
                MensajeError = "El correo ingresado ya está en uso por otro usuario.";
                return Page();
            }

            if (string.IsNullOrEmpty(Usuario.Contrasena) || Usuario.Contrasena.Length > 5 || !Usuario.Contrasena.All(char.IsDigit))
            {
                MensajeError = "La contraseña debe ser numérica y de máximo 5 dígitos.";
                return Page();
            }

            if (Usuario.Rol == "Administrador")
            {
                int totalAdmins = _context.Usuarios.Count(u => u.Rol == "Administrador" && u.Id != Usuario.Id);
                if (totalAdmins >= 5)
                {
                    MensajeError = "Ya existen 5 administradores. No puedes cambiar este usuario a Administrador.";
                    return Page();
                }
            }

            Usuario.Correo = correoNormalizado;

            _context.Usuarios.Update(Usuario);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
