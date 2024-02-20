using BankAPI;
using BankAPI.Data;
using BankAPI.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "BancoAPI", Version = "v1" });
});

//esto es para el migrate
var connectionString = "Server=sqlserverapi,1433;Database=api_clase;User Id=sa;Password=ContraFuerteParaOmarhOO123!!;Encrypt=True;TrustServerCertificate=True;";
builder.Services.AddDbContext<BankAPIContext>(options =>
    options.UseSqlServer(connectionString).LogTo(Console.WriteLine, LogLevel.Information));

builder.Services.AddScoped<ClientesService>();
builder.Services.AddScoped<DetallePedidosService>();
builder.Services.AddScoped<EmpleadosService>();
builder.Services.AddScoped<PedidosService>();
builder.Services.AddScoped<ProductosService>();
builder.Services.AddScoped<RegistroVentasService>();
builder.Services.AddScoped<IClientesRepository, EfClientesRepository>();
builder.Services.AddScoped<IDetallePedidosRepository, EfDetallePedidosRepository>();
builder.Services.AddScoped<IEmpleadosRepository, EfEmpleadosRepository>();
builder.Services.AddScoped<IPedidosRepository, EfPedidosRepository>();
builder.Services.AddScoped<IProductosRepository, EfProductosRepository>();
builder.Services.AddScoped<IRegistroVentasRepository, EfRegistroVentasRepository>();


var app = builder.Build();

// Eliminar en produccion
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("Pol�ticaCORS");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
