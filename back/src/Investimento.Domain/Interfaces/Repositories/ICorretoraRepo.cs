using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.Domain.Entities;

namespace Investimento.Domain.Interfaces.Repositories
{
    public interface ICorretoraRepo : IGeralRepo
    {
        Task<Corretora[]> GetAllCorretorasAsync(bool includeCliente = false);  
        Task<Corretora[]> GetAllCorretorasByClienteId(int clienteId, bool includeCliente = false);      
        Task<Corretora> GetCorretoraByIdAsync(int id, bool includeCliente = false);
        Task<Corretora> GetCorretoraByDescricaoAsync(string descricao);
    }
}