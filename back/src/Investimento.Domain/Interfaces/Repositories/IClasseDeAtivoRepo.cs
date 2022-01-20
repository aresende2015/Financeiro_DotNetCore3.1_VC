using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.Domain.Entities;

namespace Investimento.Domain.Interfaces.Repositories
{
    public interface IClasseDeAtivoRepo : IGeralRepo
    {
        Task<ClasseDeAtivo[]> GetAllClasseDeAtivosAsync(bool includeAtivos = false);  
        Task<ClasseDeAtivo[]> GetAllClasseDeAtivosByAtivoId(int ativoId, bool includeAtivos = false);      
        Task<ClasseDeAtivo> GetClasseDeAtivoByIdAsync(int id, bool includeAtivos = false);
        Task<ClasseDeAtivo> GetClasseDeAtivoByDescricaoAsync(string descricao);
    }
}