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
    public class ClienteRepo : GeralRepo, IClienteRepo
    {
        private readonly InvestimentoContext _context;

        public ClienteRepo(InvestimentoContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Cliente[]> GetAllClientesAsync(bool includeCorretora = false)
        {
            IQueryable<Cliente> query = _context.Clientes;

            if (includeCorretora)
                query = query.Include(c => c.ClientesCorretoras)
                             .ThenInclude(cc => cc.Corretora);

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Cliente[]> GetAllClientesByCorretoraId(int corretoraId, bool includeCorretora = false)
        {
            IQueryable<Cliente> query = _context.Clientes;

            if (includeCorretora)
                query = query.Include(c => c.ClientesCorretoras)
                             .ThenInclude(cc => cc.Corretora);

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id)
                         .Where(c => c.ClientesCorretoras.Any(cc =>cc.CorretoraId == corretoraId));

            return await query.ToArrayAsync();
        }

        public async Task<Cliente> GetClienteByDescricaoAsync(string descricao)
        {
            IQueryable<Cliente> query = _context.Clientes;

            query = query.AsNoTracking()
                         .OrderBy(c => c.Descricao);

            return await query.FirstOrDefaultAsync(c => c.Descricao == descricao);
        }

        public async Task<Cliente> GetClienteByIdAsync(int id, bool includeCorretora = false)
        {
            IQueryable<Cliente> query = _context.Clientes;

            if (includeCorretora)
                query = query.Include(c => c.ClientesCorretoras)
                             .ThenInclude(cc => cc.Corretora);

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id)
                         .Where(c => c.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}