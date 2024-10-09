using bienesoft.Funcions;
using bienesoft.Models;
using bienesoft.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllers();

// Configurar Swagger para desarrollo.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar DbContext con la cadena de conexión correcta.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"), // Asegúrate de que el nombre sea correcto
        new MySqlServerVersion(new Version(8, 0, 39))
    )
);

// Registrar servicios personalizados.
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<DepartmentServices>();
builder.Services.AddTransient<GeneralFunction>();

// Configurar JWT
builder.Services.Configure<JWTModels>(builder.Configuration.GetSection("JWT"));

// Construir la aplicación.
var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
