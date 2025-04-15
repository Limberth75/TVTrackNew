using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TVTrackII.Models;
using TVTrackII.Data;
using System.Linq;

namespace TVTrackII.Pages.Usuarios
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Usuario Usuario { get; set; } = new();

        public string MensajeError { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var correoNormalizado = Usuario.Correo.Trim().ToLower();

            // Validar que termine en ".com"
            if (!correoNormalizado.EndsWith(".com"))
            {
                MensajeError = "El correo debe terminar en '.com'.";
                return Page();
            }

            // Validar que no esté duplicado
            bool correoExiste = _context.Usuarios.Any(u => u.Correo.Trim().ToLower() == correoNormalizado);
            if (correoExiste)
            {
                MensajeError = "El correo ingresado ya está registrado.";
                return Page();
            }

            // Validar contraseña: solo dígitos y máx 5
            if (string.IsNullOrEmpty(Usuario.Contrasena) ||
                Usuario.Contrasena.Length > 5 ||
                !Usuario.Contrasena.All(char.IsDigit))
            {
                MensajeError = "La contraseña debe ser numérica y de máximo 5 dígitos.";
                return Page();
            }

            // Validar que no haya más de 5 administradores
            if (Usuario.Rol == "Administrador")
            {
                int totalAdmins = _context.Usuarios.Count(u => u.Rol == "Administrador");
                if (totalAdmins >= 5)
                {
                    MensajeError = "Ya existen 5 administradores. No se pueden crear más.";
                    return Page();
                }
            }

            Usuario.Correo = correoNormalizado;
            _context.Usuarios.Add(Usuario);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
