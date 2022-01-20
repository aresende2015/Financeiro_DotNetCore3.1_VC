using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.Domain.Entities;

namespace Investimento.Domain.Interfaces.Repositories
{
    public interface IClienteRepo : IGeralRepo
    {
        Task<Cliente[]> GetAllClientesAsync(bool includeAtivos = false);  
        Task<Cliente[]> GetAllClientesByAtivoId(int ativoId, bool includeAtivos = false);      
        Task<Cliente> GetClienteByIdAsync(int id, bool includeAtivos = false);
        Task<Cliente> GetClienteByDescricaoAsync(string descricao);
    }
}