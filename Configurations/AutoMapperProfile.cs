using AutoMapper;
using GreenFundGS.DTOs;
using GreenFundGS.Models;

namespace GreenFundGS.Configurations
{
    /// <summary>
    /// Configurações de mapeamento do AutoMapper.
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Configuração de mapeamento entre UsuarioDto e Usuario
            CreateMap<UsuarioDto, Usuario>()
                .ReverseMap(); // Permite mapeamento bidirecional

            // Configuração de mapeamento entre ProjectDto e Project
            CreateMap<ProjectDto, Project>()
                .ReverseMap(); // Permite mapeamento bidirecional

            // Configuração de mapeamento entre DonationDto e Donation
            CreateMap<DonationDto, Donation>()
                .ReverseMap(); // Permite mapeamento bidirecional

            // Configuração de mapeamento entre RewardDto e Reward
            CreateMap<RewardDto, Reward>()
                .ReverseMap(); // Permite mapeamento bidirecional
                
        }
    }
}
