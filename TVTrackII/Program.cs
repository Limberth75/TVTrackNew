using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TVTrackII.Components;
using TVTrackII.Data;
using TVTrackII.Models;
using TVTrackII.Services; // Asegúrate de tener este using para el ContenidoService

var builder = WebApplication.CreateBuilder(args);

// Configurar EF Core con SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar Identity con roles
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

// Razor components y autorización
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAuthorization();

// Registrar servicio de contenidos
builder.Services.AddScoped<ContenidoService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

// Ejecutar seeding de base de datos y contenido de prueba
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var contenidoService = services.GetRequiredService<ContenidoService>();

    await DataSeeder.SeedAsync(context, userManager, roleManager);
    await contenidoService.CrearContenidosFalsosAsync();
}

// Mapear componente principal
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
