using GreenFundGS.Models;
using GreenFundGS.Interfaces;

namespace GreenFundGS.Factories
{
    /// <summary>
    /// Implementação da fábrica de recompensas.
    /// </summary>
    public class RewardFactory : IRewardFactory
    {
        /// <inheritdoc />
        public Reward CreateReward(string rewardType, string descricao, int points)
        {
            return new Reward
            {
                Type = rewardType,
                Descricao = descricao,
                Points = points
            };
        }
    }
}
