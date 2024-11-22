using GreenFundGS.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using GreenFundGS.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using GreenFundGS.Interfaces;

namespace GreenFundGS.Controllers
{
    /// <summary>
    /// Controlador para gerenciar recompensas.
    /// </summary>
    [ApiController]
    [Route("api/rewards")]
    public class RewardController : ControllerBase
    {
        private readonly IRewardService _rewardService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor do RewardController.
        /// </summary>
        /// <param name="rewardService">Serviço de recompensa.</param>
        /// <param name="mapper">Mapeador para converter entre modelos e DTOs.</param>
        public RewardController(IRewardService rewardService, IMapper mapper)
        {
            _rewardService = rewardService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna uma lista de todas as recompensas.
        /// </summary>
        /// <returns>Lista de recompensas.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RewardDto>>> GetAllRewards()
        {
            var rewards = await _rewardService.GetAllRewardsAsync();
            var rewardDtos = _mapper.Map<IEnumerable<RewardDto>>(rewards);
            return Ok(rewardDtos);
        }

        /// <summary>
        /// Cria uma nova recompensa no sistema.
        /// </summary>
        /// <param name="rewardDto">Detalhes da recompensa a ser criada.</param>
        /// <returns>Recompensa criada.</returns>
        [HttpPost]
        public async Task<ActionResult> CreateReward([FromBody] RewardDto rewardDto)
        {
            var reward = _mapper.Map<Reward>(rewardDto);
            await _rewardService.AddRewardAsync(reward);
            var createdRewardDto = _mapper.Map<RewardDto>(reward);
            return CreatedAtAction(nameof(GetAllRewards), new { id = createdRewardDto.RewardId }, createdRewardDto);
        }
    }
}
