using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.Domain.Entities;
using Investimento.Domain.Interfaces.Repositories;
using Investimento.Domain.Interfaces.Services;

namespace Investimento.Domain.Services
{
    public class ClasseDeAtivoService : IClasseDeAtivoService
    {
        private readonly IClasseDeAtivoRepo _classeDeAtivoRepo;
        public ClasseDeAtivoService(IClasseDeAtivoRepo classeDeAtivoRepo)
        {
            _classeDeAtivoRepo = classeDeAtivoRepo;
            
        }
        public async Task<ClasseDeAtivo> AdicionarClasseDeAtivo(ClasseDeAtivo model)
        {
            if (model.Inativo)
                throw new Exception("Não é possível incluir uma Classe de Ativo já inativa.");

            if (await _classeDeAtivoRepo.GetClasseDeAtivoByDescricaoAsync(model.Descricao) != null)
                throw new Exception("Já existe uma atividade com essa descrição");

            if(await _classeDeAtivoRepo.GetClasseDeAtivoByIdAsync(model.Id) == null)
            {
                _classeDeAtivoRepo.Adicionar(model);
                if (await _classeDeAtivoRepo.SalvarMudancasAsync())
                    return model;
            }

            return null;
        }

        public async Task<ClasseDeAtivo> AtualizarClasseDeAtivo(ClasseDeAtivo model)
        {
            if (model.Inativo)
                throw new Exception("Não é possível atualizar uma Classe de Ativo já inativa.");

            var cAtivo = await _classeDeAtivoRepo.GetClasseDeAtivoByIdAsync(model.Id);

            if(cAtivo != null)
            {
                if (cAtivo.Inativo)
                    throw new Exception("Não se pode alterar uma Classe de Ativo inativa.");

                _classeDeAtivoRepo.Atualizar(model);
                if (await _classeDeAtivoRepo.SalvarMudancasAsync())
                    return model;
            }

            return null;
        }

        public async Task<bool> DeletarClasseDeAtivo(int classeDeAtivoId)
        {
            var classeDeAtivo = await _classeDeAtivoRepo.GetClasseDeAtivoByIdAsync(classeDeAtivoId);
            if (classeDeAtivo == null) 
                throw new Exception("Classe de Ativo que tentou deletar não existe.");

            _classeDeAtivoRepo.Deletar(classeDeAtivo);

            return await _classeDeAtivoRepo.SalvarMudancasAsync();

        }
        public async Task<bool> InativarClasseDeAtivo(ClasseDeAtivo model)
        {
            if (model != null)
            {
                model.Inativar();
                _classeDeAtivoRepo.Atualizar<ClasseDeAtivo>(model);
                return await _classeDeAtivoRepo.SalvarMudancasAsync();
            }

            return false;
        }

        public async Task<bool> ReativarClasseDeAtivo(ClasseDeAtivo model)
        {
            if (model != null)
            {
                model.Reativar();
                _classeDeAtivoRepo.Atualizar<ClasseDeAtivo>(model);
                return await _classeDeAtivoRepo.SalvarMudancasAsync();
            }

            return false;
        }

        public async Task<ClasseDeAtivo> GetClasseDeAtivoByIdAsync(int classeDeAtivoId)
        {
            try
            {
                var classesDeAtivo = await _classeDeAtivoRepo.GetClasseDeAtivoByIdAsync(classeDeAtivoId, true);
                if (classesDeAtivo == null) return null;

                return classesDeAtivo;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }            
        }

        public async Task<ClasseDeAtivo[]> GetAllClassesDeAtivosAsync()
        {
            try
            {
                var classesDeAtivos = await _classeDeAtivoRepo.GetAllClasseDeAtivosAsync(true);
                if (classesDeAtivos == null) return null;

                return classesDeAtivos;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
    }
}