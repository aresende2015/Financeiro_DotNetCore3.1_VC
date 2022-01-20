using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.Domain.Entities;

namespace Investimento.Domain.Interfaces.Repositories
{
    public interface IAtivoRepo : IGeralRepo
    {
        Task<Ativo[]> GetAllAtivosAsync(bool includeClasseDeAtivo = false);
        Task<Ativo[]> GetAllAtivosByClasseDeAtivoId(int classeDeAtivoId, bool includeClasseDeAtivo = false);
        Task<Ativo> GetAtivoByIdAsync(int id, bool includeClasseDeAtivo = false);
        Task<Ativo> GetAtivoByDescricaoAsync(string descricao);        
    }
}