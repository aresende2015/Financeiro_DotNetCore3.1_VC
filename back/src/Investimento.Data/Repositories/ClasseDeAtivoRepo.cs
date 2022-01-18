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
    public class ClasseDeAtivoRepo : GeralRepo, IClasseDeAtivoRepo
    {
        private readonly InvestimentoContext _context;

        public ClasseDeAtivoRepo(InvestimentoContext context) : base(context)
        {
            _context = context;
        }
        public async Task<ClasseDeAtivo> PegaPorDescricaoAsync(string descricao)
        {
            IQueryable<ClasseDeAtivo> query = _context.ClasseDeAtivos;

            query = query.AsNoTracking()
                         .OrderBy(ca => ca.Id);

            return await query.FirstOrDefaultAsync(ca => ca.Descricao == descricao);
        }

        public async Task<ClasseDeAtivo> PegaPorIdAsync(int id)
        {
            IQueryable<ClasseDeAtivo> query = _context.ClasseDeAtivos;

            query = query.AsNoTracking()
                         .OrderBy(ca => ca.Id)
                         .Where(ca => ca.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<ClasseDeAtivo[]> PegaTodasAsync()
        {
            IQueryable<ClasseDeAtivo> query = _context.ClasseDeAtivos;

            query = query.AsNoTracking()
                         .OrderBy(ca => ca.Id);

            return await query.ToArrayAsync();
        }
    }
}