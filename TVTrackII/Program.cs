using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TVTrackII.Data;
using TVTrackII.Models;
using TVTrackII.Services;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System;
using System.Runtime.Loader;
using System.Runtime.InteropServices;
using System.IO;

// PDF
using DinkToPdf;
using DinkToPdf.Contracts;

// Cargar manualmente la DLL nativa de wkhtmltopdf
var wkhtmlPath = Path.Combine(Directory.GetCurrentDirectory(), "Wkhtmltopdf", "libwkhtmltox.dll");
CustomAssemblyLoadContext context = new();
context.LoadUnmanagedLibrary(wkhtmlPath);

var builder = WebApplication.CreateBuilder(args);

// Activar Razor Pages y servicios necesarios
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<RecomendacionService>();
builder.Services.AddScoped<ReportePdfService>();
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools())); // PDF

// Conexión a base de datos SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapRazorPages();

// Seeder inicial
using (var scope = app.Services.CreateScope())
{
    var contextDb = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    if (!contextDb.Usuarios.Any(u => u.Nombre == "Admin"))
    {
        contextDb.Usuarios.Add(new Usuario
        {
            Nombre = "Admin",
            Correo = "admin@admin.com",
            Contrasena = "admin",
            Rol = "Administrador"
        });

        contextDb.SaveChanges();
    }

    int cantidadActual = contextDb.Usuarios.Count(u => u.Rol == "Usuario");
    int cantidadFaltante = 100 - cantidadActual;

    if (cantidadFaltante > 0)
    {
        for (int i = cantidadActual + 1; i <= 100; i++)
        {
            contextDb.Usuarios.Add(new Usuario
            {
                Nombre = $"Usuario{i}",
                Correo = $"usuario{i}@hotmail.com",
                Contrasena = "1234",
                Rol = "Usuario"
            });
        }

        contextDb.SaveChanges();
    }

    if (!contextDb.Contenidos.Any())
    {
        string[] generos = { "Drama", "Terror", "Ciencia Ficción", "Comedia", "Acción", "Aventura", "Romance", "Documental" };
        var random = new Random();

        for (int i = 1; i <= 100; i++)
        {
            contextDb.Contenidos.Add(new Contenido
            {
                Titulo = $"Contenido {i}",
                Genero = generos[random.Next(generos.Length)],
                VecesVisto = random.Next(0, 1000)
            });
        }

        contextDb.SaveChanges();
    }
}

// Página por defecto
app.MapGet("/", async context =>
{
    var nombreUsuario = context.Session.GetString("NombreUsuario");
    var rolUsuario = context.Session.GetString("RolUsuario");

    if (!string.IsNullOrEmpty(nombreUsuario) && !string.IsNullOrEmpty(rolUsuario))
    {
        context.Response.Redirect("/HomePage");
    }
    else
    {
        context.Response.Redirect("/Login");
    }

    await Task.CompletedTask;
});

app.Run();

// Clase necesaria para cargar libwkhtmltox.dll manualmente
public class CustomAssemblyLoadContext : AssemblyLoadContext
{
    public CustomAssemblyLoadContext() : base(true) { }

    public IntPtr LoadUnmanagedLibrary(string absolutePath)
    {
        return LoadUnmanagedDllFromPath(absolutePath);
    }

    protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
    {
        return IntPtr.Zero;
    }
}
