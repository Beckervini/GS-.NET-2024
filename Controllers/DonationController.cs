using GreenFundGS.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using GreenFundGS.DTOs;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using GreenFundGS.Interfaces;

namespace GreenFundGS.Controllers
{
    /// <summary>
    /// Controlador responsável por gerenciar as operações de doações.
    /// </summary>
    [ApiController]
    [Route("api/donations")]
    public class DonationController : ControllerBase
    {
        private readonly IDonationService _donationService;
        private readonly IProjectService _projectService;
        private readonly IUsuarioService _usuarioService; // Serviço de usuário adicionado
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor da classe DonationController.
        /// </summary>
        /// <param name="donationService">Serviço de doações injetado.</param>
        /// <param name="projectService">Serviço de projetos injetado.</param>
        /// <param name="usuarioService">Serviço de usuários injetado.</param>
        /// <param name="mapper">Instância do AutoMapper injetada.</param>
        public DonationController(IDonationService donationService, IProjectService projectService, IUsuarioService usuarioService, IMapper mapper)
        {
            _donationService = donationService;
            _projectService = projectService;
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        /// <summary>
        /// Registra uma nova doação para um projeto.
        /// </summary>
        /// <param name="donationDto">Objeto DTO contendo os detalhes da doação.</param>
        /// <returns>Resultado da criação da doação com status HTTP apropriado.</returns>
        [SwaggerOperation(Summary = "Cria uma doação", Description = "Registra uma doação para um projeto.")]
        [HttpPost]
        public async Task<IActionResult> CreateDonation([FromBody] DonationDto donationDto)
        {
            // Verifica se o projeto associado à doação existe
            var project = await _projectService.GetProjectByIdAsync(donationDto.ProjectId);
            if (project == null)
            {
                return NotFound("Projeto não encontrado.");
            }

            // Verifica se o usuário existe
            var user = await _usuarioService.GetUsuarioByIdAsync(donationDto.UserId);
            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            // Mapeia o DTO para a entidade de doação e associa o projeto e usuário
            var donation = _mapper.Map<Donation>(donationDto);
            donation.Project = project;
            donation.User = user;

            // Adiciona a doação e retorna a resposta
            await _donationService.AddDonationAsync(donation);
            var createdDonationDto = _mapper.Map<DonationDto>(donation);

            return CreatedAtAction(nameof(CreateDonation), new { id = createdDonationDto.DonationId }, createdDonationDto);
        }
    }
}
