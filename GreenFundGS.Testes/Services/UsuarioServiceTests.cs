using Xunit;
using Moq;
using GreenFundGS.Interfaces;
using GreenFundGS.Services;
using GreenFundGS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UsuarioServiceTests
{
    private readonly UsuarioService _usuarioService;
    private readonly Mock<IUsuarioRepository> _mockUsuarioRepository;

    public UsuarioServiceTests()
    {
        _mockUsuarioRepository = new Mock<IUsuarioRepository>();
        _usuarioService = new UsuarioService(_mockUsuarioRepository.Object);
    }

    [Fact]
    public async Task GetAllUsuariosAsync_ShouldReturnListOfUsuarios()
    {
        // Arrange
        var usuarios = new List<Usuario>
        {
            new Usuario { UserId = 1, NomeCompleto = "User A" },
            new Usuario { UserId = 2, NomeCompleto = "User B" }
        };
        _mockUsuarioRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(usuarios);

        // Act
        var result = await _usuarioService.GetAllUsuariosAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, ((List<Usuario>)result).Count);
    }

    [Fact]
    public async Task AddUsuarioAsync_ShouldCallRepositoryAdd()
    {
        // Arrange
        var newUsuario = new Usuario { NomeCompleto = "Novo Usuario" };

        // Act
        await _usuarioService.AddUsuarioAsync(newUsuario);

        // Assert
        _mockUsuarioRepository.Verify(repo => repo.AddAsync(newUsuario), Times.Once);
    }
}
