using GreenFundGS.Models;
using GreenFundGS.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenFundGS.Services
{
    /// <summary>
    /// Implementação do serviço de usuários.
    /// </summary>
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Obtém todos os usuários.
        /// </summary>
        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        /// <summary>
        /// Obtém um usuário pelo ID.
        /// </summary>
        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Obtém um usuário pelo email.
        /// </summary>
        public async Task<Usuario> GetUsuarioByEmailAsync(string email)
        {
            return await _usuarioRepository.GetByEmailAsync(email);
        }

        /// <summary>
        /// Autentica um usuário com base em email e senha.
        /// </summary>
        public async Task<Usuario> AuthenticateUserAsync(string email, string senha)
        {
            var usuario = await GetUsuarioByEmailAsync(email);
            if (usuario != null && usuario.Senha == senha) // Verifique se 'Senha' é a propriedade correta
            {
                return usuario;
            }
            return null;
        }

        /// <summary>
        /// Adiciona um novo usuário.
        /// </summary>
        public async Task AddUsuarioAsync(Usuario usuario)
        {
            await _usuarioRepository.AddAsync(usuario);
        }

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            await _usuarioRepository.UpdateAsync(usuario);
        }

        /// <summary>
        /// Deleta um usuário pelo ID.
        /// </summary>
        public async Task DeleteUsuarioAsync(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }
    }
}
