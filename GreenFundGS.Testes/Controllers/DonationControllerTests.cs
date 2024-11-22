using Xunit;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GreenFundGS.Controllers;
using GreenFundGS.DTOs;
using GreenFundGS.Interfaces;
using GreenFundGS.Models;

public class DonationControllerTests
{
    private readonly DonationController _donationController;
    private readonly Mock<IDonationService> _mockDonationService;
    private readonly Mock<IProjectService> _mockProjectService;
    private readonly Mock<IUsuarioService> _mockUsuarioService;
    private readonly Mock<IMapper> _mockMapper;

    public DonationControllerTests()
    {
        _mockDonationService = new Mock<IDonationService>();
        _mockProjectService = new Mock<IProjectService>();
        _mockUsuarioService = new Mock<IUsuarioService>();
        _mockMapper = new Mock<IMapper>();

        _donationController = new DonationController(
            _mockDonationService.Object,
            _mockProjectService.Object,
            _mockUsuarioService.Object,
            _mockMapper.Object
        );
    }

    [Fact]
    public async Task CreateDonation_ShouldReturnCreatedAtActionResult_WhenDonationIsValid()
    {
        // Arrange
        var donationDto = new DonationDto { ValorDoado = 150, ProjectId = 1, UserId = 1 };
        var donation = new Donation { DonationId = 1, ValorDoado = 150 };
        var project = new Project { ProjectId = 1, NomeProjeto = "Projeto 1" };
        var user = new Usuario { UserId = 1, NomeCompleto = "User 1" };

        _mockProjectService.Setup(service => service.GetProjectByIdAsync(1)).ReturnsAsync(project);
        _mockUsuarioService.Setup(service => service.GetUsuarioByIdAsync(1)).ReturnsAsync(user);
        _mockMapper.Setup(mapper => mapper.Map<Donation>(donationDto)).Returns(donation);
        _mockDonationService.Setup(service => service.AddDonationAsync(donation)).Returns(Task.CompletedTask);
        _mockMapper.Setup(mapper => mapper.Map<DonationDto>(donation)).Returns(donationDto);

        // Act
        var result = await _donationController.CreateDonation(donationDto);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnValue = Assert.IsType<DonationDto>(createdResult.Value);
        Assert.Equal(150, returnValue.ValorDoado);
    }
}
