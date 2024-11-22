using Microsoft.AspNetCore.Mvc;
using GreenFundGS.DTOs;

namespace GreenFundGS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatorioController : ControllerBase
    {
        [HttpGet("impact-report")]
        public IActionResult GetImpactReport()
        {
            var report = new RelatorioDto
            {
                EnergiaGerada = 12345.67,
                Co2Evitado = 987.65,
                ProjetosConcluidos = 12
            };

            return Ok(report);
        }
    }
}
