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
    public class CorretoraRepo : GeralRepo, ICorretoraRepo
    {
        private readonly InvestimentoContext _context;

        public CorretoraRepo(InvestimentoContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Corretora[]> GetAllCorretorasAsync(bool includeCliente = false)
        {
            IQueryable<Corretora> query = _context.Corretoras;

            if (includeCliente)
                query = query.Include(c => c.ClientesCorretoras)
                             .ThenInclude(cc => cc.Cliente);

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Corretora[]> GetAllCorretorasByClienteId(int clienteId, bool includeCliente = false)
        {
            IQueryable<Corretora> query = _context.Corretoras;

            if (includeCliente)
                query = query.Include(c => c.ClientesCorretoras)
                             .ThenInclude(cc => cc.Cliente);

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id)
                         .Where(c => c.ClientesCorretoras.Any(cc =>cc.ClienteId == clienteId));

            return await query.ToArrayAsync();
        }

        public async Task<Corretora> GetCorretoraByDescricaoAsync(string descricao)
        {
            IQueryable<Corretora> query = _context.Corretoras;

            query = query.AsNoTracking()
                         .OrderBy(c => c.Descricao);

            return await query.FirstOrDefaultAsync(c => c.Descricao == descricao);
        }

        public async Task<Corretora> GetCorretoraByIdAsync(int id, bool includeCliente = false)
        {
            IQueryable<Corretora> query = _context.Corretoras;

            if (includeCliente)
                query = query.Include(c => c.ClientesCorretoras)
                             .ThenInclude(cc => cc.Cliente);

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id)
                         .Where(c => c.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}