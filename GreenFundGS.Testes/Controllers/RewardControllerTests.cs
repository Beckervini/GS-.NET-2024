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

namespace GreenFundGS.Testes.Controllers
{
    /// <summary>
    /// Testes unitários para o RewardController.
    /// </summary>
    public class RewardControllerTests
    {
        private readonly RewardController _rewardController;
        private readonly Mock<IRewardService> _mockRewardService;
        private readonly Mock<IMapper> _mockMapper;

        /// <summary>
        /// Configuração inicial para os testes do RewardController.
        /// </summary>
        public RewardControllerTests()
        {
            _mockRewardService = new Mock<IRewardService>();
            _mockMapper = new Mock<IMapper>();
            _rewardController = new RewardController(_mockRewardService.Object, _mockMapper.Object);
        }

        /// <summary>
        /// Verifica se GetAllRewards retorna a lista esperada de recompensas.
        /// </summary>
        [Fact]
        public async Task GetAllRewards_ShouldReturnOkResult_WithListOfRewards()
        {
            var rewards = new List<Reward>
            {
                new Reward { RewardId = 1, Descricao = "Reward A", Type = "Certificate", Points = 50 },
                new Reward { RewardId = 2, Descricao = "Reward B", Type = "Badge", Points = 100 }
            };
            var rewardDtos = new List<RewardDto>
            {
                new RewardDto { RewardId = 1, Descricao = "Reward A", Type = "Certificate", Points = 50 },
                new RewardDto { RewardId = 2, Descricao = "Reward B", Type = "Badge", Points = 100 }
            };

            _mockRewardService.Setup(service => service.GetAllRewardsAsync()).ReturnsAsync(rewards);
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<RewardDto>>(rewards)).Returns(rewardDtos);

            var result = await _rewardController.GetAllRewards();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<RewardDto>>(okResult.Value);
            Assert.Equal(2, ((List<RewardDto>)returnValue).Count);
        }

        /// <summary>
        /// Verifica se CreateReward cria uma recompensa válida.
        /// </summary>
        [Fact]
        public async Task CreateReward_ShouldReturnCreatedAtActionResult_WhenRewardIsValid()
        {
            var rewardDto = new RewardDto { Descricao = "Nova Recompensa", Type = "Certificate", Points = 100 };
            var reward = new Reward { RewardId = 1, Descricao = "Nova Recompensa", Type = "Certificate", Points = 100 };

            _mockMapper.Setup(mapper => mapper.Map<Reward>(rewardDto)).Returns(reward);
            _mockRewardService.Setup(service => service.AddRewardAsync(reward)).Returns(Task.CompletedTask);
            _mockMapper.Setup(mapper => mapper.Map<RewardDto>(reward)).Returns(rewardDto);

            var result = await _rewardController.CreateReward(rewardDto);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnValue = Assert.IsType<RewardDto>(createdResult.Value);
            Assert.Equal("Nova Recompensa", returnValue.Descricao);
        }
    }
}
