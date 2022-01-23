using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.Domain.Entities;

namespace Investimento.Domain.Interfaces.Repositories
{
    public interface IClienteRepo : IGeralRepo
    {
        Task<Cliente[]> GetAllClientesAsync(bool includeCorretora = false);  
        Task<Cliente[]> GetAllClientesByCorretoraId(int corretoraId, bool includeCorretora = false);      
        Task<Cliente> GetClienteByIdAsync(int id, bool includeCorretora = false);
        Task<Cliente> GetClienteByCpfAsync(string cpf);
    }
}