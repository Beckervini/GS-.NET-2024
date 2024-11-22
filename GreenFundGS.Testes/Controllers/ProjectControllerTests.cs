using Xunit;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GreenFundGS.Controllers;
using GreenFundGS.DTOs;
using GreenFundGS.Interfaces;
using GreenFundGS.Models;
using GreenFundAPI.Controllers;

public class ProjectControllerTests
{
    private readonly ProjectController _projectController;
    private readonly Mock<IProjectService> _mockProjectService;
    private readonly Mock<IMapper> _mockMapper;

    public ProjectControllerTests()
    {
        _mockProjectService = new Mock<IProjectService>();
        _mockMapper = new Mock<IMapper>();
        _projectController = new ProjectController(_mockProjectService.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetAllProjects_ShouldReturnOkResult_WithListOfProjects()
    {
        // Arrange
        var projects = new List<Project>
        {
            new Project { ProjectId = 1, NomeProjeto = "Projeto A", Descricao = "Descrição A" },
            new Project { ProjectId = 2, NomeProjeto = "Projeto B", Descricao = "Descrição B" }
        };
        var projectDtos = new List<ProjectDto>
        {
            new ProjectDto { ProjectId = 1, NomeProjeto = "Projeto A", Descricao = "Descrição A" },
            new ProjectDto { ProjectId = 2, NomeProjeto = "Projeto B", Descricao = "Descrição B" }
        };

        _mockProjectService.Setup(service => service.GetAllProjectsAsync()).ReturnsAsync(projects);
        _mockMapper.Setup(mapper => mapper.Map<IEnumerable<ProjectDto>>(projects)).Returns(projectDtos);

        // Act
        var result = await _projectController.GetAllProjects();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsAssignableFrom<IEnumerable<ProjectDto>>(okResult.Value);
        Assert.Equal(2, ((List<ProjectDto>)returnValue).Count);
    }

    [Fact]
    public async Task CreateProject_ShouldReturnCreatedAtActionResult_WhenProjectIsValid()
    {
        // Arrange
        var projectDto = new ProjectDto { NomeProjeto = "Novo Projeto", Descricao = "Descrição do projeto" };
        var project = new Project { ProjectId = 1, NomeProjeto = "Novo Projeto", Descricao = "Descrição do projeto" };

        _mockMapper.Setup(mapper => mapper.Map<Project>(projectDto)).Returns(project);
        _mockProjectService.Setup(service => service.AddProjectAsync(project)).Returns(Task.CompletedTask);
        _mockMapper.Setup(mapper => mapper.Map<ProjectDto>(project)).Returns(projectDto);

        // Act
        var result = await _projectController.CreateProject(projectDto);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnValue = Assert.IsType<ProjectDto>(createdResult.Value);
        Assert.Equal("Novo Projeto", returnValue.NomeProjeto);
    }

    [Fact]
    public async Task EditProject_ShouldReturnOkResult_WhenProjectIsUpdated()
    {
        // Arrange
        var projectId = 1;
        var projectDto = new ProjectDto { ProjectId = projectId, NomeProjeto = "Projeto Atualizado", Descricao = "Descrição Atualizada", Progresso = 50, ImpactoEstimado = "Impacto Atualizado" };
        var existingProject = new Project { ProjectId = projectId };

        _mockProjectService.Setup(service => service.GetProjectByIdAsync(projectId)).ReturnsAsync(existingProject);
        _mockProjectService.Setup(service => service.UpdateProjectAsync(It.IsAny<Project>())).Returns(Task.CompletedTask);

        // Act
        var result = await _projectController.EditProject(projectId, projectDto);

        // Assert
        Assert.IsType<OkObjectResult>(result);
        _mockProjectService.Verify(service => service.UpdateProjectAsync(It.IsAny<Project>()), Times.Once);
    }

    [Fact]
    public async Task DeleteProject_ShouldReturnNoContentResult_WhenProjectIsDeleted()
    {
        // Arrange
        var projectId = 1;
        var existingProject = new Project { ProjectId = projectId };

        _mockProjectService.Setup(service => service.GetProjectByIdAsync(projectId)).ReturnsAsync(existingProject);
        _mockProjectService.Setup(service => service.DeleteProjectAsync(projectId)).Returns(Task.CompletedTask);

        // Act
        var result = await _projectController.DeleteProject(projectId);

        // Assert
        Assert.IsType<NoContentResult>(result);
        _mockProjectService.Verify(service => service.DeleteProjectAsync(projectId), Times.Once);
    }
}
