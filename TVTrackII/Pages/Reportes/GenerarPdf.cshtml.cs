using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TVTrackII.Data;
using TVTrackII.Services;

namespace TVTrackII.Pages.Reportes
{
    public class GenerarPdfModel : PageModel
    {
        private readonly ReportePdfService _pdfService;
        private readonly ApplicationDbContext _context;

        public GenerarPdfModel(ReportePdfService pdfService, ApplicationDbContext context)
        {
            _pdfService = pdfService;
            _context = context;
        }

        public IActionResult OnGet()
        {
            var usuarios = _context.Usuarios.ToList();
            var contenidos = _context.Contenidos.ToList();

            string html = @"
                <html>
                <head>
                    <style>
                        body { font-family: Arial; }
                        h1 { color: navy; }
                        table { width: 100%; border-collapse: collapse; margin-top: 20px; }
                        th, td { border: 1px solid #000; padding: 8px; text-align: left; }
                        th { background-color: #f2f2f2; }
                    </style>
                </head>
                <body>
                    <h1>Reporte de Usuarios - TVTrack</h1>
                    <table>
                        <tr><th>ID</th><th>Nombre</th><th>Correo</th><th>Rol</th></tr>";

            foreach (var u in usuarios)
            {
                html += $"<tr><td>{u.Id}</td><td>{u.Nombre}</td><td>{u.Correo}</td><td>{u.Rol}</td></tr>";
            }

            html += @"</table><h2>Reporte de Contenidos</h2><table>
                        <tr><th>ID</th><th>Título</th><th>Género</th><th>Veces Visto</th></tr>";

            foreach (var c in contenidos)
            {
                html += $"<tr><td>{c.Id}</td><td>{c.Titulo}</td><td>{c.Genero}</td><td>{c.VecesVisto}</td></tr>";
            }

            html += @"</table></body></html>";

            var pdfBytes = _pdfService.GenerarPdfDesdeHtml(html);

            return File(pdfBytes, "application/pdf", "ReporteTVTrack.pdf");
        }
    }
}
