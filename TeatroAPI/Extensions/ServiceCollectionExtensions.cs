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

            return services;
        }
    }
}
