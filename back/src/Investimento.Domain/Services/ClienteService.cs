using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.Domain.Entities;
using Investimento.Domain.Interfaces.Repositories;
using Investimento.Domain.Interfaces.Services;

namespace Investimento.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepo _clienteRepo;
        public ClienteService(IClienteRepo clienteRepo)
        {
            _clienteRepo = clienteRepo;
            
        }
        public async Task<Cliente> AdicionarCliente(Cliente model)
        {
            if (model.Inativo)
                throw new Exception("Não é possível incluir um Cliente já inativo.");

            if (await _clienteRepo.GetClienteByCpfAsync(model.Cpf) != null)
                throw new Exception("Já existe um Cliente com esse CPF.");

            if( await _clienteRepo.GetClienteByIdAsync(model.Id) == null)
            {
                _clienteRepo.Adicionar(model);
                if (await _clienteRepo.SalvarMudancasAsync())
                    return model;
            }

            return null;
        }

        public async Task<Cliente> AtualizarCliente(Cliente model)
        {
            if (model.Inativo)
                throw new Exception("Não é possível atualizar um Cliente já inativo.");

            var cliente = await _clienteRepo.GetClienteByIdAsync(model.Id);

            if (cliente != null)
            {
                if (cliente.Inativo)
                    throw new Exception("Não se pode alterar um Cliente inativo.");

                _clienteRepo.Atualizar(model);

                if (await _clienteRepo.SalvarMudancasAsync())
                    return model;
            }

            return null;
        }

        public async Task<bool> DeletarCliente(int clienteId)
        {
            var cliente = await _clienteRepo.GetClienteByIdAsync(clienteId);

            if (cliente == null)
                throw new Exception("O Cliente que tentou deletar não existe.");

            _clienteRepo.Deletar(cliente);

            return await _clienteRepo.SalvarMudancasAsync();
        }

        public async Task<Cliente[]> GetAllClientesAsync()
        {
            try
            {
                var clientes = await _clienteRepo.GetAllClientesAsync(true);

                if (clientes == null) return null;

                return clientes;     
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente> GetClienteByIdAsync(int clienteId)
        {
            try
            {
                var cliente = await _clienteRepo.GetClienteByIdAsync(clienteId);

                if (cliente == null) return null;

                return cliente;     
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> InativarCliente(Cliente model)
        {
            if (model != null)
            {
                model.Inativar();
                _clienteRepo.Atualizar(model);
                return await _clienteRepo.SalvarMudancasAsync();
            }

            return false;
        }

        public async Task<bool> ReativarCliente(Cliente model)
        {
            if (model != null)
            {
                model.Reativar();
                _clienteRepo.Atualizar(model);
                return await _clienteRepo.SalvarMudancasAsync();
            }

            return false;
        }
    }
}