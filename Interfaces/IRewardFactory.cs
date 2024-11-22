using GreenFundGS.Models;

namespace GreenFundGS.Interfaces
{
    /// <summary>
    /// Interface para a fábrica de recompensas.
    /// </summary>
    public interface IRewardFactory
    {
        /// <summary>
        /// Cria uma recompensa com base nos parâmetros fornecidos.
        /// </summary>
        /// <param name="rewardType">Tipo da recompensa.</param>
        /// <param name="descricao">Descrição da recompensa.</param>
        /// <param name="points">Pontos necessários para obter a recompensa.</param>
        /// <returns>Uma nova instância de Reward.</returns>
        Reward CreateReward(string rewardType, string descricao, int points);
    }
}
