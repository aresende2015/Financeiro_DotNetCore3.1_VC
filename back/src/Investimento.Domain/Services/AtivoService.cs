using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.Domain.Entities;
using Investimento.Domain.Interfaces.Repositories;
using Investimento.Domain.Interfaces.Services;

namespace Investimento.Domain.Services
{
    public class AtivoService : IAtivoService
    {
        private readonly IAtivoRepo _ativoRepo;
        public AtivoService(IAtivoRepo ativoRepo)
        {
            _ativoRepo = ativoRepo;
            
        }
        public async Task<Ativo> AdicionarAtivo(Ativo model)
        {
            if (model.Inativo)
                throw new Exception("Não é possível incluir um Ativo já inativo.");

            if (await _ativoRepo.GetAtivoByDescricaoAsync(model.Descricao) != null)
                throw new Exception("Já existe um Ativo com essa descrição.");

            if( await _ativoRepo.GetAtivoByIdAsync(model.Id) == null)
            {
                _ativoRepo.Adicionar(model);
                if (await _ativoRepo.SalvarMudancasAsync())
                    return model;
            }

            return null;
        }

        public async Task<Ativo> AtualizarAtivo(Ativo model)
        {
            if (model.Inativo)
                throw new Exception("Não é possível atualizar um Ativo já inativo.");

            var ativo = await _ativoRepo.GetAtivoByIdAsync(model.Id);

            if (ativo != null)
            {
                if (ativo.Inativo)
                    throw new Exception("Não se pode alterar um Ativo inativo.");

                _ativoRepo.Atualizar(model);

                if (await _ativoRepo.SalvarMudancasAsync())
                    return model;
            }

            return null;
        }

        public async Task<bool> DeletarAtivo(int ativoId)
        {
            var ativo = await _ativoRepo.GetAtivoByIdAsync(ativoId);

            if (ativo == null)
                throw new Exception("O Ativo que tentou deletar não existe.");

            _ativoRepo.Deletar(ativo);

            return await _ativoRepo.SalvarMudancasAsync();
        }
        public async Task<bool> InativarAtivo(Ativo model)
        {
            if (model != null)
            {
                model.Inativar();
                _ativoRepo.Atualizar(model);
                return await _ativoRepo.SalvarMudancasAsync();
            }

            return false;
        }

        public async Task<Ativo> GetAtivoByIdAsync(int ativoId)
        {
            try
            {
                var ativo = await _ativoRepo.GetAtivoByIdAsync(ativoId);

                if (ativo == null) return null;

                return ativo;     
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<Ativo[]> GetAllAtivosAsync()
        {
            try
            {
                var ativos = await _ativoRepo.GetAllAtivosAsync();

                if (ativos == null) return null;

                return ativos;     
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ReativarAtivo(Ativo model)
        {
            if (model != null)
            {
                model.Reativar();
                _ativoRepo.Atualizar(model);
                return await _ativoRepo.SalvarMudancasAsync();
            }

            return false;
        }
    }
}