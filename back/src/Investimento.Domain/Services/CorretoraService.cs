using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.Domain.Entities;
using Investimento.Domain.Interfaces.Services;

namespace Investimento.Domain.Services
{
    public class CorretoraService : ICorretoraService
    {
        public Task<Corretora> AdicionarCorretora(Corretora model)
        {
            throw new NotImplementedException();
        }

        public Task<Corretora> AtualizarCorretora(Corretora model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarCorretora(int corretoraId)
        {
            throw new NotImplementedException();
        }

        public Task<Corretora[]> GetAllCorretorasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Corretora> GetCorretoraByIdAsync(int corretoraId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InativarCorretora(Corretora model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ReativarCorretora(Corretora model)
        {
            throw new NotImplementedException();
        }
    }
}