using Planningame_Application.Interfaces;
using Planningame_Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Planningame_Application
{
    public static class ConfigureServices
    {
        public static void ConfigureApplication(this IServiceCollection services, IConfiguration cfg)
        {
            services.AddScoped<IPartidaService, PartidaService>();
            services.AddScoped<IJogadoresService, JogadoresService>();
            services.AddScoped<IRodadaService, RodadaService>();
        }
    }
}
