using Xunit;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GreenFundGS.Controllers;
using GreenFundGS.DTOs;
using GreenFundGS.Interfaces;
using GreenFundGS.Models;

public class AuthControllerTests
{
    private readonly AuthController _authController;
    private readonly Mock<IUsuarioService> _mockUsuarioService;
    private readonly Mock<IMapper> _mockMapper;

    public AuthControllerTests()
    {
        _mockUsuarioService = new Mock<IUsuarioService>();
        _mockMapper = new Mock<IMapper>();

        _authController = new AuthController(
            _mockUsuarioService.Object,
            _mockMapper.Object
        );
    }

    [Fact]
    public async Task Login_ShouldReturnOkResult_WhenCredentialsAreValid()
    {
        // Arrange
        var loginDto = new LoginDto { Email = "test@example.com", Senha = "password123" };
        var usuario = new Usuario { UserId = 1, Email = "test@example.com", Senha = "password123" };

        _mockUsuarioService.Setup(service => service.AuthenticateUserAsync(loginDto.Email, loginDto.Senha))
            .ReturnsAsync(usuario);

        // Act
        var result = await _authController.Login(loginDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = okResult.Value;

        Assert.NotNull(returnValue);
        // Verifique os dados retornados de acordo com o que seu projeto espera.
    }
    [Fact]
    public async Task Login_ShouldReturnUnauthorized_WhenCredentialsAreInvalid()
    {
        // Arrange
        var loginDto = new LoginDto { Email = "invalid@example.com", Senha = "wrongpassword" };

        _mockUsuarioService.Setup(service => service.AuthenticateUserAsync(loginDto.Email, loginDto.Senha))
            .ReturnsAsync((Usuario)null);

        // Act
        var result = await _authController.Login(loginDto);

        // Assert
        Assert.IsType<UnauthorizedObjectResult>(result);
    }
}
