using System;
using System.Collections.Generic;
using System.Linq;
using TVTrack.Model;

namespace TVTrack.Controller
{
    // Clase estática que genera diferentes reportes del sistema
    public static class ReportesController
    {
        // Muestra el total de usuarios registrados y cuántos han visto contenido
        public static void GenerarReporteUsuarios(List<Usuario> usuarios)
        {
            Console.WriteLine("Reporte de Usuarios:");
            Console.WriteLine($"Total de usuarios registrados: {usuarios.Count}");

            // Cuenta usuarios que tienen historial de visualización
            int activos = usuarios.Count(u => u.Historial.Count > 0);
            Console.WriteLine($"Usuarios activos (que han visto contenido): {activos}");
        }

        // Muestra cuántos títulos hay por género, ordenados de mayor a menor
        public static void GenerarReporteGeneros(List<Contenido> contenidos)
        {
            Console.WriteLine("Reporte de Géneros:");

            // Agrupa contenidos por categoría y cuenta cuántos hay en cada grupo
            var generos = contenidos.GroupBy(c => c.Categoria)
                                    .Select(g => new { Categoria = g.Key, Cantidad = g.Count() })
                                    .OrderByDescending(g => g.Cantidad); // Ordena de mayor a menor

            // Muestra el reporte por género
            foreach (var genero in generos)
            {
                Console.WriteLine($"{genero.Categoria}: {genero.Cantidad} títulos");
            }
        }
    }
}
