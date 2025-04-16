using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.Text;
using TVTrackII.Data;
using System.Linq;

namespace TVTrackII.Pages
{
    public class ReportesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public string? MensajeError { get; set; }

        public ReportesModel(ApplicationDbContext context)
        {
            _context = context;
        }

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

        public IActionResult OnPostCsv()
        {
            var data = _context.Usuarios
                .Select(u => $"{u.Id},{u.Nombre},{u.Correo},{u.Rol}")
                .ToList();

            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("Id,Nombre,Correo,Rol");
            data.ForEach(line => csvBuilder.AppendLine(line));

            var bytes = Encoding.UTF8.GetBytes(csvBuilder.ToString());
            return File(bytes, "text/csv", "reporte_usuarios.csv");
        }

        public IActionResult OnPostPdf()
        {
            var html = new StringBuilder();
            html.Append("<h1>Reporte de Usuarios - TVTrack</h1>");
            html.Append("<table border='1'><tr><th>ID</th><th>Nombre</th><th>Correo</th><th>Rol</th></tr>");

            foreach (var u in _context.Usuarios.ToList())
            {
                html.Append($"<tr><td>{u.Id}</td><td>{u.Nombre}</td><td>{u.Correo}</td><td>{u.Rol}</td></tr>");
            }

            html.Append("</table>");

            var pdfBytes = Encoding.UTF8.GetBytes(html.ToString());
            return File(pdfBytes, "application/octet-stream", "reporte_usuarios.html");
        }
    }
}
