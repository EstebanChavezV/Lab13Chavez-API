using Lab13Chavez.Domain.Ports;
using Lab13Chavez.Infrastructure.Adapters;
using Lab13Chavez.Application.UseCases; 
using Microsoft.OpenApi.Models; // Necesario para la configuración de Swagger

var builder = WebApplication.CreateBuilder(args);

// ----------------------------------------------------
// Configuración de Inyección de Dependencias (DI)
// 1. Conectar el Puerto con su Adaptador (Infraestructura)
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

// 2. Registrar el Caso de Uso (Use Case)
builder.Services.AddScoped<GetTicketQueryHandler>(); 
// ----------------------------------------------------

// ----------------------------------------------------
// Configuración de Servicios (Swagger y API)
// Agrega servicios de controladores para manejar peticiones HTTP
builder.Services.AddControllers();

// Agrega servicios de OpenAPI/Swagger para generar la documentación
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Opcional: Configuración para el título de Swagger UI
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lab13Chavez API - Hexagonal Architecture", Version = "v1" });
});
// ----------------------------------------------------

var app = builder.Build();

// ----------------------------------------------------
// Configuración del Middleware
// MOVIDO: Habilitamos Swagger FUERA del bloque IsDevelopment para que funcione en Render (Producción)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lab13Chavez API v1");
});
// ----------------------------------------------------

// DEJAMOS ESTE BLOQUE SOLO SI HAY OTRAS CONFIGURACIONES ESPECÍFICAS DE DESARROLLO
// if (app.Environment.IsDevelopment())
// {
// Las líneas de Swagger se movieron arriba
// }


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();