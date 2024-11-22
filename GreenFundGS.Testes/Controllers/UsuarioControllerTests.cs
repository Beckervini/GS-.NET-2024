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

public class UsuarioControllerTests
{
    private readonly UsuarioController _usuarioController;
    private readonly Mock<IUsuarioService> _mockUsuarioService;
    private readonly Mock<IMapper> _mockMapper;

    public UsuarioControllerTests()
    {
        _mockUsuarioService = new Mock<IUsuarioService>();
        _mockMapper = new Mock<IMapper>();
        _usuarioController = new UsuarioController(_mockUsuarioService.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetAllUsuarios_ShouldReturnOkResult_WithListOfUsuarios()
    {
        // Arrange
        var usuarios = new List<Usuario>
        {
            new Usuario { UserId = 1, NomeCompleto = "User A" },
            new Usuario { UserId = 2, NomeCompleto = "User B" }
        };
        var usuarioDtos = new List<UsuarioDto>
        {
            new UsuarioDto { UserId = 1, NomeCompleto = "User A" },
            new UsuarioDto { UserId = 2, NomeCompleto = "User B" }
        };

        _mockUsuarioService.Setup(service => service.GetAllUsuariosAsync()).ReturnsAsync(usuarios);
        _mockMapper.Setup(mapper => mapper.Map<IEnumerable<UsuarioDto>>(usuarios)).Returns(usuarioDtos);

        // Act
        var result = await _usuarioController.GetAllUsuarios();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsAssignableFrom<IEnumerable<UsuarioDto>>(okResult.Value);
        Assert.Equal(2, ((List<UsuarioDto>)returnValue).Count);
    }

    [Fact]
    public async Task CreateUsuario_ShouldReturnCreatedAtActionResult_WhenUsuarioIsValid()
    {
        // Arrange
        var usuarioDto = new UsuarioDto { NomeCompleto = "Novo Usuario" };
        var usuario = new Usuario { UserId = 1, NomeCompleto = "Novo Usuario" };

        _mockMapper.Setup(mapper => mapper.Map<Usuario>(usuarioDto)).Returns(usuario);
        _mockUsuarioService.Setup(service => service.AddUsuarioAsync(usuario)).Returns(Task.CompletedTask);
        _mockMapper.Setup(mapper => mapper.Map<UsuarioDto>(usuario)).Returns(usuarioDto);

        // Act
        var result = await _usuarioController.CreateUsuario(usuarioDto);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnValue = Assert.IsType<UsuarioDto>(createdResult.Value);
        Assert.Equal("Novo Usuario", returnValue.NomeCompleto);
    }
}
