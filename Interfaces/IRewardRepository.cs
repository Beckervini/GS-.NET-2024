using GreenFundGS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenFundGS.Interfaces
{
    /// <summary>
    /// Interface para o repositório de Reward.
    /// </summary>
    public interface IRewardRepository
    {
        /// <summary>
        /// Retorna todas as recompensas.
        /// </summary>
        Task<IEnumerable<Reward>> GetAllAsync();

        /// <summary>
        /// Retorna uma recompensa por ID.
        /// </summary>
        Task<Reward> GetByIdAsync(int id);

        /// <summary>
        /// Adiciona uma nova recompensa.
        /// </summary>
        Task AddAsync(Reward reward);

        /// <summary>
        /// Exclui uma recompensa existente.
        /// </summary>
        Task DeleteAsync(Reward reward);
    }
}
