using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using TVTrackII.Data;
using TVTrackII.Models;

namespace TVTrackII.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Correo { get; set; } = string.Empty;

        [BindProperty]
        public string Contrasena { get; set; } = string.Empty;

        public string MensajeError { get; set; } = string.Empty;

        public IActionResult OnPost()
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Correo == Correo && u.Contrasena == Contrasena);

            if (usuario == null)
            {
                MensajeError = "Credenciales inválidas.";
                return Page();
            }

            // Guardar en sesión
            HttpContext.Session.SetString("NombreUsuario", usuario.Nombre);
            HttpContext.Session.SetString("RolUsuario", usuario.Rol);

            // Redirigir a HomePage (ya no directamente a Usuarios)
            return RedirectToPage("/HomePage");
        }
    }
}
