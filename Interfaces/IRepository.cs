using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenFundGS.Interfaces
{
    /// <summary>
    /// Interface genérica para repositórios.
    /// </summary>
    /// <typeparam name="T">Tipo da entidade.</typeparam>
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync(); // Método que precisa ser implementado
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
