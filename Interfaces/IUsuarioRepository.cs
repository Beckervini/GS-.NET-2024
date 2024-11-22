using GreenFundGS.Models;
using System.Threading.Tasks;

namespace GreenFundGS.Interfaces
{
    /// <summary>
    /// Interface para o repositório de usuários.
    /// </summary>
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        /// <summary>
        /// Obtém um usuário pelo email.
        /// </summary>
        Task<Usuario> GetByEmailAsync(string email);
    }
}
