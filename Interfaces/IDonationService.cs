using GreenFundGS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenFundGS.Interfaces
{
    /// <summary>
    /// Interface para o serviço de doações.
    /// </summary>
    public interface IDonationService
    {
        /// <summary>
        /// Obtém todas as doações.
        /// </summary>
        Task<IEnumerable<Donation>> GetAllDonationsAsync();

        /// <summary>
        /// Obtém uma doação pelo ID.
        /// </summary>
        Task<Donation> GetDonationByIdAsync(int id);

        /// <summary>
        /// Adiciona uma nova doação.
        /// </summary>
        Task AddDonationAsync(Donation donation);

        /// <summary>
        /// Deleta uma doação pelo ID.
        /// </summary>
        Task DeleteDonationAsync(int id);
    }
}
