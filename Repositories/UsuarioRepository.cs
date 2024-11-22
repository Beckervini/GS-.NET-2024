using GreenFundGS.Data;
using GreenFundGS.Models;
using GreenFundGS.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenFundGS.Repositories
{
    /// <summary>
    /// Implementação do repositório de usuários.
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GreenFundContext _context;

        public UsuarioRepository(GreenFundContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém todos os usuários.
        /// </summary>
        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        /// <summary>
        /// Obtém um usuário pelo ID.
        /// </summary>
        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        /// <summary>
        /// Adiciona um novo usuário.
        /// </summary>
        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deleta um usuário pelo ID.
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var usuario = await GetByIdAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Obtém um usuário pelo email.
        /// </summary>
        public async Task<Usuario> GetByEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
