using GreenFundGS.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using GreenFundGS.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using GreenFundGS.Interfaces;

namespace GreenFundAPI.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna uma lista de projetos.
        /// </summary>
        /// <returns>Lista de projetos</returns>
        [SwaggerOperation(Summary = "Obtém todos os projetos", Description = "Retorna uma lista de todos os projetos existentes.")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAllProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            var projectDtos = _mapper.Map<IEnumerable<ProjectDto>>(projects);
            return Ok(projectDtos);
        }

        /// <summary>
        /// Cria um novo projeto.
        /// </summary>
        /// <param name="projectDto">Detalhes do projeto</param>
        /// <returns>Projeto criado</returns>
        [SwaggerOperation(Summary = "Cria um novo projeto", Description = "Adiciona um novo projeto ao sistema.")]
        [HttpPost]
        public async Task<ActionResult> CreateProject([FromBody] ProjectDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            await _projectService.AddProjectAsync(project);
            var createdProjectDto = _mapper.Map<ProjectDto>(project);
            return CreatedAtAction(nameof(GetAllProjects), new { id = createdProjectDto.ProjectId }, createdProjectDto);
        }

        /// <summary>
        /// Atualiza um projeto existente pelo ID.
        /// </summary>
        /// <param name="id">ID do projeto a ser atualizado.</param>
        /// <param name="projectDto">Detalhes do projeto atualizado.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditProject(int id, [FromBody] ProjectDto projectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            projectDto.ProjectId = id;

            var existingProject = await _projectService.GetProjectByIdAsync(id);
            if (existingProject == null)
            {
                return NotFound();
            }

            var project = _mapper.Map(projectDto, existingProject);
            await _projectService.UpdateProjectAsync(project);
            return Ok(projectDto);
        }

        /// <summary>
        /// Deleta um projeto pelo ID.
        /// </summary>
        /// <param name="id">ID do projeto a ser deletado.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            await _projectService.DeleteProjectAsync(id);
            return NoContent();
        }
    }
}
