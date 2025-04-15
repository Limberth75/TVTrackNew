using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace TVTrackII.Pages
{
    public class HomePageModel : PageModel
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public string RolUsuario { get; set; } = string.Empty;

        public void OnGet()
        {
            NombreUsuario = HttpContext.Session.GetString("NombreUsuario") ?? "Invitado";
            RolUsuario = HttpContext.Session.GetString("RolUsuario") ?? "Desconocido";
        }
    }
}
