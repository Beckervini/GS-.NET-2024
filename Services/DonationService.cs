using GreenFundGS.Models;
using GreenFundGS.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenFundGS.Services
{
    /// <summary>
    /// Implementação do serviço de doações.
    /// </summary>
    public class DonationService : IDonationService
    {
        private readonly IDonationRepository _donationRepository;

        public DonationService(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        /// <summary>
        /// Obtém todas as doações.
        /// </summary>
        public async Task<IEnumerable<Donation>> GetAllDonationsAsync()
        {
            return await _donationRepository.GetAllAsync();
        }

        /// <summary>
        /// Obtém uma doação pelo ID.
        /// </summary>
        public async Task<Donation> GetDonationByIdAsync(int id)
        {
            return await _donationRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Adiciona uma nova doação.
        /// </summary>
        public async Task AddDonationAsync(Donation donation)
        {
            await _donationRepository.AddAsync(donation);
        }

        /// <summary>
        /// Deleta uma doação pelo ID.
        /// </summary>
        public async Task DeleteDonationAsync(int id)
        {
            await _donationRepository.DeleteAsync(id);
        }
    }
}
