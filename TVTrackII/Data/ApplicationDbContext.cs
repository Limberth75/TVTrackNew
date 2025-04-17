using Microsoft.EntityFrameworkCore;
using TVTrackII.Models;

namespace TVTrackII.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Contenido> Contenidos => Set<Contenido>();
        public DbSet<Calificacion> Calificaciones => Set<Calificacion>();
        public DbSet<HistorialVisualizacion> Historiales { get; set; }
        public DbSet<HistorialVisualizacion> HistorialVisualizaciones { get; set; }
        public DbSet<HistorialVisualizacion> HistorialVisualizacion { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
    }
}
