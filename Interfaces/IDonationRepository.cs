using GreenFundGS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenFundGS.Interfaces
{
    /// <summary>
    /// Interface específica para o repositório de doações.
    /// </summary>
    public interface IDonationRepository : IRepository<Donation>
    {
        // Métodos adicionais específicos de doações, se houver.
    }
}

