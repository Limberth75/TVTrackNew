using System;
using System.Collections.Generic;
using System.Linq;
using TVTrack.Model;

namespace TVTrack.Controller
{
    public static class ReportesController
    {
        public static void GenerarReporteUsuarios(List<Usuario> usuarios)
        {
            Console.WriteLine("Reporte de Usuarios:");
            Console.WriteLine($"Total de usuarios registrados: {usuarios.Count}");

            int activos = usuarios.Count(u => u.Historial.Count > 0);
            Console.WriteLine($"Usuarios activos (que han visto contenido): {activos}");
        }

        public static void GenerarReporteGeneros(List<Contenido> contenidos)
        {
            Console.WriteLine("Reporte de Géneros:");
            var generos = contenidos.GroupBy(c => c.Categoria)
                                    .Select(g => new { Categoria = g.Key, Cantidad = g.Count() })
                                    .OrderByDescending(g => g.Cantidad);

            foreach (var genero in generos)
            {
                Console.WriteLine($"{genero.Categoria}: {genero.Cantidad} títulos");
            }
        }
    }
}
