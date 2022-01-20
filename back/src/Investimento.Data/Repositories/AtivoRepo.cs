using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.Data.Context;
using Investimento.Domain.Entities;
using Investimento.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Investimento.Data.Repositories
{
    public class AtivoRepo : GeralRepo, IAtivoRepo
    {
        private readonly InvestimentoContext _context;
        public AtivoRepo(InvestimentoContext context) : base(context)
        {
            _context = context;            
        }
        public async Task<Ativo> GetAtivoByDescricaoAsync(string descricao)
        {
            IQueryable<Ativo> query = _context.Ativos;

            query = query.AsNoTracking()
                         .OrderBy(a => a.Descricao);

            return await query.FirstOrDefaultAsync(a => a.Descricao == descricao);
        }

        public async Task<Ativo> GetAtivoByIdAsync(int id)
        {
            IQueryable<Ativo> query = _context.Ativos;

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(a => a.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Ativo[]> GetAllAtivosAsync()
        {
            IQueryable<Ativo> query = _context.Ativos;

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id);

            return await query.ToArrayAsync();
        }

        public Task<Ativo[]> GetAllAtivosByClasseDeAtivoId()
        {
            throw new NotImplementedException();
        }
    }
}