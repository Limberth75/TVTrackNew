using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TVTrackII.Models;

namespace TVTrackII.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contenido> Contenidos => Set<Contenido>();
        public DbSet<Comentario> Comentarios => Set<Comentario>();
    }
}
