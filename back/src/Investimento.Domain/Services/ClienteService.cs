using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.Domain.Entities;
using Investimento.Domain.Interfaces.Services;

namespace Investimento.Domain.Services
{
    public class ClienteService : IClienteService
    {
        public Task<Cliente> AdicionarCliente(Cliente model)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> AtualizarCliente(Cliente model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarCliente(int clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente[]> GetAllClientesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> GetClienteByIdAsync(int clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InativarCliente(Cliente model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ReativarCliente(Cliente model)
        {
            throw new NotImplementedException();
        }
    }
}