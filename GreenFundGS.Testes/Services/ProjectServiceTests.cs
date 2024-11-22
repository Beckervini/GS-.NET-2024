using Xunit;
using Moq;
using GreenFundGS.Interfaces;
using GreenFundGS.Services;
using GreenFundGS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProjectServiceTests
{
    private readonly ProjectService _projectService;
    private readonly Mock<IProjectRepository> _mockProjectRepository;

    public ProjectServiceTests()
    {
        _mockProjectRepository = new Mock<IProjectRepository>();
        _projectService = new ProjectService(_mockProjectRepository.Object);
    }

    [Fact]
    public async Task GetAllProjectsAsync_ShouldReturnListOfProjects()
    {
        // Arrange
        var projects = new List<Project>
        {
            new Project { ProjectId = 1, NomeProjeto = "Projeto A", Descricao = "Descrição A" },
            new Project { ProjectId = 2, NomeProjeto = "Projeto B", Descricao = "Descrição B" }
        };
        _mockProjectRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(projects);

        // Act
        var result = await _projectService.GetAllProjectsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, ((List<Project>)result).Count);
    }

    [Fact]
    public async Task AddProjectAsync_ShouldCallRepositoryAdd()
    {
        // Arrange
        var newProject = new Project { NomeProjeto = "Novo Projeto", Descricao = "Descrição do projeto" };

        // Act
        await _projectService.AddProjectAsync(newProject);

        // Assert
        _mockProjectRepository.Verify(repo => repo.AddAsync(newProject), Times.Once);
    }
}
