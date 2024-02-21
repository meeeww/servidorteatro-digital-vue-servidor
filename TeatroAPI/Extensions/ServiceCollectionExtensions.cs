using Microsoft.Extensions.DependencyInjection;
using TeatroAPI.Data;
using TeatroAPI.Services;

namespace TeatroAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Configura aquí tus servicios y repositorios
            services.AddScoped<UsuarioService>();
            services.AddScoped<IUsuarioRepository, EFUsuarioRepository>();

            services.AddScoped<SesionService>();
            services.AddScoped<ISesionRepository, EFSesionRepository>();

            // Añade más servicios y repositorios según sea necesario

            return services;
        }
    }
}
