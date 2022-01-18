using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.Domain.Entities;

namespace Investimento.Domain.Interfaces.Repositories
{
    public interface IClasseDeAtivoRepo : IGeralRepo
    {
        Task<ClasseDeAtivo[]> PegaTodasAsync();        
        Task<ClasseDeAtivo> PegaPorIdAsync(int id);
        Task<ClasseDeAtivo> PegaPorDescricaoAsync(string descricao);
    }
}