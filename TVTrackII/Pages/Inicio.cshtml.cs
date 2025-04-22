using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace TVTrackII.Pages
{
    public class InicioModel : PageModel
    {
        public string NombreUsuario { get; set; } = string.Empty;

        public IActionResult OnGet()
        {
            var nombre = HttpContext.Session.GetString("NombreUsuario");

            if (string.IsNullOrEmpty(nombre))   // Si no hay sesión activa, vuelve al Login
            {
                return RedirectToPage("Login");
            }

            NombreUsuario = nombre;
            return Page();
        }
    }
}
