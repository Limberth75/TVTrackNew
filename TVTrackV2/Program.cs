using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using TVTrackV2.Components;
using TVTrackV2.Data;
using TVTrackV2.Services;
using Microsoft.JSInterop;

var builder = WebApplication.CreateBuilder(args);

// A�adir los servicios necesarios
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<SeedService>();

// Agregar SignalR para Blazor Server
builder.Services.AddSignalR();

var app = builder.Build();

// Condici�n de desarrollo para manejo de errores
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Configuraci�n de Blazor Server tradicional
app.MapBlazorHub();
app.MapControllers(); // Mapeo de controladores

app.Run();
