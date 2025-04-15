using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TVTrackII.Data;
using TVTrackII.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Activar Razor Pages y servicios necesarios
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor(); // <- Requerido para usar @inject IHttpContextAccessor

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

app.UseSession();       // <-- Importante para HttpContext.Session
app.UseAuthorization();

app.MapRazorPages();

// Seeding de datos iniciales (admin + 100 usuarios)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    if (!context.Usuarios.Any(u => u.Nombre == "Admin"))
    {
        context.Usuarios.Add(new Usuario
        {
            Nombre = "Admin",
            Correo = "admin@admin.com",
            Contrasena = "admin",
            Rol = "Administrador"
        });

        context.SaveChanges();
    }

    int cantidadActual = context.Usuarios.Count(u => u.Rol == "Usuario");
    int cantidadFaltante = 100 - cantidadActual;

    if (cantidadFaltante > 0)
    {
        for (int i = cantidadActual + 1; i <= 100; i++)
        {
            context.Usuarios.Add(new Usuario
            {
                Nombre = $"Usuario{i}",
                Correo = $"usuario{i}@hotmail.com",
                Contrasena = "1234",
                Rol = "Usuario"
            });
        }

        context.SaveChanges();
    }
}

// Página por defecto según sesión
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
