using TeatroAPI;
using TeatroAPI.Data;
using TeatroAPI.Services;
using TeatroAPI.Extensions;
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

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddApplicationServices();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("PoliticaCORS");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
