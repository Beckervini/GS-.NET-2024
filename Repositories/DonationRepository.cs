using GreenFundGS.Data;
using GreenFundGS.Models;
using GreenFundGS.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenFundGS.Repositories
{
    /// <summary>
    /// Implementação do repositório de doações, responsável por interagir com o banco de dados para operações relacionadas a doações.
    /// </summary>
    public class DonationRepository : IDonationRepository
    {
        private readonly GreenFundContext _context;

        /// <summary>
        /// Construtor da classe DonationRepository.
        /// </summary>
        /// <param name="context">Contexto do banco de dados injetado.</param>
        public DonationRepository(GreenFundContext context)
        {
            _context = context;
        }

        // Implementação dos métodos da interface
        public async Task<IEnumerable<Donation>> GetAllAsync()
        {
            return await _context.Donations.Include(d => d.Project).ToListAsync();
        }

        public async Task<Donation> GetByIdAsync(int id)
        {
            return await _context.Donations.Include(d => d.Project).FirstOrDefaultAsync(d => d.DonationId == id);
        }

        public async Task AddAsync(Donation donation)
        {
            donation.Project = await _context.Projects.FindAsync(donation.ProjectId);
            if (donation.Project == null)
            {
                throw new DbUpdateException("O projeto associado não foi encontrado.");
            }

            await _context.Donations.AddAsync(donation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Donation donation)
        {
            _context.Donations.Update(donation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var donation = await GetByIdAsync(id);
            if (donation != null)
            {
                _context.Donations.Remove(donation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
