using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.Data.Context;
using Investimento.Domain.Interfaces.Repositories;

namespace Investimento.Data.Repositories
{
    public class GeralRepo : IGeralRepo
    {
        private readonly InvestimentoContext _context;

        public GeralRepo(InvestimentoContext context)
        {
            _context = context;
            
        }
        public void Adicionar<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Atualizar<T>(T entity) where T : class
        {
             _context.Update(entity);
        }

        public void Deletar<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeletarVarias<T>(T[] entityarray) where T : class
        {
            _context.RemoveRange(entityarray);
        }

        public async Task<bool> SalvarMudancasAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}