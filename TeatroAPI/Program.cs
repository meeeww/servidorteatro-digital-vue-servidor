using TeatroAPI;
using TeatroAPI.Data;
using TeatroAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "TeatroAPI", Version = "v1" });
});

var connectionStringLocal = builder.Configuration.GetConnectionString("TeatroAPI");

var enDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";

var connectionString = enDocker && !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("STRING_CONEXION"))
    ? Environment.GetEnvironmentVariable("STRING_CONEXION")
    : connectionStringLocal;

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("No se ha configurado un tipo de base de datos válido.");
}

builder.Services.AddDbContext<TeatroAPIContext>(options =>
    options.UseSqlServer(connectionString).LogTo(Console.WriteLine, LogLevel.Information));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

//meter en otra clase con override
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, EFUsuarioRepository>();

builder.Services.AddScoped<SesionService>();
builder.Services.AddScoped<ISesionRepository, EFSesionRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("PoliticaCORS");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
