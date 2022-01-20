using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.Domain.Entities;

namespace Investimento.Domain.Interfaces.Repositories
{
    public interface IAtivoRepo : IGeralRepo
    {
        Task<Ativo[]> GetAllAtivosAsync();
        Task<Ativo[]> GetAllAtivosByClasseDeAtivoId();
        Task<Ativo> GetAtivoByIdAsync(int id);
        Task<Ativo> GetAtivoByDescricaoAsync(string descricao);        
    }
}