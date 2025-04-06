using Microsoft.EntityFrameworkCore;
using TVTrackV2.Models.Entities;

namespace TVTrackV2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Contenido> Contenidos => Set<Contenido>();
        public DbSet<Comentario> Comentarios => Set<Comentario>();
        public DbSet<Calificacion> Calificaciones => Set<Calificacion>();
        public DbSet<HistorialVisualizacion> Historiales => Set<HistorialVisualizacion>();
    }
}
