using Inspira.Infrastructure;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planningame_Domain.Interfaces;
using Planningame_Domain.Interfaces.Repositorios;
using Planningame_Insfrastructure.Repositorios;

namespace Planningame_Insfrastructure.Inicialization
{
    public static class ConfigureServices
    {
        public static void ConfigureInfra(this IServiceCollection services, IConfiguration cfg)
        {
            var connectionString = cfg.GetConnectionString("DefaultConnection");

            services.AddDbContext<PlanningameDbContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IUnityOfWork, UnityOfWork>();

            services.AddMapster();

            services.AddScoped<IPartidaRepository, PartidaRepository>();
            services.AddScoped<IRodadaRepository, RodadaRepository>();
            services.AddScoped<IJogadorRepositoy, JogadorRepositoy>();
            services.AddScoped<IVotoRepository, VotoRepository>();
        }
    }
}
