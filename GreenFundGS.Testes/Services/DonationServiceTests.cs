using Xunit;
using Moq;
using GreenFundGS.Interfaces;
using GreenFundGS.Services;
using GreenFundGS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DonationServiceTests
{
    private readonly DonationService _donationService;
    private readonly Mock<IDonationRepository> _mockDonationRepository;

    public DonationServiceTests()
    {
        _mockDonationRepository = new Mock<IDonationRepository>();
        _donationService = new DonationService(_mockDonationRepository.Object);
    }

    [Fact]
    public async Task GetAllDonationsAsync_ShouldReturnListOfDonations()
    {
        // Arrange
        var donations = new List<Donation>
        {
            new Donation { DonationId = 1, ValorDoado = 100 },
            new Donation { DonationId = 2, ValorDoado = 200 }
        };
        _mockDonationRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(donations);

        // Act
        var result = await _donationService.GetAllDonationsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, ((List<Donation>)result).Count);
    }

    [Fact]
    public async Task AddDonationAsync_ShouldCallRepositoryAdd()
    {
        // Arrange
        var newDonation = new Donation { ValorDoado = 150 };

        // Act
        await _donationService.AddDonationAsync(newDonation);

        // Assert
        _mockDonationRepository.Verify(repo => repo.AddAsync(newDonation), Times.Once);
    }
}
