using AutoMapper;
using GreenFundGS.DTOs;
using GreenFundGS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using GreenFundGS.Interfaces;

namespace GreenFundGS.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public AuthController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        /// <summary>
        /// Realiza o login do usuário.
        /// </summary>
        /// <param name="loginDto">Credenciais do usuário, contendo email e senha.</param>
        /// <returns>Token JWT se as credenciais forem válidas.</returns>
        [SwaggerOperation(Summary = "Realiza o login", Description = "Autentica o usuário e retorna um token JWT.")]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = await _usuarioService.AuthenticateUserAsync(loginDto.Email, loginDto.Senha);
            if (usuario == null)
            {
                return Unauthorized(new { Erro = "Credenciais Inválidas" });
            }

            // Token fictício para exemplo
            var token = "token_jwt_simulado";
            return Ok(new { Token = token });
        }
    }
}
