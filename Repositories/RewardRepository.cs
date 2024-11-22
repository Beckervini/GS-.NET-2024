using GreenFundGS.Data;
using GreenFundGS.Interfaces;
using GreenFundGS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenFundGS.Repositories
{
    /// <summary>
    /// Implementação do repositório de Reward.
    /// </summary>
    public class RewardRepository : IRewardRepository
    {
        private readonly GreenFundContext _context;

        public RewardRepository(GreenFundContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reward>> GetAllAsync()
        {
            return await _context.Rewards.ToListAsync();
        }

        public async Task<Reward> GetByIdAsync(int id)
        {
            return await _context.Rewards.FindAsync(id);
        }

        public async Task AddAsync(Reward reward)
        {
            await _context.Rewards.AddAsync(reward);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Reward reward)
        {
            _context.Rewards.Remove(reward);
            await _context.SaveChangesAsync();
        }
    }
}
