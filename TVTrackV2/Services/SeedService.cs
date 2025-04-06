using Bogus;
using Microsoft.EntityFrameworkCore;
using TVTrackV2.Data;
using TVTrackV2.Models.Entities;

namespace TVTrackV2.Services
{
    public class SeedService
    {
        private readonly ApplicationDbContext _context;

        public SeedService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            // Si la tabla de usuarios está vacía, insertamos
            if (!await _context.Usuarios.AnyAsync())
            {
                var usuarios = new Faker<Usuario>()
                    .RuleFor(u => u.Nombre, f => f.Name.FullName())
                    .RuleFor(u => u.Email, f => f.Internet.Email())
                    .RuleFor(u => u.Contraseña, f => f.Internet.Password(8))
                    .RuleFor(u => u.Rol, f => "usuario")
                    .Generate(95);

                var admins = new Faker<Usuario>()
                    .RuleFor(u => u.Nombre, f => f.Name.FullName())
                    .RuleFor(u => u.Email, f => f.Internet.Email())
                    .RuleFor(u => u.Contraseña, f => f.Internet.Password(10))
                    .RuleFor(u => u.Rol, f => "admin")
                    .Generate(5);

                usuarios.AddRange(admins);
                await _context.Usuarios.AddRangeAsync(usuarios);
            }

            // Si la tabla de contenidos está vacía, insertamos
            if (!await _context.Contenidos.AnyAsync())
            {
                var generos = new[] { "Acción", "Drama", "Comedia", "Terror", "Ciencia ficción" };
                var plataformas = new[] { "Netflix", "Disney+", "HBO", "Prime Video", "Star+" };

                var contenidos = new Faker<Contenido>()
                    .RuleFor(c => c.Titulo, f => f.Lorem.Sentence(3))
                    .RuleFor(c => c.Categoria, f => f.PickRandom(generos))
                    .RuleFor(c => c.Plataforma, f => f.PickRandom(plataformas))
                    .RuleFor(c => c.Descripcion, f => f.Lorem.Paragraph(1))
                    .RuleFor(c => c.FechaEstreno, f => f.Date.Past(5))
                    .RuleFor(c => c.DuracionMinutos, f => f.Random.Int(60, 180))
                    .RuleFor(c => c.Disponible, f => f.Random.Bool())
                    .Generate(100);

                await _context.Contenidos.AddRangeAsync(contenidos);
            }

            await _context.SaveChangesAsync();
        }
    }
}
