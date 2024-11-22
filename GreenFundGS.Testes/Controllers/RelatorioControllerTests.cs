using Xunit;
using Microsoft.AspNetCore.Mvc;
using GreenFundGS.Controllers;
using GreenFundGS.DTOs;

public class RelatorioControllerTests
{
    private readonly RelatorioController _relatorioController;

    public RelatorioControllerTests()
    {
        _relatorioController = new RelatorioController();
    }

    [Fact]
    public void GetImpactReport_ShouldReturnOkResult_WithReportData()
    {
        // Act
        var result = _relatorioController.GetImpactReport();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = okResult.Value as RelatorioDto;

        Assert.NotNull(returnValue);
        Assert.Equal(12345.67, returnValue.EnergiaGerada);
        Assert.Equal(987.65, returnValue.Co2Evitado);
        Assert.Equal(12, returnValue.ProjetosConcluidos);
    }
}
