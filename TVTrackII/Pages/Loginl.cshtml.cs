using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TVTrackII.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;

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
        public string Correo { get; set; }

        [BindProperty]
        public string Contrasena { get; set; }

        public string MensajeError { get; set; }

        public void OnGet()
        {
            // limpia sesión
            HttpContext.Session.Clear();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(Correo) || string.IsNullOrEmpty(Contrasena))
            {
                MensajeError = "Por favor ingresa ambos campos.";
                return Page();
            }

            var usuario = _context.Usuarios.FirstOrDefault(u => u.Correo == Correo && u.Contrasena == Contrasena);

            if (usuario == null)
            {
                MensajeError = "Credenciales inválidas.";
                return Page();
            }

            HttpContext.Session.SetString("NombreUsuario", usuario.Nombre);
            HttpContext.Session.SetString("RolUsuario", usuario.Rol);

            return RedirectToPage("/HomePage");
        }
    }
}
