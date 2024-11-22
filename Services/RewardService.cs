using GreenFundGS.Interfaces;
using GreenFundGS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenFundGS.Services
{
    /// <summary>
    /// Implementação do serviço de Reward.
    /// </summary>
    public class RewardService : IRewardService
    {
        private readonly IRewardRepository _rewardRepository;
        private readonly IRewardFactory _rewardFactory;

        /// <summary>
        /// Construtor do RewardService.
        /// </summary>
        /// <param name="rewardRepository">Repositório para gerenciar recompensas.</param>
        /// <param name="rewardFactory">Fábrica para criação de recompensas.</param>
        public RewardService(IRewardRepository rewardRepository, IRewardFactory rewardFactory)
        {
            _rewardRepository = rewardRepository;
            _rewardFactory = rewardFactory;
        }

        /// <summary>
        /// Retorna todas as recompensas.
        /// </summary>
        public async Task<IEnumerable<Reward>> GetAllRewardsAsync()
        {
            return await _rewardRepository.GetAllAsync();
        }

        /// <summary>
        /// Retorna uma recompensa pelo ID.
        /// </summary>
        public async Task<Reward> GetRewardByIdAsync(int id)
        {
            return await _rewardRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Gera uma nova recompensa.
        /// </summary>
        public async Task<Reward> GenerateRewardAsync(string rewardType, string descricao, int points)
        {
            var reward = _rewardFactory.CreateReward(rewardType, descricao, points);
            await _rewardRepository.AddAsync(reward);
            return reward;
        }

        /// <summary>
        /// Exclui uma recompensa pelo ID.
        /// </summary>
        public async Task DeleteRewardAsync(int id)
        {
            var reward = await _rewardRepository.GetByIdAsync(id);
            if (reward != null)
            {
                await _rewardRepository.DeleteAsync(reward);
            }
        }

        /// <summary>
        /// Adiciona uma nova recompensa.
        /// </summary>
        public async Task AddRewardAsync(Reward reward)
        {
            await _rewardRepository.AddAsync(reward);
        }
    }
}
