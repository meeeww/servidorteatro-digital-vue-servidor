using Microsoft.Extensions.DependencyInjection;
using TeatroAPI.Data;
using TeatroAPI.Services;

namespace TeatroAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<UsuarioService>();
            services.AddScoped<IUsuarioRepository, EFUsuarioRepository>();

            services.AddScoped<SesionService>();
            services.AddScoped<ISesionRepository, EFSesionRepository>();

            services.AddScoped<SalaService>();
            services.AddScoped<ISalaRepository, EFSalaRepository>();

            services.AddScoped<ReservaService>();
            services.AddScoped<IReservaRepository, EFReservaRepository>();

            services.AddScoped<ObraService>();
            services.AddScoped<IObraRepository, EFObraRepository>();

            services.AddScoped<FuncionService>();
            services.AddScoped<IFuncionRepository, EFFuncionRepository>();

            return services;
        }
    }
}
