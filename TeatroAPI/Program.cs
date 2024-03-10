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

var connectionString = Environment.GetEnvironmentVariable("DOCKER_CONTAINER") != null
    ? Environment.GetEnvironmentVariable("STRING_CONEXION")
    : builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TeatroAPIContext>(options =>
    options.UseSqlServer(connectionString).LogTo(Console.WriteLine, LogLevel.Information));

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddApplicationServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "PoliticaCORS",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173/");
                      });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("PoliticaCORS");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
