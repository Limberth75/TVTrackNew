using Bogus;
using Microsoft.EntityFrameworkCore;
using TVTrackII.Data;
using TVTrackII.Models;

namespace TVTrackII.Services
{
    public class ContenidoService
    {
        private readonly ApplicationDbContext _context;

        public ContenidoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Contenido>> ObtenerTodosAsync()
        {
            return await _context.Contenidos.ToListAsync();
        }

        public async Task CrearContenidosFalsosAsync()
        {
            if (await _context.Contenidos.AnyAsync()) return;

            var faker = new Faker<Contenido>()
                .RuleFor(c => c.Titulo, f => f.Lorem.Sentence(3))
                .RuleFor(c => c.Genero, f => f.PickRandom("Acción", "Comedia", "Drama", "Terror"))
                .RuleFor(c => c.DuracionMinutos, f => f.Random.Int(60, 180))
                .RuleFor(c => c.FechaEstreno, f => f.Date.Past(5))
                .RuleFor(c => c.Disponible, f => f.Random.Bool());

            var lista = faker.Generate(15);
            _context.Contenidos.AddRange(lista);
            await _context.SaveChangesAsync();
        }
    }
}
