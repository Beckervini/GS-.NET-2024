using GreenFundGS.Interfaces;
using GreenFundGS.Models;
using GreenFundGS.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace GreenFundGS.Testes.Services
{
    public class RewardServiceTests
    {
        [Fact]
        public async Task AddRewardAsync_ShouldSaveReward()
        {
            // Arrange
            var rewardRepositoryMock = new Mock<IRewardRepository>();
            var rewardFactoryMock = new Mock<IRewardFactory>();
            var rewardService = new RewardService(rewardRepositoryMock.Object, rewardFactoryMock.Object);

            var reward = new Reward
            {
                Type = "Certificate",
                Descricao = "Certificate of Contribution",
                Points = 100
            };

            // Act
            await rewardService.AddRewardAsync(reward);

            // Assert
            rewardRepositoryMock.Verify(r => r.AddAsync(reward), Times.Once);
        }
    }
}
