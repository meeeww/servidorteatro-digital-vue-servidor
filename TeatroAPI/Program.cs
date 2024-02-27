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

var connectionString = "Server=teatrosqlserver,1433;Database=teatroapi;User Id=sa;Password=ContraFuerteParaOmarhOO123!!;Encrypt=True;TrustServerCertificate=True;";
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
