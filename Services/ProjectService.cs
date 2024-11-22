using GreenFundGS.Models;
using GreenFundGS.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenFundGS.Services
{
    /// <summary>
    /// Implementação do serviço de projetos.
    /// </summary>
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        /// <summary>
        /// Obtém todos os projetos.
        /// </summary>
        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _projectRepository.GetAllAsync();
        }

        /// <summary>
        /// Obtém um projeto pelo ID.
        /// </summary>
        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _projectRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Adiciona um novo projeto.
        /// </summary>
        public async Task AddProjectAsync(Project project)
        {
            await _projectRepository.AddAsync(project);
        }

        /// <summary>
        /// Atualiza um projeto existente.
        /// </summary>
        public async Task UpdateProjectAsync(Project project)
        {
            await _projectRepository.UpdateAsync(project);
        }

        /// <summary>
        /// Deleta um projeto pelo ID.
        /// </summary>
        public async Task DeleteProjectAsync(int id)
        {
            await _projectRepository.DeleteAsync(id);
        }
    }
}
