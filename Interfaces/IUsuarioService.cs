using GreenFundGS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenFundGS.Interfaces
{
    /// <summary>
    /// Interface para o serviço de gerenciamento de usuários.
    /// </summary>
    public interface IUsuarioService
    {
        /// <summary>
        /// Obtém todos os usuários.
        /// </summary>
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();

        /// <summary>
        /// Obtém um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário</param>
        Task<Usuario> GetUsuarioByIdAsync(int id);

        /// <summary>
        /// Obtém um usuário pelo email.
        /// </summary>
        /// <param name="email">Email do usuário</param>
        Task<Usuario> GetUsuarioByEmailAsync(string email);

        /// <summary>
        /// Adiciona um novo usuário.
        /// </summary>
        /// <param name="usuario">Usuário a ser adicionado</param>
        Task AddUsuarioAsync(Usuario usuario);

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        /// <param name="usuario">Usuário a ser atualizado</param>
        Task UpdateUsuarioAsync(Usuario usuario);

        /// <summary>
        /// Deleta um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário</param>
        Task DeleteUsuarioAsync(int id);

        /// <summary>
        /// Autentica um usuário com base em email e senha.
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Usuário autenticado ou null se falhar</returns>
        Task<Usuario> AuthenticateUserAsync(string email, string senha);
    }
}
