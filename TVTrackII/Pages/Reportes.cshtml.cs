using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using TVTrackII.Data;
using System.Text;
using System.Linq;

namespace TVTrackII.Pages
{
    public class ReportesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ReportesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public string? MensajeError { get; set; }

        public IActionResult OnGet()
        {
            var rol = HttpContext.Session.GetString("RolUsuario");

            if (rol != "Administrador")
            {
                MensajeError = "Acceso denegado. Solo administradores pueden ver esta página.";
                return Page();
            }

            return Page();
        }

        public IActionResult OnGetCsv()
        {
            var usuarios = _context.Usuarios
                .Select(u => $"{u.Id},{u.Nombre},{u.Correo},{u.Rol}")
                .ToList();

            var contenidos = _context.Contenidos
                .Select(c => $"{c.Id},{c.Titulo},{c.Genero},{c.VecesVisto}")
                .ToList();

            var builder = new StringBuilder();
            builder.AppendLine("=== Usuarios ===");
            builder.AppendLine("Id,Nombre,Correo,Rol");
            usuarios.ForEach(line => builder.AppendLine(line));

            builder.AppendLine();
            builder.AppendLine("=== Contenido ===");
            builder.AppendLine("Id,Titulo,Genero,VecesVisto");
            contenidos.ForEach(line => builder.AppendLine(line));

            var bytes = Encoding.UTF8.GetBytes(builder.ToString());
            return File(bytes, "text/csv", "reporte_completo.csv");
        }

        public IActionResult OnGetPdf()
        {
            var html = new StringBuilder();

            html.Append("<h1>Reporte de Usuarios - TVTrack</h1><table border='1'><tr><th>ID</th><th>Nombre</th><th>Correo</th><th>Rol</th></tr>");
            foreach (var u in _context.Usuarios)
            {
                html.Append($"<tr><td>{u.Id}</td><td>{u.Nombre}</td><td>{u.Correo}</td><td>{u.Rol}</td></tr>");
            }
            html.Append("</table><br/>");

            html.Append("<h2>Reporte de Contenido</h2><table border='1'><tr><th>ID</th><th>Titulo</th><th>Género</th><th>Veces Visto</th></tr>");
            foreach (var c in _context.Contenidos)
            {
                html.Append($"<tr><td>{c.Id}</td><td>{c.Titulo}</td><td>{c.Genero}</td><td>{c.VecesVisto}</td></tr>");
            }
            html.Append("</table>");

            var pdfBytes = Encoding.UTF8.GetBytes(html.ToString());
            return File(pdfBytes, "application/octet-stream", "reporte_completo.html");
        }
    }
}
