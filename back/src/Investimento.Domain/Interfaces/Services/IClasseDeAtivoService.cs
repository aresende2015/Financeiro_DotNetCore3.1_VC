using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.Domain.Entities;

namespace Investimento.Domain.Interfaces.Services
{
    public interface IClasseDeAtivoService
    {
        Task<ClasseDeAtivo> AdicionarClasseDeAtivo(ClasseDeAtivo model);
        Task<ClasseDeAtivo> AtualizarClasseDeAtivo(ClasseDeAtivo model);

        Task<bool> DeletarClasseDeAtivo(int classeDeAtivoId);
        Task<bool> InativarClasseDeAtivo(ClasseDeAtivo model);
        Task<bool> ReativarClasseDeAtivo(ClasseDeAtivo model);

        Task<ClasseDeAtivo[]> GetAllClassesDeAtivosAsync();
        Task<ClasseDeAtivo> GetClasseDeAtivoByIdAsync(int classeDeAtivoId);
    }
}