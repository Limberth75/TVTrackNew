using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using TVTrackV2.Components;
using TVTrackV2.Data;
using TVTrackV2.Services;
using Microsoft.JSInterop;
using TVTrackV2;

var builder = WebApplication.CreateBuilder(args);

// Añadir los servicios necesarios
builder.Services.AddRazorPages(); // Para Blazor Server tradicional
builder.Services.AddControllers(); // Añadir soporte para controladores
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<SeedService>();

// Asegúrate de registrar IJSRuntime correctamente
builder.Services.AddScoped<IJSRuntime, JSRuntime>(); // Esto está bien

var app = builder.Build();

// Condición de desarrollo para manejo de errores
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

// Configurar Blazor para Blazor Server tradicional
app.MapBlazorHub(); // Usado para Blazor Server tradicional
app.MapControllers(); // Mapeo de controladores

app.Run();
