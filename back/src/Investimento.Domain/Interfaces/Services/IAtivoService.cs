using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.Domain.Entities;

namespace Investimento.Domain.Interfaces.Services
{
    public interface IAtivoService
    {
        Task<Ativo> AdicionarAtivo(Ativo model);
        Task<Ativo> AtualizarAtivo(Ativo model);
        Task<bool> DeletarAtivo(int ativoId);
        
        Task<bool> InativarAtivo(Ativo model);
        Task<bool> ReativarAtivo(Ativo model);

        Task<Ativo[]> GetAllAtivosAsync();
        Task<Ativo> GetAtivoByIdAsync(int ativoId);
    }
}