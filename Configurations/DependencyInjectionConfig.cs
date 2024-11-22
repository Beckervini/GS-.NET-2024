using Microsoft.Extensions.DependencyInjection;
using GreenFundGS.Interfaces;
using GreenFundGS.Repositories;
using GreenFundGS.Services;

namespace GreenFundGS.Configurations
{
    /// <summary>
    /// Classe para configurar a injeção de dependências.
    /// </summary>
    public static class DependencyInjectionConfig
    {
        /// <summary>
        /// Registra os serviços e repositórios no contêiner de injeção de dependência.
        /// </summary>
        /// <param name="services">A coleção de serviços da aplicação.</param>
        public static void RegisterServices(IServiceCollection services)
        {
            // Registrar repositórios
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IDonationRepository, DonationRepository>();
            services.AddScoped<IRewardRepository, RewardRepository>();

            // Registrar serviços
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IDonationService, DonationService>();
            services.AddScoped<IRewardService, RewardService>();

        }
    }
}
