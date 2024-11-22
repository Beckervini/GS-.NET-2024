using GreenFundGS.Models;
using GreenFundGS.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using GreenFundGS.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenFundGS.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna uma lista de usuários.
        /// </summary>
        /// <returns>Lista de usuários</returns>
        [SwaggerOperation(Summary = "Obtém todos os usuários", Description = "Retorna uma lista de todos os usuários existentes.")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetAllUsuarios()
        {
            var usuarios = await _usuarioService.GetAllUsuariosAsync();
            var usuarioDtos = _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
            return Ok(usuarioDtos);
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="usuarioDto">Detalhes do usuário</param>
        /// <returns>Usuário criado</returns>
        [SwaggerOperation(Summary = "Cria um novo usuário", Description = "Adiciona um novo usuário ao sistema.")]
        [HttpPost]
        public async Task<ActionResult> CreateUsuario([FromBody] UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            await _usuarioService.AddUsuarioAsync(usuario);
            var createdUsuarioDto = _mapper.Map<UsuarioDto>(usuario);
            return CreatedAtAction(nameof(GetAllUsuarios), new { id = createdUsuarioDto.UserId }, createdUsuarioDto);
        }
    }
}
