using GreenFundGS.Models;
using System.Threading.Tasks;

namespace GreenFundGS.Interfaces
{
    /// <summary>
    /// Interface para definir os métodos do serviço de Reward.
    /// </summary>
    public interface IRewardService
    {
        Task<IEnumerable<Reward>> GetAllRewardsAsync();
        Task<Reward> GetRewardByIdAsync(int id);
        Task<Reward> GenerateRewardAsync(string rewardType, string description, int points);
        Task DeleteRewardAsync(int id);

        // Método para adicionar uma nova recompensa
        Task AddRewardAsync(Reward reward);
    }
}
