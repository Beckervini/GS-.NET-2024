using GreenFundGS.Data;
using GreenFundGS.Models;
using GreenFundGS.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenFundGS.Repositories
{
    /// <summary>
    /// Implementação do repositório de projetos.
    /// </summary>
    public class ProjectRepository : IProjectRepository
    {
        private readonly GreenFundContext _context;

        public ProjectRepository(GreenFundContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém todos os projetos.
        /// </summary>
        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        /// <summary>
        /// Obtém um projeto pelo ID.
        /// </summary>
        public async Task<Project> GetByIdAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        /// <summary>
        /// Adiciona um novo projeto.
        /// </summary>
        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um projeto existente.
        /// </summary>
        public async Task UpdateAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deleta um projeto pelo ID.
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var project = await GetByIdAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }
    }
}
